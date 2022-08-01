using Helpers.ClientServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.JiraServices.Services
{
    public class IssueServices : BaseService, IIssueServices
    {
        private readonly IHttpClientFactory _httpClient;

        public IssueServices(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<T> GetIssueByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.JiraApiBase + "issue/" + id,
                AccessToken = token
            });
        }
        public async Task<T> GetIssueByKeyAsync<T>(string key, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.JiraApiBase + "issue/" + key,
                AccessToken = token
            });
        }

        public async Task<T> SetIssueStatus<T>(string key, IssueStatus issueStatus, string token)
        {
            var reqData = new transtionIssueDto();
            switch (issueStatus)
            {
                case IssueStatus.Done:
                    reqData.transition = new transitionDto { id = "31" };
                    break;
                case IssueStatus.InProgress:
                    reqData.transition = new transitionDto { id = "21" };
                    break;
                case IssueStatus.ToDo:
                    reqData.transition = new transitionDto { id = "11" };
                    break;
                default:
                    break;
            }
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                ApiUrl = SD.JiraApiBase + "issue/" + key + "/transitions",
                AccessToken = token,
                Data = reqData
            });
        }
        
    }

    public enum IssueStatus
    {
        Done,
        InProgress,
        ToDo,
    }

    public class transtionIssueDto
    {
        public transitionDto transition { get; set; }
    }
    public class transitionDto
    {
        public string id { get; set; }
    }
}
