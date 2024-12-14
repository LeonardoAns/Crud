using System.Net;

namespace Crud.Exception.ExceptionModel;

public class InvalidRequestException : BaseCrudException {

    public InvalidRequestException(List<string> errors) : base(errors, HttpStatusCode.BadRequest){
    }
}