namespace Backend.Services.Mailsender
{
    public interface IMailSenderServices
    {
        public void SendMail(string para, string usuario, string cupon);
    }
}