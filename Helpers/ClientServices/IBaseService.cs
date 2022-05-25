using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.ClientServices
{
    internal interface IBaseService
    {
        ApiResponse _apiResponse { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
