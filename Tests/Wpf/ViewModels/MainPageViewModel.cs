namespace Wpf.ViewModels;

public class MainPageViewModel : Base.ViewModelBase
{
    private IMessageService _messageService;

    private string _text = default!;
    /// <summary>
    /// Текст
    /// </summary>
    public string Text
    {
        get => _text;
        set => Set(ref _text, value);
    }

    public MainPageViewModel(IMessageService messageService)
    {
        _messageService = messageService;

        Update();
    }

    private void Update()
    {
        Text = _messageService.GetMessage();
    }
}