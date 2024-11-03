using System.Net;

namespace BubberDinner.Application.Common.Errors;

//1. Flow Control Exception
public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exists";
}