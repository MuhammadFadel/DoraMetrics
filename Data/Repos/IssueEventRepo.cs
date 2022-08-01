using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class IssueEventRepo : IIssueEventRepo
    {
        private readonly ApplicationDbContext _context;
        public IssueEventRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<JiraIssueEvent>> GetGroups()
        {
            var events = await _context.JiraIssueEvents
                                .ToListAsync();
            return events;
        }

        public async Task<JiraIssueEvent> GetIssueEvent(int id)
        {
            var issueEvent = await _context.JiraIssueEvents
                                .Include(pr => pr.Changelog)
                                .Include(mt => mt.User)
                                .Include(mt => mt.Issue)
                                .FirstOrDefaultAsync(p => p.JiraIssueEventId == id);
            return issueEvent;
        }

        public async Task<JiraIssueEvent> GetIssueEventWithJiraId(string id)
        {
            var issue = await _context.Issues
                                .FirstOrDefaultAsync(p => p.Id == id);
            if (issue == null)
                return null;
            
            var issueEvent = await _context.JiraIssueEvents
                                .Include(pr => pr.Changelog)
                                .Include(mt => mt.User)
                                .Include(mt => mt.Issue)
                                .FirstOrDefaultAsync(p => p.IssueId == issue.IssueId);
            return issueEvent;
        }

        public async Task<bool> IssueEventIsExist(int id)
        {
            var issueEvent = await _context.JiraIssueEvents
                .FirstOrDefaultAsync(gr => gr.JiraIssueEventId == id || gr.IssueId == id);
            return (issueEvent != null) ? true : false;
        }
    }
}
