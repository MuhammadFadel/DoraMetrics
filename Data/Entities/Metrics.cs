using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Data.Enums;

namespace Data.Entities
{
    public class Metrics
    {
        [Key]
        public int Id { get; set; }        
        public ProjectType ProjectType { get; set; }
        public MetricType MetricType { get; set; }
        public string Date { get; set; }
        public double? Value { get; set; }
    }
}
