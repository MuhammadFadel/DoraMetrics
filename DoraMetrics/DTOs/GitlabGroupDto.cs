﻿using System;
using System.Collections.Generic;

namespace DoraMetrics.DTOs
{
    public class GitlabGroupDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string description { get; set; }
        public string visibility { get; set; }
        public List<GitlabProjectDto> projects { get; set; }
        public DoraMetricsAnalyticsDto DoraMetricsAnalytics { get; set; }
        public bool share_with_group_lock { get; set; }
        public bool require_two_factor_authentication { get; set; }
        public int two_factor_grace_period { get; set; }
        public string project_creation_level { get; set; }        
        public string subgroup_creation_level { get; set; }        
        public bool lfs_enabled { get; set; }
        public int default_branch_protection { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
        public bool request_access_enabled { get; set; }
        public string full_name { get; set; }
        public string full_path { get; set; }
        public int file_template_project_id { get; set; }
        public object parent_id { get; set; }
        public DateTime created_at { get; set; }
    }
}
