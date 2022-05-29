using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Metrics
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        [ForeignKey("DeploymentFrequencyId")]
        public List<MetricData> DeploymentFrequency { get; set; }
        [ForeignKey("LeadTimeForChangesId")]
        public List<MetricData> LeadTimeForChanges { get; set; }
        [ForeignKey("TimeToRestoreServiceId")]
        public List<MetricData> TimeToRestoreService { get; set; }
        [ForeignKey("ChangeFailureRateId")]
        public List<MetricData> ChangeFailureRate { get; set; }
    }
}
