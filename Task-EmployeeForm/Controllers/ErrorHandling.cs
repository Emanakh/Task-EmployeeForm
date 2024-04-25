using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Task_EmployeeForm.Models.DTOs;

namespace Task_EmployeeForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandling : ControllerBase
    {
        private readonly APIResponse _apiResponse;
        public ErrorHandling(APIResponse apiResponse)
        {
            _apiResponse = apiResponse;
        }

        [HttpGet("Throw")]
        public IActionResult Throw() =>
   throw new Exception("Sample exception.");



        //Resource I used: https://learn.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-8.0

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]

        public ActionResult<APIResponse> HandleError()
        {
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
            _apiResponse.IsSuccess = false;
            _apiResponse.ErrorMessages = [$" CallStack of the Error:{exceptionHandlerFeature.Error.StackTrace}, Error MessageL {exceptionHandlerFeature.Error.Message} "];

            return _apiResponse;


        }

    }
}
