namespace Wpf.Commands;

public class RelayCommand<T> : RelayCommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool>? _canExecute;
    public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }
    protected override bool CanExecute(object? p) => _canExecute?.Invoke((T)p!) ?? true;
    protected override void Execute(object? p) => _execute.Invoke((T)p!);
}

public class RelayCommand : Base.CommandBase
{
    private readonly Action<object> _Execute;
    private readonly Func<object, bool>? _CanExecute;
    protected RelayCommand() { _Execute = default!; }
    public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _CanExecute = canExecute;
    }
    protected override bool CanExecute(object? p) => _CanExecute?.Invoke(p!) ?? true;
    protected override void Execute(object? p) => _Execute.Invoke(p!);
}

