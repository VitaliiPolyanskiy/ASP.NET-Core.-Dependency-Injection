namespace DependencyInjection.Services;

public class EmailMessageSender : IMessageSender
{
    public string Send() => "Відправлено через Email";
}