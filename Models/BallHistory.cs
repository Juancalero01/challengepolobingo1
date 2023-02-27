using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bingoapp.Models
{
    public class BallHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int BallNumber { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }
    }
}