using System;
using System.Net;

namespace UtttApi.ObjectModel.Exceptions
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; }

        public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = (int)statusCode;
        }
    }
}