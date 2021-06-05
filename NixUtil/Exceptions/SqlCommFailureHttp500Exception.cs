using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NixUtil.Exceptions
{
    public class SqlCommFailureHttp500Exception : HttpResponseException
    {
        public SqlCommFailureHttp500Exception() : base(HttpStatusCode.InternalServerError, "Falha de comunicação com o banco de dados.")
        {
        }
    }
}
