﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class MetricData
    {
        [Key]
        public int Id { get; set; }
        public int? DeploymentFrequencyId { get; set; }               
        public int? LeadTimeForChangesId { get; set; }        
        public int? TimeToRestoreServiceId { get; set; }        
        public int? ChangeFailureRateId { get; set; }        
        public string Date { get; set; }
        public double? Value { get; set; }
    }
}
