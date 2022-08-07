namespace Kanadeiar.Core.Base;

/// <summary>
/// Базовая сущность библиотеки
/// </summary>
/// <typeparam name="TKey">Тип ключа</typeparam>
public interface IKndEntity<TKey> : IKndEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    TKey Id { get; set; }
}

/// <summary>
/// Совсем базовая сущность библиотеки
/// </summary>
public interface IKndEntity { }

