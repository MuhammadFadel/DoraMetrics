using Integrations.JiraServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.JiraServices
{
    public interface IIssueServices
    {
        Task<T> GetIssueByIdAsync<T>(int id, string token);        
        Task<T> SetIssueStatus<T>(string key, IssueStatus issueStatus, string token);        
    }

    
}
