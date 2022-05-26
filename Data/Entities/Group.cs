using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public int GitlabGroupId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public List<Project> Projects { get; set; }
        public string Visibility { get; set; }
        public bool ShareWithGroupLock { get; set; }
        public bool RequireTwoFactorAuthentication { get; set; }
        public int TwoFactorGracePeriod { get; set; }
        public string ProjectCreationLevel { get; set; }        
        public string SubgroupCreationLevel { get; set; }        
        public bool LfsEnabled { get; set; }
        public int DefaultBranchProtection { get; set; }
        public string AvatarUrl { get; set; }
        public string WebUrl { get; set; }
        public bool RequestAccessEnabled { get; set; }
        public string FullName { get; set; }
        public string FullPath { get; set; }
        public int FileTemplateProjectId { get; set; }
        public int ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
