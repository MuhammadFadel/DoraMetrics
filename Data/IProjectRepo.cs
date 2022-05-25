using Data.Entities;
using Helpers.Paginations;
using System.Threading.Tasks;

namespace Data
{
    public interface IProjectRepo
    {
        Task<Project> GetProject(int id);
        Task<Project> GetProjectWithGitlabId(int id);
        Task<PagedList<Project>> GetProjects(ProjectParams projectParams);
        //Task<PagedList<UserProducts>> GetUserProducts(UserProductsParams userParams);        
        //Task<UserProducts> GetUserProduct(Guid id);
    }
}
