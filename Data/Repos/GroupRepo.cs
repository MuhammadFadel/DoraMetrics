using Data.Entities;
using Helpers.Paginations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class GroupRepo : IGroupRepo
    {
        private readonly ApplicationDbContext _context;
        public GroupRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Group> GetGroup(int id)
        {
            var group = await _context.Groups
                                .Include(pr => pr.Projects)
                                .FirstOrDefaultAsync(p => p.Id == id);

            return group;
        }
        public async Task<Group> GetGroupWithGitlabId(int id)
        {
            var group = await _context.Groups
                                .Include(pr => pr.Projects)
                                .Include(mt => mt.Metrics)
                                //.Include(mt => mt.Metrics.DeploymentFrequency)
                                //.Include(mt => mt.Metrics.ChangeFailureRate)
                                //.Include(mt => mt.Metrics.LeadTimeForChanges)
                                //.Include(mt => mt.Metrics.TimeToRestoreService)
                                .FirstOrDefaultAsync(p => p.GitlabGroupId == id);

            return group;
        }

        public async Task<List<Group>> GetGroups()
        {
            var groups = await _context.Groups
                                .Include(pr => pr.Projects)
                            .ToListAsync();            
            return groups;
        }

        public async Task<bool> GroupIsExist(int id)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(gr => gr.Id == id || gr.GitlabGroupId == id);
            return (group != null) ? true : false; 
        }
    }
}
