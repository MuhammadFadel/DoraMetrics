using AutoMapper;
using Data;
using Data.Entities;
using DoraMetrics.DTOs;
using DoraMetrics.Models;
using Helpers.ClientServices;
using Helpers.Extentions;
using Integrations.GitlabServices;
using Integrations.JiraServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraMetrics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IGroupServices _gitlabGroupServices;
        private readonly IProjectServices _gitlabProjectServices;
        private readonly IMapper _mapper;
        public readonly IProjectRepo _projectRepo;
        public readonly IGroupRepo _groupRepo;
        private readonly IIssueServices _issueServices;
        private readonly IIssueEventRepo _issueEventRepo;
        private readonly IUnitOfWork _db;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,
            IProjectServices gitlabProjectServices, IMapper mapper, IProjectRepo projectRepo,
            IUnitOfWork db, IGroupServices gitlabGroupServices, IGroupRepo groupRepo,
            IIssueServices issueServices, IIssueEventRepo issueEventRepo)
        {
            _logger = logger;
            _config = configuration;
            _gitlabProjectServices = gitlabProjectServices;
            _mapper = mapper;
            _projectRepo = projectRepo;
            _db = db;
            _gitlabGroupServices = gitlabGroupServices;
            _groupRepo = groupRepo;
            _issueServices = issueServices;
            _issueEventRepo = issueEventRepo;
        }


        public async Task<IActionResult> Index()
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var response = await _gitlabGroupServices.GetGroupsAsync<ApiResponse>(accessToken);
            if (response != null && response.IsSuccess)
            {
                var groupsDto = JsonConvert.DeserializeObject<List<GitlabGroupDto>>(Convert.ToString(response.Result));
                var groups = _mapper.Map<IEnumerable<Group>>(groupsDto);
                foreach (var group in groups)
                {
                    if (!await _groupRepo.GroupIsExist(group.GitlabGroupId))
                        _db.Add(group);
                    try { await _db.SaveAll(); }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                }
                return View(groups);
            }
            return View();
        }
                
        public async Task<IActionResult> GitlabProjects()
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var response = await _gitlabProjectServices.GetProjectsAsync<ApiResponse>(accessToken);
            if (response != null && response.IsSuccess)
            {
                var projectsDto = JsonConvert.DeserializeObject<List<GitlabProjectDto>>(Convert.ToString(response.Result));
                var projects = _mapper.Map<IEnumerable<Data.Entities.Project>>(projectsDto);

                foreach (var project in projects)
                {
                    var dbProject = await _projectRepo.GetProjectWithGitlabId(project.GitlabProjectId);
                    if (dbProject != null)
                    {
                        dbProject.MappingUpdates(project, true);
                        _db.Update(dbProject);
                    }
                    else
                        _db.Add(project);
                }

                try
                {
                    await _db.SaveAll();
                    return View(projects);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

            }
            return View();
        }

        public async Task<IActionResult> GitlabProjectDetails(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectResponse = await _gitlabProjectServices.GetProjectByIdAsync<ApiResponse>(id, accessToken);
            if (projectResponse != null && projectResponse.IsSuccess)
            {
                var projectDto = JsonConvert.DeserializeObject<GitlabProjectDto>(Convert.ToString(projectResponse.Result));                
                var mappedProject = _mapper.Map<Data.Entities.Project>(projectDto);                

                var dbProject = await _projectRepo.GetProjectWithGitlabId(mappedProject.GitlabProjectId);
                if (dbProject != null)
                {
                    mappedProject.Metrics = dbProject.Metrics;
                    dbProject.MappingUpdates(mappedProject, true, 2);

                    dbProject.Metrics = MappingMetrics(dbProject.Metrics, await GetGitlabMetric(id, Enums.MetricType.ChangeFailureRate, Enums.ProjectType.Project),
                        Enums.MetricType.ChangeFailureRate, Enums.ProjectType.Project);
                    dbProject.Metrics = MappingMetrics(dbProject.Metrics, await GetGitlabMetric(id, Enums.MetricType.DeploymentFrequency, Enums.ProjectType.Project),
                        Enums.MetricType.DeploymentFrequency, Enums.ProjectType.Project);
                    dbProject.Metrics = MappingMetrics(dbProject.Metrics, await GetGitlabMetric(id, Enums.MetricType.LeadTimeForChanges, Enums.ProjectType.Project),
                        Enums.MetricType.LeadTimeForChanges, Enums.ProjectType.Project);
                    dbProject.Metrics = MappingMetrics(dbProject.Metrics, await GetGitlabMetric(id, Enums.MetricType.TimeToRestoreService, Enums.ProjectType.Project),
                        Enums.MetricType.TimeToRestoreService, Enums.ProjectType.Project);
                    
                    _db.Update(dbProject);
                }
                else if (await _groupRepo.GroupIsExist(projectDto.@namespace.id))
                {
                    var dbGroup = await _groupRepo.GetGroupWithGitlabId(projectDto.@namespace.id);
                    mappedProject.GroupId = dbGroup.Id;
                    _db.Add(mappedProject);
                }

                try { await _db.SaveAll(); }
                catch (Exception ex) { throw new Exception(ex.Message); }

                mappedProject.GroupId = projectDto.@namespace.id;
                return View(mappedProject);

            }
            return View();
        }

        public async Task<IActionResult> GitlabGroupDetails(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var groupResponse = await _gitlabGroupServices.GetGroupByIdAsync<ApiResponse>(id, accessToken);
            if (groupResponse != null && groupResponse.IsSuccess)
            {
                var groupDto = JsonConvert.DeserializeObject<GitlabGroupDto>(Convert.ToString(groupResponse.Result));                
                var mappedGroup = _mapper.Map<Group>(groupDto);                              

                var dbGroup = await _groupRepo.GetGroupWithGitlabId(mappedGroup.GitlabGroupId);
                if (dbGroup == null)
                {
                    _db.Add(mappedGroup);
                    try { await _db.SaveAll(); }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                    dbGroup = mappedGroup;
                }
                if (dbGroup != null)
                {
                    mappedGroup.Metrics = dbGroup.Metrics;
                    dbGroup.MappingUpdates(mappedGroup, true, 2);

                    dbGroup.Metrics = MappingMetrics(dbGroup.Metrics, await GetGitlabMetric(id, Enums.MetricType.ChangeFailureRate, Enums.ProjectType.Group),
                        Enums.MetricType.ChangeFailureRate, Enums.ProjectType.Group);
                    dbGroup.Metrics = MappingMetrics(dbGroup.Metrics, await GetGitlabMetric(id, Enums.MetricType.DeploymentFrequency, Enums.ProjectType.Group),
                        Enums.MetricType.DeploymentFrequency, Enums.ProjectType.Group);
                    dbGroup.Metrics = MappingMetrics(dbGroup.Metrics, await GetGitlabMetric(id, Enums.MetricType.LeadTimeForChanges, Enums.ProjectType.Group),
                        Enums.MetricType.LeadTimeForChanges, Enums.ProjectType.Group);
                    dbGroup.Metrics = MappingMetrics(dbGroup.Metrics, await GetGitlabMetric(id, Enums.MetricType.TimeToRestoreService, Enums.ProjectType.Group),
                        Enums.MetricType.TimeToRestoreService, Enums.ProjectType.Group);
                    
                    _db.Update(dbGroup);                    
                }
                
                try { await _db.SaveAll(); }
                catch (Exception ex) { throw new Exception(ex.Message); }

                return View(mappedGroup);
            }
            return View();
        }

        public List<Metrics> MappingMetrics(List<Metrics> metrics, List<MetricValueDto> metricValueDto, 
            Enums.MetricType metricType, Enums.ProjectType projectType) 
        {
            if(metrics != null && metricValueDto != null)
            {
                foreach (var metric in metricValueDto)
                {

                    var mappedMetric = metrics.Find(m => m.Date == metric.date && m.MetricType == metricType && m.ProjectType == projectType);
                    if (mappedMetric != null)
                        mappedMetric.Value = metric.value;
                    else
                        metrics.Add(new Metrics
                        {
                            MetricType = metricType,
                            ProjectType = projectType,
                            Date = metric.date,
                            Value = metric.value
                        });
                }                                   
            }
            return metrics;
        }
        
        public async Task<List<MetricValueDto>> GetGitlabMetric(int id, Enums.MetricType metricType, Enums.ProjectType projectType)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            ApiResponse apiResponse = null;
            switch (metricType)
            {
                case Enums.MetricType.DeploymentFrequency:
                    if(projectType == Enums.ProjectType.Project)
                        apiResponse = await _gitlabProjectServices.GetProjectDeploymentFrequency<ApiResponse>(id, accessToken);
                    else if (projectType == Enums.ProjectType.Group)
                        apiResponse = await _gitlabGroupServices.GetGroupDeploymentFrequency<ApiResponse>(id, accessToken);
                    break;

                case Enums.MetricType.LeadTimeForChanges:
                    if (projectType == Enums.ProjectType.Project)
                        apiResponse = await _gitlabProjectServices.GetProjectLeadTimeForChanges<ApiResponse>(id, accessToken);
                    else if (projectType == Enums.ProjectType.Group)
                        apiResponse = await _gitlabGroupServices.GetGroupLeadTimeForChanges<ApiResponse>(id, accessToken);
                    break;

                case Enums.MetricType.TimeToRestoreService:
                    if (projectType == Enums.ProjectType.Project)
                        apiResponse = await _gitlabProjectServices.GetProjectTimeToRestoreService<ApiResponse>(id, accessToken);
                    else if (projectType == Enums.ProjectType.Group)
                        apiResponse = await _gitlabGroupServices.GetGroupTimeToRestoreService<ApiResponse>(id, accessToken);
                    break;

                case Enums.MetricType.ChangeFailureRate:
                    if (projectType == Enums.ProjectType.Project)
                        apiResponse = await _gitlabProjectServices.GetProjectChangeFailureRate<ApiResponse>(id, accessToken);
                    else if (projectType == Enums.ProjectType.Group)
                        apiResponse = await _gitlabGroupServices.GetGroupChangeFailureRate<ApiResponse>(id, accessToken);
                    break;

                default:
                    break;
            }
            
            if (apiResponse != null && apiResponse.IsSuccess)
            {
                var metricValueDto =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(apiResponse.Result));                
                return metricValueDto;
            }
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
