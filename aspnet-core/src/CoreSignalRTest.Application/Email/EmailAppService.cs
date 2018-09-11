using Abp.AppFactory.Interfaces;
using System.Threading.Tasks;

namespace CoreSignalRTest.Email
{
    public class EmailAppService : CoreSignalRTestAppServiceBase
    {
        private readonly ISendGrid sendGrid;

        public EmailAppService(ISendGrid sendGrid)
        {
            this.sendGrid = sendGrid;
        }

        public async Task SendEmail()
        {
            var response = await sendGrid.SendAsync(new Email()
            {
                SenderName = "Marc",
                SenderEmailAddress = "Marcraffy@gmail.com",
                SubjectContent = "Hello World",
                BodyTextContent = "Hello World",
                RecepientName = "Marc",
                RecepientEmailAddress = "Marcraffy@gmail.com"
            });
        }
    }
}