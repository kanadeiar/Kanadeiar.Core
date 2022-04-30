using System.ComponentModel.DataAnnotations;

namespace Kanadeiar.Core.Domain.Base;

/// <summary>
/// Базовая сущность
/// </summary>
abstract public class KndEntity<TId> : IKndEntity<TId>
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
