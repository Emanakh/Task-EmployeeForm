using System.Security.AccessControl;
using static EmployeeMVC.Enums.Enums;

namespace EmployeeMVC.Models.DTOs
{
    public class APIRequest
    {
        public ApiType apiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
