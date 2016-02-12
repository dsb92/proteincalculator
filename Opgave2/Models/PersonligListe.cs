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
    public class PersonligListe
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Navn { get; set; }

        [Key, Column(Order = 0), ForeignKey("BrugerData")]
        public int BrugerDataId { get; set; }

        [JsonIgnore]
        public BrugerData BrugerData { get; set; }

        public virtual List<FoedevareIndtag> FoedevareIndtagListe { get; set; }
    }
}
