using Helpers.ClientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.GitlabServices.Services
{
    internal class GroupServices : BaseService, IGroupServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GroupServices(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetGroupsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups" + "?min_access_level=40",
                AccessToken = token
            });
        }
        
        public async Task<T> GetSubGroupsAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id + "/subgroups",
                AccessToken = token
            });
        }

        public async Task<T> GetGroupProjectsAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id + "/projects",
                AccessToken = token
            });
        }

        public async Task<T> GetGroupByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetGroupChangeFailureRate<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id + "/dora/metrics?metric=change_failure_rate",
                AccessToken = token
            });
        }

        public async Task<T> GetGroupDeploymentFrequency<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id + "/dora/metrics?metric=deployment_frequency",
                AccessToken = token
            });
        }

        public async Task<T> GetGroupLeadTimeForChanges<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id + "/dora/metrics?metric=lead_time_for_changes",
                AccessToken = token
            });
        }        

        public async Task<T> GetGroupTimeToRestoreService<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "groups/" + id + "/dora/metrics?metric=time_to_restore_service",
                AccessToken = token
            });
        }

        
    }
}
