using BusinessRuleEngine.Interfaces;

namespace BusinessRuleEngine.Services.Notification
{
    public class EmailService : IEmailService
    {
        public void SendMail(string emailId, string subject, string content)
        {
            // TO DO: Data validation logic to be written to avoid exception.
        }
    }
}
