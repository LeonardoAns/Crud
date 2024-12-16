using System.Net;

namespace Crud.Exception.ExceptionModel;

public class NotFoundException : BaseCrudException{
    
    public NotFoundException(string message) : base(message, HttpStatusCode.NotFound){
    }
}