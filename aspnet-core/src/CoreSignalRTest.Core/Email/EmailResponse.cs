using Abp.AppFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CoreSignalRTest.Email
{
    public class EmailResponse : ISendGridResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpContent Body { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public Dictionary<string, dynamic> DeserializedResponseBody { get; set; }
        public Dictionary<string, string> DeserializedResponseHeaders { get; set; }
    }
}
