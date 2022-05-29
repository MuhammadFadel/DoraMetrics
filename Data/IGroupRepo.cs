using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IGroupRepo
    {
        Task<Group> GetGroup(int id);
        Task<bool> GroupIsExist(int id);
        Task<Group> GetGroupWithGitlabId(int id);
        Task<List<Group>> GetGroups();
    }
}
