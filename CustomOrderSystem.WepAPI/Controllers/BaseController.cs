using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomOrderSystem.WepAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected HttpResponseMessage CreateRawStringResponse(HttpStatusCode statusCode, string content)
        {
            var response = Request.CreateResponse(statusCode);

            response.Content = new StringContent(content);

            return response;
        }
    }
}
