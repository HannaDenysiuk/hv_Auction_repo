using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Lot
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string LotName { get; set; }
        public string Description { get; set; }
        public double StartPrice { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Client User { get; set; }

        [ForeignKey("StepId")]
        public IEnumerable<Step> Steps { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishtDate { get; set; }
    }
}
