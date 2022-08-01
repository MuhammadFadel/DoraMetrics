using System;
using System.Collections.Generic;

namespace DoraMetrics.DTOs
{
    public class JiraIssueEventDto
    {
        public long timestamp { get; set; }
        public string webhookEvent { get; set; }
        public string issue_event_type_name { get; set; }
        public UserDto user { get; set; }
        public IssueDto issue { get; set; }
        public ChangelogDto changelog { get; set; }
    }
    
    public class AggregateprogressDto
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class AvatarUrlsDto
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

    public class ChangelogDto
    {
        public string id { get; set; }
        public List<ItemDto> items { get; set; }
    }

    public class CreatorDto
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public AvatarUrlsDto avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
    }

    public class FieldsDto
    {
        public string statuscategorychangedate { get; set; }
        public IssuetypeDto issuetype { get; set; }
        public object timespent { get; set; }
        public object customfield_10030 { get; set; }
        public object customfield_10031 { get; set; }
        public ProjectDto project { get; set; }
        public object customfield_10032 { get; set; }
        public List<object> fixVersions { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolution { get; set; }
        public object customfield_10029 { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public WatchesDto watches { get; set; }
        public IssuerestrictionDto issuerestriction { get; set; }
        public string lastViewed { get; set; }
        public string created { get; set; }
        public object customfield_10020 { get; set; }
        public object customfield_10021 { get; set; }
        public object customfield_10022 { get; set; }
        public PriorityDto priority { get; set; }
        public object customfield_10023 { get; set; }
        public object customfield_10024 { get; set; }
        public object customfield_10025 { get; set; }
        public List<object> labels { get; set; }
        public object customfield_10016 { get; set; }
        public object customfield_10017 { get; set; }        
        public string customfield_10019 { get; set; }
        public object timeestimate { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public List<object> versions { get; set; }
        public List<object> issuelinks { get; set; }
        public object assignee { get; set; }
        public string updated { get; set; }
        public StatusDto status { get; set; }
        public List<object> components { get; set; }
        public object timeoriginalestimate { get; set; }
        public string description { get; set; }
        public object customfield_10010 { get; set; }
        public object customfield_10014 { get; set; }
        public object customfield_10015 { get; set; }
        public TimetrackingDto timetracking { get; set; }
        public object customfield_10005 { get; set; }
        public object customfield_10006 { get; set; }
        public object security { get; set; }
        public object customfield_10007 { get; set; }
        public object customfield_10008 { get; set; }
        public object customfield_10009 { get; set; }
        public object aggregatetimeestimate { get; set; }
        public List<object> attachment { get; set; }
        public string summary { get; set; }
        public CreatorDto creator { get; set; }
        public List<object> subtasks { get; set; }
        public ReporterDto reporter { get; set; }
        public AggregateprogressDto aggregateprogress { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10002 { get; set; }
        public object customfield_10003 { get; set; }
        public object customfield_10004 { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
        public ProgressDto progress { get; set; }
        public VotesDto votes { get; set; }
    }

    public class IssueDto
    {
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public FieldsDto fields { get; set; }
    }

    public class IssuerestrictionDto
    {
        public IssuerestrictionsDto issuerestrictions { get; set; }
        public bool shouldDisplay { get; set; }
    }

    public class IssuerestrictionsDto
    {
    }

    public class IssuetypeDto
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
        public string entityId { get; set; }
        public int hierarchyLevel { get; set; }
    }

    public class ItemDto
    {
        public string field { get; set; }
        public string fieldtype { get; set; }
        public string fieldId { get; set; }
        public object from { get; set; }
        public object fromString { get; set; }
        public object to { get; set; }
        public string toString { get; set; }
    }

    public class NonEditableReasonDto
    {
        public string reason { get; set; }
        public string message { get; set; }
    }

    public class PriorityDto
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class ProgressDto
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class ProjectDto
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public bool simplified { get; set; }
        public AvatarUrlsDto avatarUrls { get; set; }
    }

    public class ReporterDto
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public AvatarUrlsDto avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
    }

    public class StatusDto
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategoryDto statusCategory { get; set; }
    }

    public class StatusCategoryDto
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class TimetrackingDto
    {
    }

    public class UserDto 
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public AvatarUrlsDto avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
    }

    public class VotesDto
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class WatchesDto
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class transtionIssueDto
    {
        public transitionDto transition { get; set; }
    }
    public class transitionDto
    {
        public string id { get; set; }
    }

}
