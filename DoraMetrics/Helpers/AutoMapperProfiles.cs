using AutoMapper;
using Data.Entities;
using DoraMetrics.DTOs;
using DoraMetrics.Models;

namespace DoraMetrics.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<Project, GitlabProjectDto>();
            CreateMap<GitlabProjectDto, Project>()
                .ForMember(m => m.GitlabProjectId, opt => opt.MapFrom(s => s.id))
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Links, opt => opt.MapFrom(s => s._links));

            CreateMap<Group, GitlabGroupDto>();
            CreateMap<GitlabGroupDto, Group>()
                .ForMember(m => m.GitlabGroupId, opt => opt.MapFrom(s => s.id))
                .ForMember(m => m.Id, opt => opt.Ignore());


            CreateMap<Links, LinksDto>();
            CreateMap<LinksDto, Links>();

            CreateMap<Permissions, PermissionsDto>();
            CreateMap<PermissionsDto, Permissions>();

            CreateMap<AccessInfo, ProjectAccessDto>();
            CreateMap<AccessInfo, GroupAccessDto>();
            CreateMap<ProjectAccessDto, AccessInfo>();
            CreateMap<GroupAccessDto, AccessInfo>();

            CreateMap<DoraMetricsAnalyticsDto, Metrics>();
            CreateMap<Metrics, DoraMetricsAnalyticsDto>();

            // Jira Issue Event DTOs Mapping
            CreateMap<JiraIssueEventDto, JiraIssueEvent>();
            CreateMap<JiraIssueEvent, JiraIssueEventDto>();

            CreateMap<JiraIssueEventDto, JiraIssueEvent>();
            CreateMap<JiraIssueEvent, JiraIssueEventDto>();

            CreateMap<Changelog, ChangelogDto>();
            CreateMap<ChangelogDto, Changelog>();

            CreateMap<Creator, CreatorDto>();
            CreateMap<CreatorDto, Creator>();

            CreateMap<Fields, FieldsDto>();
            CreateMap<FieldsDto, Fields>();

            CreateMap<Issue, IssueDto>();
            CreateMap<IssueDto, Issue>();

            CreateMap<Issuetype, IssuetypeDto>();
            CreateMap<IssuetypeDto, Issuetype>();

            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();

            CreateMap<PriorityDto, Priority>();
            CreateMap<Priority, PriorityDto>();

            CreateMap<ProjectDto, Project>();
            CreateMap<Project, ProjectDto>();

            CreateMap<Reporter, ReporterDto>();
            CreateMap<ReporterDto, Reporter>();

            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

            CreateMap<StatusCategory, StatusCategoryDto>();
            CreateMap<StatusCategoryDto, StatusCategory>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Watches, WatchesDto>();
            CreateMap<WatchesDto, Watches>();

        }
    }
}
