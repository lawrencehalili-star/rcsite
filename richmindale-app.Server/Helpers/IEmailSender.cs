namespace richmindale_app.Server.Helpers
{
    public interface IEmailSender
    {
        void SendMail(string sendTo, string subject, string body);
        void SendBulkMail(string[] sendTo, string subject, string body);
    }
}