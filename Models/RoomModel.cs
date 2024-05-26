using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_management_backend.Models;

public class RoomModel
{
    [Key]
    public int RoomId { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [StringLength(255)]
    public string? Image { get; set; }

    [ForeignKey("RoomTypeModel")]
    public int RoomTypeId { get; set; }

    [Required]
    public RoomStatus Status { get; set; }

    public RoomTypeModel? RoomType { get; set; }
}

public enum RoomStatus
{
    Available,
    Unavailable
}
