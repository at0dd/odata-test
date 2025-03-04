using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataTest.API.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; init; }

    public required int Price { get; init; }

    public required int Quantity { get; init; }

    public required long CustomerID { get; init; }

    [ForeignKey(nameof(CustomerID))]
    public Customer? Customer { get; set; }
}