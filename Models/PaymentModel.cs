using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_management_backend.Models;
public class PaymentModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentId { get; set; }

    [Range(0, 100)]
    public int Discount { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; }

    public int ReservationId { get; set; }

    public virtual ReservationModel Reservation { get; set; }
}