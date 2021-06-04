using System;
using System.Net;

namespace NixUtil.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public object Value { get; set; }

        public HttpResponseException(HttpStatusCode code, string message) : base($"Erro {(int)code}: - {message}")
        {
            StatusCode = code;
            Value = this;
        }
    }
}
