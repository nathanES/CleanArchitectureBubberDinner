using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    //ErrorHandling Number 3. (Link with the Number 4)
    [Route("/error")]
   public IActionResult Error()
   {
       var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
       return Problem();
   } 
}