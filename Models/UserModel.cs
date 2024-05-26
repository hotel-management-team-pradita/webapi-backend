using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_management_backend.Models;

public class UserModel
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(255)]
    public string Fullname { get; set;}

    [Required]
    public GenderOptions Gender { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set;}

    [Required]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(255)]
    public string Address { get; set; }
}

public enum GenderOptions {
    Male,
    Female
}