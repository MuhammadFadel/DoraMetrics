using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IIssueEventRepo
    {
        Task<JiraIssueEvent> GetIssueEvent(int id);
        Task<bool> IssueEventIsExist(int id);
        Task<JiraIssueEvent> GetIssueEventWithJiraId(string id);
        Task<List<JiraIssueEvent>> GetGroups();
    }
}
