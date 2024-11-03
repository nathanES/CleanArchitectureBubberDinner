using System.Net;

namespace BubberDinner.Application.Common.Errors;

//1. Flow Control Exception
public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}