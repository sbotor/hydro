using System.Net;

namespace Hydro.Api.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        private const string _msg = "The specified resource was not found.";

        public NotFoundException() : this(_msg)
        { }

        public NotFoundException(object value) : base(HttpStatusCode.NotFound, value)
        { }
    }
}
