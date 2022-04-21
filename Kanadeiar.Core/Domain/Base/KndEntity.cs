using System.ComponentModel.DataAnnotations;

namespace Kanadeiar.Core.Domain.Base;

/// <summary>
/// Базовая сущность
/// </summary>
abstract public class Entity<TId> : IKndEntity<TId>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public TId Id { get; set; }
}
