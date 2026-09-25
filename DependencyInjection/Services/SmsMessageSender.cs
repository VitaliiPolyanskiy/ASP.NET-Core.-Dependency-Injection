namespace DependencyInjection.Services;

public class SmsMessageSender : IMessageSender
{
    public string Send() => "Відправлено через SMS";
}