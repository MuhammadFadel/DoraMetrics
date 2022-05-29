using AutoMapper;
using Data;
using Data.Entities;
using DoraMetrics.DTOs;
using DoraMetrics.Models;
using Helpers.ClientServices;
using Helpers.Extentions;
using Integrations.GitlabServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IUnitOfWork _db;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,
            IProjectServices gitlabProjectServices, IMapper mapper, IProjectRepo projectRepo,
            IUnitOfWork db, IGroupServices gitlabGroupServices, IGroupRepo groupRepo)
        {
            _logger = logger;
            _config = configuration;
            _gitlabProjectServices = gitlabProjectServices;
            _mapper = mapper;
            _projectRepo = projectRepo;
            _db = db;
            _gitlabGroupServices = gitlabGroupServices;
            _groupRepo = groupRepo;
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
                var projects = _mapper.Map<IEnumerable<Project>>(projectsDto);

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

        public async Task<List<MetricValueDto>> GitlabProjectChangeFailureRate(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectChangeFailureRateResponse = await _gitlabProjectServices.GetProjectChangeFailureRate<ApiResponse>(id, accessToken);
            if (projectChangeFailureRateResponse != null && projectChangeFailureRateResponse.IsSuccess)
            {
                var ChangeFailureRate =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(projectChangeFailureRateResponse.Result));
                var project = await _projectRepo.GetProjectWithGitlabId(id);
                foreach (var cfr in ChangeFailureRate)
                {
                    //if(project.Metrics.ChangeFailureRate)
                }
                return ChangeFailureRate;
            }
            return null;
        }
        public async Task<List<MetricValueDto>> GitlabProjectDeploymentFrequency(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectDeploymentFrequencyResponse = await _gitlabProjectServices.GetProjectDeploymentFrequency<ApiResponse>(id, accessToken);
            if (projectDeploymentFrequencyResponse != null && projectDeploymentFrequencyResponse.IsSuccess)
            {
                var DeploymentFrequency =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(projectDeploymentFrequencyResponse.Result));
                return DeploymentFrequency;
            }
            return null;
        }
        public async Task<List<MetricValueDto>> GitlabProjectLeadTimeForChanges(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectLeadTimeForChangesResponse = await _gitlabProjectServices.GetProjectLeadTimeForChanges<ApiResponse>(id, accessToken);
            if (projectLeadTimeForChangesResponse != null && projectLeadTimeForChangesResponse.IsSuccess)
            {
                var LeadTimeForChanges =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(projectLeadTimeForChangesResponse.Result));
                return LeadTimeForChanges;
            }
            return null;
        }
        public async Task<List<MetricValueDto>> GitlabProjectTimeToRestoreService(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectTimeToRestoreServiceResponse = await _gitlabProjectServices.GetProjectTimeToRestoreService<ApiResponse>(id, accessToken);
            if (projectTimeToRestoreServiceResponse != null && projectTimeToRestoreServiceResponse.IsSuccess)
            {
                var TimeToRestoreService =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(projectTimeToRestoreServiceResponse.Result));
                return TimeToRestoreService;
            }
            return null;
        }

        public async Task<IActionResult> GitlabProjectDetails(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectResponse = await _gitlabProjectServices.GetProjectByIdAsync<ApiResponse>(id, accessToken);
            if (projectResponse != null && projectResponse.IsSuccess)
            {
                var projectDto = JsonConvert.DeserializeObject<GitlabProjectDto>(Convert.ToString(projectResponse.Result));

                projectDto.DoraMetricsAnalytics = new DoraMetricsAnalyticsDto()
                {
                    ChangeFailureRate = await GitlabProjectChangeFailureRate(id),
                    DeploymentFrequency = await GitlabProjectDeploymentFrequency(id),
                    LeadTimeForChanges = await GitlabProjectLeadTimeForChanges(id),
                    TimeToRestoreService = await GitlabProjectLeadTimeForChanges(id)
                };

                var mappedProject = _mapper.Map<Project>(projectDto);
                var dbProject = await _projectRepo.GetProjectWithGitlabId(mappedProject.GitlabProjectId);

                if (dbProject != null)
                {
                    dbProject.MappingUpdates(mappedProject, true, 2);
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

                groupDto.DoraMetricsAnalytics = new DoraMetricsAnalyticsDto()
                {
                    ChangeFailureRate = await GitlabGroupChangeFailureRate(id),
                    DeploymentFrequency = await GitlabGroupDeploymentFrequency(id),
                    LeadTimeForChanges = await GitlabGroupLeadTimeForChanges(id),
                    TimeToRestoreService = await GitlabGroupTimeToRestoreService(id)
                };

                var mappedGroup = _mapper.Map<Group>(groupDto);

                if (!await _groupRepo.GroupIsExist(mappedGroup.GitlabGroupId))
                {
                    _db.Add(mappedGroup);
                    try { await _db.SaveAll(); }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                }
                return View(mappedGroup);
            }
            return View();
        }


        public async Task<List<MetricValueDto>> GitlabGroupChangeFailureRate(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var groupChangeFailureRateResponse = await _gitlabGroupServices.GetGroupChangeFailureRate<ApiResponse>(id, accessToken);
            if (groupChangeFailureRateResponse != null && groupChangeFailureRateResponse.IsSuccess)
            {
                var ChangeFailureRate =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(groupChangeFailureRateResponse.Result));
                var project = await _projectRepo.GetProjectWithGitlabId(id);
                foreach (var cfr in ChangeFailureRate)
                {
                    //if(project.Metrics.ChangeFailureRate)
                }
                return ChangeFailureRate;
            }
            return null;
        }
        public async Task<List<MetricValueDto>> GitlabGroupDeploymentFrequency(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var groupDeploymentFrequencyResponse = await _gitlabGroupServices.GetGroupDeploymentFrequency<ApiResponse>(id, accessToken);
            if (groupDeploymentFrequencyResponse != null && groupDeploymentFrequencyResponse.IsSuccess)
            {
                var DeploymentFrequency =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(groupDeploymentFrequencyResponse.Result));
                return DeploymentFrequency;
            }
            return null;
        }
        public async Task<List<MetricValueDto>> GitlabGroupLeadTimeForChanges(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var groupLeadTimeForChangesResponse = await _gitlabGroupServices.GetGroupLeadTimeForChanges<ApiResponse>(id, accessToken);
            if (groupLeadTimeForChangesResponse != null && groupLeadTimeForChangesResponse.IsSuccess)
            {
                var LeadTimeForChanges =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(groupLeadTimeForChangesResponse.Result));
                return LeadTimeForChanges;
            }
            return null;
        }
        public async Task<List<MetricValueDto>> GitlabGroupTimeToRestoreService(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var groupTimeToRestoreServiceResponse = await _gitlabGroupServices.GetGroupTimeToRestoreService<ApiResponse>(id, accessToken);
            if (groupTimeToRestoreServiceResponse != null && groupTimeToRestoreServiceResponse.IsSuccess)
            {
                var TimeToRestoreService =
                    JsonConvert.DeserializeObject<List<MetricValueDto>>(Convert.ToString(groupTimeToRestoreServiceResponse.Result));
                return TimeToRestoreService;
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
