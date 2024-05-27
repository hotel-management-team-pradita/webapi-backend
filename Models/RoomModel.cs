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

    [StringLength(100)]
    public string? Location { get; set; }


    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [StringLength(255)]
    public string? Image { get; set; }

    [Required]
    public RoomStatus Status { get; set; }

    public int RoomTypeId { get; set; }

    public virtual RoomTypeModel? RoomType { get; set; }
}
public enum RoomStatus
{
    Available,
    Unavailable
}