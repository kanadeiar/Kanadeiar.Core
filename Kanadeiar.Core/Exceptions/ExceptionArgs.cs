namespace Kanadeiar.Core.Exceptions;

/// <summary>
/// Класс данных исключения
/// </summary>
[Serializable]
public class ExceptionArgs
{
    public virtual string Message => string.Empty;
}
