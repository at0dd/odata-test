using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataTest.API.Models;

public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; init; }

    [MaxLength(20)]
    public required string Street { get; init; }

    [MaxLength(20)]
    public required string City { get; init; }

    [MaxLength(20)]
    public required string State { get; init; }

    [MaxLength(6)]
    public required string PostalCode { get; init; }

    public required DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; init; }
}