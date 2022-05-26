using Data.Entities;
using Helpers.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IGroupRepo
    {
        Task<Group> GetGroup(int id);
        Task<Group> GetGroupWithGitlabId(int id);
        Task<PagedList<Group>> GetGroups(ProjectParams projectParams);
    }
}
