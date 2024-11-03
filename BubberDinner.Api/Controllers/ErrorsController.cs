using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

public class ErrorsController : ApiController
{
    //ErrorHandling Number 3. (Can be used with the Number 4)
    [Route("/error")]
   public IActionResult Error()
   {
       var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
       return Problem();
   } 
}