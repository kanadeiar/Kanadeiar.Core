using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanadeiar.Core.Domain.Base;

/// <summary>
/// Базовая сущность библиотеки
/// </summary>
/// <typeparam name="TKey">Тип ключа</typeparam>
abstract public class KndEntity<TKey> : IKndEntity<TKey>, IEquatable<KndEntity<TKey>> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }

    /// <summary> 
    /// Датовременной штамп 
    /// </summary>
    [Timestamp]
    public byte[]? Timestamp { get; set; }

    protected KndEntity() { }

    protected KndEntity(TKey Id) => this.Id = Id;

    public bool Equals(KndEntity<TKey>? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (!other.GetType().IsAssignableTo(GetType())) return false;
        if (EqualityComparer<TKey>.Default.Equals(Id, default))
            return ReferenceEquals(this, other);
        return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((KndEntity<TKey>)obj);
    }

    public override int GetHashCode() =>
    EqualityComparer<TKey>.Default.Equals(Id, default)
        ? base.GetHashCode()
        : EqualityComparer<TKey>.Default.GetHashCode(Id);

    /// <summary>
    /// Оператор проверки на равенство двух сущностей
    /// </summary>
    /// <param name="left">Левый операнд</param>
    /// <param name="right">Правый операнд</param>
    /// <returns>Истина, если значения левого и правого операнда равны</returns>
    public static bool operator ==(KndEntity<TKey> left, KndEntity<TKey> right) => Equals(left, right);

    /// <summary>
    /// Оператор проверки на неравенство двух сущностей
    /// </summary>
    /// <param name="left">Левый операнд</param>
    /// <param name="right">Правый операнд</param>
    /// <returns>Истина, если значение левого операнда не равно значению правого операнда</returns>
    public static bool operator !=(KndEntity<TKey> left, KndEntity<TKey> right) => !Equals(left, right);
}

/// <summary>
/// Базовая сущность библиотеки с целочисленным ключем
/// </summary>
public abstract class KndEntity : KndEntity<int>, IKndEntity
{
    protected KndEntity() { }

    protected KndEntity(int Id) : base(Id) { }
}