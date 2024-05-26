using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_management_backend.Models;

public class RoomTypeModel
{
    [Key]
    public int TypeId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [StringLength(255)]
    public string? Image { get; set; }

    public List<RoomModel>? Rooms { get; set; }
}
