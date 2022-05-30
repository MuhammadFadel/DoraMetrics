using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Enums
    {
        public enum ProjectType
        {
            Group,
            Project,
        }

        public enum MetricType
        {
            DeploymentFrequency,
            LeadTimeForChanges,
            TimeToRestoreService,
            ChangeFailureRate
        }
    }
}
