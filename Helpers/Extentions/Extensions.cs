using Helpers.Paginations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace Helpers.Extentions
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination",
                JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static void MappingUpdates<TSource, TDestination>(this TSource source, TDestination destination, bool updateNestedObjects = true, int nestedLevel = 1)
        {
            foreach (PropertyInfo p in source.GetType().GetProperties())
            {
                if (!p.Name.Contains("Id"))
                {
                    try
                    {
                        // to skip any lists and just assign default types
                        if ((p.PropertyType.FullName.Contains("System") && !p.PropertyType.FullName.Contains("Collections"))
                            || (p.PropertyType.FullName.Contains("Collections") && !IsEmptyObject(source)))
                            p.SetValue(source, p.GetValue(destination));
                        // to assign objects to null objects without go throuhg
                        else if (p.GetValue(source) == null && p.GetValue(destination) != null)
                            p.SetValue(source, p.GetValue(destination));
                        // to update nested objects of source
                        else if (p.GetValue(source) != null && p.GetValue(destination) != null && updateNestedObjects && nestedLevel >= 0)
                            p.GetValue(source).MappingUpdates(p.GetValue(destination), false, --nestedLevel);
                    }
                    catch
                    {
                        break;
                    }

                }

            }
        }

        public static bool IsEmptyObject<T>(T obj)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
                if (property.GetValue(obj, null) != null)
                    return false;
            return true;

        }
    }
}
