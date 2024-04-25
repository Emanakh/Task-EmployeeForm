using EmployeeMVC.Models.DTOs;
using EmployeeMVC.Services.IServices;
using static EmployeeMVC.Enums.Enums;

namespace EmployeeMVC.Services
{
    public class EmployeeService : MainService ,IEmployeeService
    {
        private readonly string _url;

        //base service constructor require IHttpClientFactory
        public EmployeeService(IHttpClientFactory clientFactory, IConfiguration configuration, APIResponse response) : base(clientFactory, response )
        {
            _url = configuration.GetValue<string>("ServiceUrls:EmployeeAPI");
        }

		public async Task<APIResponse> GetAllAsync()
		{
			return await SendRequest(new APIRequest()
			{
				apiType = ApiType.GET,
				Url = _url + "/api/Employee"
			});
		}

		public async Task<APIResponse> GetAsync(int id)
		{
			return await SendRequest(new APIRequest()
			{
				apiType = ApiType.GET,
				Url = _url + "/api/Employee/"+id
			});;
		}


		public async Task<APIResponse> RemoveAsync(int id)
		{
			return await SendRequest(new APIRequest()
			{
				apiType = ApiType.DELETE,
				Url = _url + "/api/Employee/" + id
			}); ;
		}


		public async Task<APIResponse> UpdateAsync(EmployeeUpdateDTO dto)
        {
            return await SendRequest(new APIRequest()
            {
                apiType = ApiType.PUT,
                Data = dto,
                Url = _url + "/api/Employee/" + dto.Id
            });
        }

        public async Task<APIResponse> CreateAsync(EmployeeCreateDTO dto)
        {
            
            return await SendRequest(new APIRequest()
            {
                apiType = ApiType.POST,
                Data = dto,
                Url = _url + "/api/Employee"
            });
        }
    }
}
