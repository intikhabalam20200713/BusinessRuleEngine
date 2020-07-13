namespace BusinessRuleEngine.Interfaces
{
    public interface IEmailService
    {
        void SendMail(string emailId, string subject, string content);
    }
}
