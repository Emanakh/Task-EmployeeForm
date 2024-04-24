using Microsoft.AspNetCore.Mvc;
using System.Net;
using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Services.IServices;

namespace Task_EmployeeForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly APIResponse _apiResponse;
        private readonly IEmployeeService _employeeService;

        public EmployeeController( APIResponse apiresponse, IEmployeeService employeeService)
        {
         
            _apiResponse = apiresponse;
            _employeeService = employeeService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> AddEmployee([FromBody]EmployeeDTO dto)
        {
            try {

                //check if the dto is null
                if (dto == null)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { "the New Emplyee Data is Empty" };
                    return BadRequest();
                }

                //check input validations
                if (!ModelState.IsValid )
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = errors;
                    _apiResponse.StatusCode = HttpStatusCode.BadGateway;
                    return BadRequest(_apiResponse); 
                }

              
                var employee = await _employeeService.Add(dto);

                _apiResponse.Result = employee;
                _apiResponse.StatusCode = HttpStatusCode.Created;
                _apiResponse.IsSuccess = true;
                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.Message };
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;

            }
            return _apiResponse;

        }
    }
}
