using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_management_backend.Models;

public class ReservationModel
{
    [Key]
    public int ReservationId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    public double TotalPrice { get; set; }

    [Required]
    public string StartDate { get; set; }

    [Required]
    public string EndDate { get; set; }

    [Required]
    public ReservationStatus Status { get; set; }
}

public enum ReservationStatus
{
    Reserved,
    Expired,
    Cancelled
}
