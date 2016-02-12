using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Opgave2.Models
{
    public class FoedevareIndtag
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Maengde { get; set; }

        [Key, Column(Order = 0), ForeignKey("ProteinKilde")]
        public int ProteinKildeId { get; set; }

        public virtual ProteinKilde ProteinKilde { get; set; }
    }
}
