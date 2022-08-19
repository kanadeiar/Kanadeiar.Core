namespace Kanadeiar.Core.Async;

/// <summary>
/// Расширения для написания асинхронного кода
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Отмена операции
    /// </summary>
    public static async Task<TResult> WithCancellation<TResult>(this Task<TResult> original, CancellationToken token)
    {
        var cancel = new TaskCompletionSource();
        using (token.Register(t => ((TaskCompletionSource)t!).TrySetResult(), cancel))
        {
            var any = await Task.WhenAny(original, cancel.Task);
            if (any == cancel.Task)
            {
                token.ThrowIfCancellationRequested();
            }
        }
        return await original;
    }
    /// <summary>
    /// Отмена операции
    /// </summary>
    public static async Task WithCancellation(this Task original, CancellationToken token)
    {
        var cancel = new TaskCompletionSource();
        using (token.Register(t => ((TaskCompletionSource)t!).TrySetResult(), cancel))
        {
            var any = await Task.WhenAny(original, cancel.Task);
            if (any == cancel.Task)
            {
                token.ThrowIfCancellationRequested();
            }
        }
    }
}