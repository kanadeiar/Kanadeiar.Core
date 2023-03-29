using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Kanadeiar.Core.Exceptions;

/// <summary>
/// Обобщенный класс исключения
/// </summary>
[Serializable]
[Obsolete]
public class Exception<TExceptionArgs> : Exception, ISerializable where TExceptionArgs : ExceptionArgs
{
    private const string __args = "ExceptionArgs";
    private readonly TExceptionArgs _args;
    /// <summary>
    /// Данные исключения
    /// </summary>
    public TExceptionArgs Args => Args1;

    public Exception(string? message = null, Exception? innerException = null)
    : this(null!, message, innerException)
    { }
    public Exception(TExceptionArgs args, string? message = null, Exception? innerException = null)
    {
        _args = args;
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    private Exception(SerializationInfo info, StreamingContext content) : base(info, content)
    {
        _args = (TExceptionArgs)info.GetValue(__args, typeof(TExceptionArgs))!;
    }
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    public override string Message
    {
        get
        {
            var s = base.Message;
            return (Args1 == null) ? s : s + " (" + Args1.Message + ")";
        }
    }

    public TExceptionArgs Args1 => _args;

    public override bool Equals(object? obj)
    {
        var other = obj as Exception<TExceptionArgs>;
        if (other is null)
            return false;
        return object.Equals(Args1, other.Args1) && base.Equals(obj);
    }
    public override int GetHashCode() => base.GetHashCode();
}
