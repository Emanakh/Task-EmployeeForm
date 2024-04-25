using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;
using Task_EmployeeForm.Models;
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


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<APIResponse>> GetAllEmployees()
		{
			try
			{

				IEnumerable<Employee> Employees = await _employeeService.GetAllAsync();
				_apiResponse.Result = Employees;
				_apiResponse.IsSuccess = true;
				_apiResponse.StatusCode =HttpStatusCode.OK;
				return Ok(_apiResponse);
			}
			catch (Exception ex)
			{
				_apiResponse.IsSuccess = false;
				_apiResponse.ErrorMessages = new List<string> { ex.Message };

			}
			return _apiResponse;

		}


		[HttpGet("{id:int}", Name = "GetEmployee")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> GetEmployee(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest();
				}
				var Employee = await _employeeService.GetAsync(id);
				if (Employee == null)
				{
						_apiResponse.StatusCode = HttpStatusCode.NotFound;
					_apiResponse.IsSuccess = false;
					return _apiResponse;
				}
				_apiResponse.Result = Employee;
				_apiResponse.StatusCode = HttpStatusCode.OK;
				_apiResponse.IsSuccess = true;
				return Ok(_apiResponse);
			}
			catch (Exception ex)
			{
				_apiResponse.IsSuccess = false;
				_apiResponse.ErrorMessages = new List<string> { ex.Message };

			}
			return _apiResponse;

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
                    _apiResponse.ErrorMessages = new List<string> { "the New Employee Data is Empty" };
                    return BadRequest();
                }

                //check input validations
                if (!ModelState.IsValid )
                {
                    //extract validation errors to put in the response
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


		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> UpdateEmployee(int id, [FromBody] EmployeeUpdateDTO dto)
		{
			try
			{
				
                //check if the dto is null
                if (dto == null || dto.Id != id)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { "the New Employee Data is Empty" };
                    return BadRequest();
                }

                //check input validations
                if (!ModelState.IsValid)
                {
                    //extract validation errors to put in the response
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = errors;
                    _apiResponse.StatusCode = HttpStatusCode.BadGateway;
                    return BadRequest(_apiResponse);
                }

                var employee = await _employeeService.GetAsync(id); 
				if (employee == null)
				{
					return NotFound();
				}

				await _employeeService.UpdateAsync(dto);

				_apiResponse.StatusCode = HttpStatusCode.NoContent;
				_apiResponse.IsSuccess = true;

				return Ok(_apiResponse);
			}
			catch (Exception ex)
			{
				_apiResponse.IsSuccess = false;
				_apiResponse.ErrorMessages = new List<string> { ex.Message };

			}
			return _apiResponse;

		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> DeleteEmployee(int id) 
		{
			try
			{
				if (id == 0)
				{
					return BadRequest();
				}
				var employee = await _employeeService.GetAsync(id);

				if (employee == null)
				{
					return NotFound();
				}
				await _employeeService.RemoveAsync(employee);
				_apiResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
				_apiResponse.IsSuccess = true;

				return Ok(_apiResponse);
			}
			catch (Exception ex)
			{
				_apiResponse.IsSuccess = false;
				_apiResponse.ErrorMessages = new List<string> { ex.Message };

			}
			return _apiResponse;

		}





	}



}
