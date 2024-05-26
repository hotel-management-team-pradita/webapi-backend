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
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public ReservationStatus Status { get; set; }

    public virtual RoomModel Room { get; set; }

    public virtual PaymentModel Payment { get; set; }
}

public enum ReservationStatus
{
    Reserved,
    Expired,
    Cancelled
}
