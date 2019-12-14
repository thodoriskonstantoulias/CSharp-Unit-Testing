namespace TestNinja.Mocking
{
    public interface IEmailSender
    {
        void EmailFile(object emailAddress, object emailBody, string statementFileName, string v);
    }
}