namespace Wpf.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    private string _title = "Тестовое приложение";
    /// <summary> 
    /// Заголовок 
    /// </summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    private int _value = 200;
    /// <summary>
    /// Значение
    /// </summary>
    public int Value
    {
        get => _value;
        set => Set(ref _value, value);
    }

    public MainWindowViewModel()
    {

    }

    private ICommand? _CloseAppCommand;
    /// <summary> 
    /// Закрыть приложение 
    /// </summary>
    public ICommand CloseAppCommand => _CloseAppCommand ??=
        new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
    private bool CanCloseAppCommandExecute(object p) => true;
    private void OnCloseAppCommandExecuted(object p)
    {
        Application.Current.Shutdown();
    }
}