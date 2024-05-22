using System.Net;

namespace OnlineVideoCourse.Aplication.Common.Exseption;

public class StatusCodeExeption : Exception
{
    public HttpStatusCode StatusCode { get; }

    public StatusCodeExeption(HttpStatusCode code, string message)
        : base(message)
    {
        StatusCode = code;
    }
}