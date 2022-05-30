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
        }
    }
}
