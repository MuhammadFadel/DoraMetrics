using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int GitlabProjectId { get; set; }                               
        public Metrics Metrics { get; set; }                               
        public Links Links { get; set; }        
        public Permissions Permissions { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Description { get; set; }
        public string DefaultBranch { get; set; }
        public string Visibility { get; set; }        
        public string HttpUrlToRepo { get; set; }
        public string WebUrl { get; set; }        
        public string Name { get; set; }
        public string NameWithNamespace { get; set; }
        public string Path { get; set; }              
        public int OpenIssuesCount { get; set; }        
        public DateTime CreatedAt { get; set; }
        public DateTime LastActivityAt { get; set; }
        public int CreatorId { get; set; }               
        public string AvatarUrl { get; set; }        
        public int ForksCount { get; set; }
        public int StarCount { get; set; }
        
    }
}
