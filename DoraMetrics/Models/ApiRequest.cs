using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DoraMetrics.SD;

namespace DoraMetrics.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
