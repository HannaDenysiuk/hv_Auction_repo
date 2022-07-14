using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Step
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int LotId { get; set; }

        [ForeignKey("LotId")]
        public Lot Lot { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Client User { get; set; }
        public double Amount { get; set; }
    }
}
