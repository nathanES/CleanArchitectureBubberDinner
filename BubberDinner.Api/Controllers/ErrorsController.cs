using BubberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    //ErrorHandling Number 3. (Can be used with the Number 4)
    [Route("/error")]
   public IActionResult Error()
   {
       var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
       var (statusCode, message) = exception switch
       {
           IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
           _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
       };
       return Problem(statusCode : statusCode, title: message);
   } 
}