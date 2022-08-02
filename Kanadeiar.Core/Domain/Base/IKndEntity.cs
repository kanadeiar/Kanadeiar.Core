namespace Kanadeiar.Core.Domain.Base;

/// <summary>
/// Базовая сущность библиотеки
/// </summary>
/// <typeparam name="TKey">Тип ключа</typeparam>
public interface IKndEntity<TKey>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    TKey Id { get; set; }
}

/// <summary>
/// Базовая сущность библиотеки с целочисленным ключем
/// </summary>
public interface IKndEntity : IKndEntity<int> { }

