namespace Kanadeiar.Core.Events;

/// <summary>
/// Расширения для поддержки работы с событиями
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Потокобезопасный вызов уведомлений о произошедшем событии
    /// </summary>
    public static void Raise<TEArgs>(this TEArgs e, object sender, ref EventHandler<TEArgs> eventDelegate)
    {
        if (Volatile.Read(ref eventDelegate) is { } temp)
        {
            temp.Invoke(sender, e);
        }
    }
}
