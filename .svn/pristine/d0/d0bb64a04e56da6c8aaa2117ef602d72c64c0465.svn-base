using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraMetrics.DTOs
{
    public class GitlabProjectDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public string default_branch { get; set; }
        public string visibility { get; set; }
        public string ssh_url_to_repo { get; set; }
        public string http_url_to_repo { get; set; }
        public string web_url { get; set; }
        public string readme_url { get; set; }
        public List<string> tag_list { get; set; }
        public List<string> topics { get; set; }
        public OwnerDto owner { get; set; }
        public DoraMetricsAnalyticsDto DoraMetricsAnalytics { get; set; }
        public string name { get; set; }
        public string name_with_namespace { get; set; }
        public string path { get; set; }
        public string path_with_namespace { get; set; }
        public bool? issues_enabled { get; set; }
        public int open_issues_count { get; set; }
        public bool? merge_requests_enabled { get; set; }
        public bool? jobs_enabled { get; set; }
        public bool? wiki_enabled { get; set; }
        public bool? snippets_enabled { get; set; }
        public bool? can_create_merge_request_in { get; set; }
        public bool? resolve_outdated_diff_discussions { get; set; }
        public bool? container_registry_enabled { get; set; }
        public string container_registry_access_level { get; set; }
        public string security_and_compliance_access_level { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_activity_at { get; set; }
        public int creator_id { get; set; }
        public string import_url { get; set; }
        public string import_type { get; set; }
        public NamespaceDto @namespace { get; set; }
        public string import_status { get; set; }
        public bool? archived { get; set; }
        public string avatar_url { get; set; }
        public bool? shared_runners_enabled { get; set; }
        public int forks_count { get; set; }
        public int star_count { get; set; }
        public string runners_token { get; set; }
        public int ci_default_git_depth { get; set; }
        public bool? ci_forward_deployment_enabled { get; set; }
        public bool? public_jobs { get; set; }
        public List<object> shared_with_groups { get; set; }
        public bool? only_allow_merge_if_pipeline_succeeds { get; set; }
        public bool? allow_merge_on_skipped_pipeline { get; set; }
        public bool? restrict_user_defined_variables { get; set; }
        public bool? only_allow_merge_if_all_discussions_are_resolved { get; set; }
        public bool? remove_source_branch_after_merge { get; set; }
        public bool? request_access_enabled { get; set; }
        public string merge_method { get; set; }
        public string squash_option { get; set; }
        public bool? autoclose_referenced_issues { get; set; }
        public object suggestion_commit_message { get; set; }
        public object merge_commit_template { get; set; }
        public object squash_commit_template { get; set; }
        public string marked_for_deletion_at { get; set; }
        public string marked_for_deletion_on { get; set; }
        public StatisticsDto statistics { get; set; }
        public string container_registry_image_prefix { get; set; }
        public LinksDto _links { get; set; }
        public object import_error { get; set; }
        public PermissionsDto permissions { get; set; }
        public bool? auto_devops_enabled { get; set; }
        public string auto_devops_deploy_strategy { get; set; }
        public string repository_storage { get; set; }
        public int? approvals_before_merge { get; set; }
        public bool? mirror { get; set; }
        public int? mirror_user_id { get; set; }
        public bool? mirror_trigger_builds { get; set; }
        public bool? only_mirror_protected_branches { get; set; }
        public bool? mirror_overwrites_diverged_branches { get; set; }
        public object external_authorization_classification_label { get; set; }
        public bool? packages_enabled { get; set; }
        public bool? service_desk_enabled { get; set; }
        public object service_desk_address { get; set; }
    }

    public class OwnerDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string state { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
        public DateTime created_at { get; set; }
    }

    public class NamespaceDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string kind { get; set; }
        public string full_path { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
    }

    public class StatisticsDto
    {
        public int commit_count { get; set; }
        public int storage_size { get; set; }
        public int repository_size { get; set; }
        public int wiki_size { get; set; }
        public int lfs_objects_size { get; set; }
        public int job_artifacts_size { get; set; }
        public int pipeline_artifacts_size { get; set; }
        public int packages_size { get; set; }
        public int snippets_size { get; set; }
        public int uploads_size { get; set; }
    }

    public class LinksDto
    {
        public string self { get; set; }
        public string issues { get; set; }
        public string merge_requests { get; set; }
        public string repo_branches { get; set; }
        public string labels { get; set; }
        public string events { get; set; }
        public string members { get; set; }
        public string cluster_agents { get; set; }
    }

    public class ProjectAccessDto
    {
        public int? access_level { get; set; }
        public int? notification_level { get; set; }
    }

    public class GroupAccessDto
    {
        public int access_level { get; set; }
        public int notification_level { get; set; }
    }

    public class PermissionsDto
    {
        public ProjectAccessDto project_access { get; set; }
        public GroupAccessDto group_access { get; set; }       
    }

    public class DoraMetricsAnalyticsDto
    {
        public List<MetricValueDto> DeploymentFrequency { get; set; }
        public List<MetricValueDto> LeadTimeForChanges { get; set; }
        public List<MetricValueDto> TimeToRestoreService { get; set; }
        public List<MetricValueDto> ChangeFailureRate { get; set; }
    }

    public class MetricValueDto
    {
        public string date { get; set; }
        public double? value { get; set; }
    }
}
