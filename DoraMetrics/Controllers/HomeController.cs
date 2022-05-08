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

        public async Task<IActionResult> GitlabProjectDetails(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;
            var projectResponse = await _gitlabService.GetProjectByIdAsync<ApiResponse>(id, accessToken);
            if (projectResponse != null && projectResponse.IsSuccess)
            {
                var project = JsonConvert.DeserializeObject<GitlabProjectDto>(Convert.ToString(projectResponse.Result));
                return View(project);
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
