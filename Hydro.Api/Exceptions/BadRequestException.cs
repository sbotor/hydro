namespace Hydro.Api.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        public BadRequestException(object? value = null) : base(System.Net.HttpStatusCode.BadRequest, value)
        { }
    }
}
