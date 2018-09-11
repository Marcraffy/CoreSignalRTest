using Abp.AppFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSignalRTest.Email
{
    public class Email : ISendGridEmail
    {
        public string SenderEmailAddress { get; set; }
        public string SenderName { get; set; }
        public string SubjectContent { get; set; }
        public string BodyTextContent { get; set; }
        public string BodyHtmlContent { get; set; }
        public string RecepientEmailAddress { get; set; }
        public string RecepientName { get; set; }
    }
}
