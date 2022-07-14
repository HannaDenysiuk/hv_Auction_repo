using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }

        [ForeignKey("LotId")]
        public IEnumerable<Lot> Lots { get; set; }

        [ForeignKey("StepId")]
        public IEnumerable<Step> Steps { get; set; }
    }
}
