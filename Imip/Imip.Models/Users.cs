using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imip.Models
{
    [Table("user")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool IsAdmin { get; set; } = false;
        [Required]
        public string SystemUserId { get; set; }

    }
}
