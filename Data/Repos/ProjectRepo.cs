﻿using Data.Entities;
using Helpers.Paginations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProject(int id)
        {
            var product = await _context.Projects                                
                                .Include(pr => pr.Permissions)                                
                                .Include(mt => mt.Metrics)                                
                                .Include(li => li.Links)
                                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }
        public async Task<Project> GetProjectWithGitlabId(int id)
        {
            var product = await _context.Projects                                
                                .Include(pr => pr.Permissions)                                
                                .Include(mt => mt.Metrics)                                
                                .Include(li => li.Links)
                                .FirstOrDefaultAsync(p => p.GitlabProjectId == id);

            return product;
        }

        public async Task<Metrics> GetProjectMetrics(int id)
        {
            return await _context.Metrics
                                .FirstOrDefaultAsync(p =>  p.Id == id && p.ProjectType == Enums.ProjectType.Project);
        }


        public async Task<PagedList<Project>> GetProjects(ProjectParams projectParams)
        {
            var products = _context.Projects                            
                                .Include(pr => pr.Permissions)                                
                                .Include(mt => mt.Metrics)                                
                                .Include(li => li.Links)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(projectParams.OrderBy))
            {
                switch (projectParams.OrderBy)
                {
                    case "LastActivityAt":
                        products = products.OrderByDescending(p => p.LastActivityAt);
                        break;
                    default:
                        break;
                }
            }

            return await PagedList<Project>.CreateAsync(products, projectParams.PageNumber, projectParams.PageSize);
        }

        public async Task<bool> ProjectIsExist(int id)
        {
            var group = await _context.Projects.FirstOrDefaultAsync(pr => pr.Id == id || pr.GitlabProjectId == id);
            return (group != null) ? true : false;
        }        
    }
}
