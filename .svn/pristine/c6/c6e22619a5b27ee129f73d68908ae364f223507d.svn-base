using DoraMetrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraMetrics.Services
{
    public interface IBaseService : IDisposable
    {
        ApiResponse _apiResponse { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
