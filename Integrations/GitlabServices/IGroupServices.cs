using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.GitlabServices
{
    internal interface IGroupServices
    {
        Task<T> GetGroupByIdAsync<T>(int id, string token);
        Task<T> GetGroupsAsync<T>(string token);
        Task<T> GetSubGroupsAsync<T>(int id, string token);
        Task<T> GetGroupProjectsAsync<T>(int id, string token);
        Task<T> GetGroupDeploymentFrequency<T>(int id, string token);
        Task<T> GetGroupLeadTimeForChanges<T>(int id, string token);
        Task<T> GetGroupTimeToRestoreService<T>(int id, string token);
        Task<T> GetGroupChangeFailureRate<T>(int id, string token);
    }
}
