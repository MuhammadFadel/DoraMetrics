using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class JiraIssueEvent
    {
        [Key]
        public int JiraIssueEventId { get; set; }
        public long Timestamp { get; set; }
        public string WebhookEvent { get; set; }
        public string IssueEventTypeName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public int ChangelogId { get; set; }
        public Changelog Changelog { get; set; }
        public bool Paid { get; set; }
        public string PaidAt { get; set; }
    }
    public class Changelog
    {
        [Key]
        public int ChangelogId { get; set; }
        public string Id { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Creator
    {
        [Key]
        public int CreatorId { get; set; }
        public string Self { get; set; }
        public string AccountId { get; set; }        
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
        public string AccountType { get; set; }
    }    
    public class Fields
    {
        [Key]
        public int FieldsId { get; set; }
        public string StatusCtegoryChangeDate { get; set; }
        public int IssueTypeId { get; set; }        
        public Issuetype IssueType { get; set; }                             
        public int WatchesId { get; set; }        
        public Watches Watches { get; set; }        
        public string lastViewed { get; set; }
        public string Created { get; set; }        
        public int PriorityId { get; set; }        
        public Priority Priority { get; set; }                        
        public string Updated { get; set; }
        public int StatusId { get; set; }        
        public Status Status { get; set; }        
        public string Description { get; set; }                                                   
        public string Summary { get; set; }
        public int CreatorId { get; set; }        
        public Creator Creator { get; set; }        
        public int ReporterId { get; set; }                                       
        public Reporter Reporter { get; set; }                                       
    }
    public class Issue
    {
        [Key]
        public int IssueId { get; set; }        
        public string Id { get; set; }
        public string Self { get; set; }
        public string Key { get; set; }
        public int FieldsId { get; set; }
        public Fields Fields { get; set; }
    }    
    

    public class Issuetype
    {
        [Key]
        public int IssuetypeId { get; set; }
        public string Self { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public bool Subtask { get; set; }
        public int AvatarId { get; set; }
        public string EntityId { get; set; }
        public int HierarchyLevel { get; set; }
    }

    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Field { get; set; }
        public string FieldType { get; set; }
        public string FieldId { get; set; }
        public string From { get; set; }
        public string FromString { get; set; }
        public string To { get; set; }
        public string ToString { get; set; }
        public int ChangelogId { get; set; }
        public Changelog Changelog { get; set; }
    }    
    public class Priority
    {
        [Key]
        public int PriorityId { get; set; }
        public string Self { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }       
    public class Reporter
    {
        [Key]
        public int ReporterId { get; set; }
        public string Self { get; set; }
        public string AccountId { get; set; }        
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
        public string AccountType { get; set; }
    }
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Self { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int StatusCategoryId { get; set; }
        public StatusCategory StatusCategory { get; set; }
    }
    public class StatusCategory
    {
        [Key]
        public int StatusCategoryId { get; set; }
        public string Self { get; set; }
        public int Id { get; set; }
        public string Key { get; set; }
        public string ColorName { get; set; }
        public string Name { get; set; }
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Self { get; set; }
        public string AccountId { get; set; }        
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
        public string AccountType { get; set; }
    }
    
    public class Watches
    {
        public int WatchesId { get; set; }
        public string Self { get; set; }
        public int WatchCount { get; set; }
        public bool IsWatching { get; set; }
    }
}
