using DoraMetrics.Models;
using DoraMetrics.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoraMetrics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;        
        private readonly IGitlabService _gitlabService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IGitlabService gitlabService)
        {
            _logger = logger;
            _config = configuration;
            _gitlabService = gitlabService;
        }

        public async Task<IActionResult> Index()
        {

            List<GitlabProjectDto> projects = new();
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var response = await _gitlabService.GetProjectsAsync<ApiResponse>(accessToken);
            if (response != null && response.IsSuccess)
            {
                projects = JsonConvert.DeserializeObject<List<GitlabProjectDto>>(Convert.ToString(response.Result));
                return View(projects);
            }
            return View();
        }

        public async Task<IActionResult> GitlabProjects()
        {
            List<GitlabProjectDto> projects = new();
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var response = await _gitlabService.GetProjectsAsync<ApiResponse>(accessToken);
            if (response != null && response.IsSuccess)
            {
                projects = JsonConvert.DeserializeObject<List<GitlabProjectDto>>(Convert.ToString(response.Result));
                return View(projects);
            }
            return View();
        }        

        public async Task<List<MetricValue>> GitlabProjectChangeFailureRate(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectChangeFailureRateResponse = await _gitlabService.GetProjectChangeFailureRate<ApiResponse>(id, accessToken);
            if (projectChangeFailureRateResponse != null && projectChangeFailureRateResponse.IsSuccess)
            {                
                var ChangeFailureRate =
                    JsonConvert.DeserializeObject<List<MetricValue>>(Convert.ToString(projectChangeFailureRateResponse.Result));
                return ChangeFailureRate;
            }
            return null;
        }
        public async Task<List<MetricValue>> GitlabProjectDeploymentFrequency(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectDeploymentFrequencyResponse = await _gitlabService.GetProjectDeploymentFrequency<ApiResponse>(id, accessToken);
            if (projectDeploymentFrequencyResponse != null && projectDeploymentFrequencyResponse.IsSuccess)
            {
                var DeploymentFrequency =
                    JsonConvert.DeserializeObject<List<MetricValue>>(Convert.ToString(projectDeploymentFrequencyResponse.Result));
                return DeploymentFrequency;
            }
            return null;
        }
        public async Task<List<MetricValue>> GitlabProjectLeadTimeForChanges(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectLeadTimeForChangesResponse = await _gitlabService.GetProjectLeadTimeForChanges<ApiResponse>(id, accessToken);
            if (projectLeadTimeForChangesResponse != null && projectLeadTimeForChangesResponse.IsSuccess)
            {
                var LeadTimeForChanges =
                    JsonConvert.DeserializeObject<List<MetricValue>>(Convert.ToString(projectLeadTimeForChangesResponse.Result));
                return LeadTimeForChanges;
            }
            return null;
        }
        public async Task<List<MetricValue>> GitlabProjectTimeToRestoreService(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectTimeToRestoreServiceResponse = await _gitlabService.GetProjectTimeToRestoreService<ApiResponse>(id, accessToken);
            if (projectTimeToRestoreServiceResponse != null && projectTimeToRestoreServiceResponse.IsSuccess)
            {
                var TimeToRestoreService =
                    JsonConvert.DeserializeObject<List<MetricValue>>(Convert.ToString(projectTimeToRestoreServiceResponse.Result));
                return TimeToRestoreService;
            }
            return null;
        }

        public async Task<IActionResult> GitlabProjectDetails(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectResponse = await _gitlabService.GetProjectByIdAsync<ApiResponse>(id, accessToken);
            if (projectResponse != null && projectResponse.IsSuccess)
            {
                var project = JsonConvert.DeserializeObject<GitlabProjectDto>(Convert.ToString(projectResponse.Result));
                try
                {
                    project.DoraMetricsAnalytics = new DoraMetricsAnalytics();
                    project.DoraMetricsAnalytics.ChangeFailureRate = await GitlabProjectChangeFailureRate(id);
                    project.DoraMetricsAnalytics.DeploymentFrequency = await GitlabProjectDeploymentFrequency(id);
                    project.DoraMetricsAnalytics.LeadTimeForChanges = await GitlabProjectLeadTimeForChanges(id);
                    project.DoraMetricsAnalytics.TimeToRestoreService = await GitlabProjectTimeToRestoreService(id);
                    return View(project);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }                               
            }
            return View();
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
