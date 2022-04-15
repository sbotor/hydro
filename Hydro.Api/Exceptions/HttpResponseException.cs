using System.Net;

namespace Hydro.Api.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);

        public HttpResponseException(HttpStatusCode statusCode, object? value = null) : this((int)statusCode, value)
        { }

        public int StatusCode { get; }

        public object? Value { get; }
    }
}
