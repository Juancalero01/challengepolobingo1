using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bingoapp.Models
{
    public class CardboardHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int? CardboardOne { get; set; }

        public int? CardboardTwo { get; set; }

        public int? CardboardThree { get; set; }

        public int? CardboardFour { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }
    }
}