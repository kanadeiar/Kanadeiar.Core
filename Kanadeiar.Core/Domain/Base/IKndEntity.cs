using System.ComponentModel.DataAnnotations;

namespace Kanadeiar.Core.Domain.Base;

/// <summary>
/// Базовая сущность библиотек
/// </summary>
public interface IKndEntity<TId> : IKndEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public TId Id { get; set; }
}

/// <summary>
/// Базовая сущность библиотек
/// </summary>
public interface IKndEntity
{
}
