namespace Wpf.Services;

public class MessageService : IMessageService
{
    private string _message { get; set; }
    public MessageService(IOptions<Settings> options, ILogger<MessageService> logger)
    {
        _message = options.Value.Message;
        logger.LogInformation($"Message readed from settings: '{options.Value.Message}'");
    }
    public string GetMessage()
    {
        return _message;
    }
}