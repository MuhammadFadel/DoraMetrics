using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraMetrics.Services.IServices
{
    public interface IGitlabService
    {
        Task<T> GetProjectByIdAsync<T>(int id, string token);
        Task<T> GetProjectsAsync<T>(string token);
        Task<T> GetProjectDeploymentFrequency<T>(int id, string token);
        Task<T> GetProjectLeadTimeForChanges<T>(int id, string token);
        Task<T> GetProjectTimeToRestoreService<T>(int id, string token);
        Task<T> GetProjectChangeFailureRate<T>(int id, string token);
    }
}
