using System.ComponentModel.DataAnnotations;

namespace GWUserSync.Models;

public class UserModel
{
    [Key]
    public int Id { get; set; }

    [MinLength(2), MaxLength(20)]
    public string? FirstName { get; set; }

    [MinLength(2), MaxLength(50)]
    public string? LastName { get; set; }

    [RegularExpression("^[\\w\\.\\-\\@]+([\\!\\w\\-]+\\.)+[\\w]{2,4}$")]
    public string? Email { get; set; }

    [MinLength(9), MaxLength(12)]
    public string? Phone { get; set; }

    [MinLength(1), MaxLength(50)]
    [Required]
    [RegularExpression("^([\\w]+\\-)+([\\w]+)$")]
    public string? GoogleId { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]       
    public DateTime Birthday { get; set; }

    public DateTime HireDate { get; set; }

    [MaxLength(20)]
    public string? Role { get; set; }
}
