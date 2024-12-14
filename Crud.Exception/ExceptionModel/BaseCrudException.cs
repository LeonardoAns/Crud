using System.Net;

namespace Crud.Exception.ExceptionModel
{
    public abstract class BaseCrudException : SystemException
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Errors { get; set; }

        protected BaseCrudException(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
            Errors = new List<string>(); 
        }

        protected BaseCrudException(List<string> errors, HttpStatusCode statusCode)
        {
            Errors = errors ?? new List<string>(); 
            StatusCode = statusCode;
            Message = "Invalid Request"; 
        }
    }
}