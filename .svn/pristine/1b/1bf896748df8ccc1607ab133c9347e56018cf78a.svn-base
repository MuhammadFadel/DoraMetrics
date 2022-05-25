using DoraMetrics.Models;
using DoraMetrics.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoraMetrics.Services
{
    public class GitlabService : BaseService, IGitlabService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GitlabService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Get All Projects Accessed User Token
        public async Task<T> GetProjectsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects" + "?min_access_level=40",
                AccessToken = token
            });
        }

        // Get Specific Project Accessed by User Token
        public async Task<T> GetProjectByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects/" + id,
                AccessToken = token
            });
        }

        // Get Project Change Failure Rate
        public async Task<T> GetProjectChangeFailureRate<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects/" + id + "/dora/metrics?metric=change_failure_rate",
                AccessToken = token
            });
        }

        // Get Project Deployment Frequency
        public async Task<T> GetProjectDeploymentFrequency<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects/" + id + "/dora/metrics?metric=deployment_frequency",
                AccessToken = token
            });
        }

        // Get Project Lead Time For Changes
        public async Task<T> GetProjectLeadTimeForChanges<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects/" + id + "/dora/metrics?metric=lead_time_for_changes",
                AccessToken = token
            });
        }

        
        // Get Projcet Time To Restore Service
        public async Task<T> GetProjectTimeToRestoreService<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects/" + id + "/dora/metrics?metric=time_to_restore_service",
                AccessToken = token
            });
        }
    }
}
