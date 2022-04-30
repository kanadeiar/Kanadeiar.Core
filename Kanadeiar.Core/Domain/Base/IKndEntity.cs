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

    /// <summary> 
    /// Маркер версии 
    /// </summary>
    [Timestamp]
    public byte[] RowVersion { get; set; }
}

/// <summary>
/// Базовая сущность библиотек
/// </summary>
public interface IKndEntity
{
}
