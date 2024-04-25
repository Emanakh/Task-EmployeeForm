using EmployeeMVC.Models.DTOs;

namespace EmployeeMVC.Services.IServices
{
	public interface IMainService
	{
		Task<APIResponse> SendRequest(APIRequest apiRequest);
	}
}
