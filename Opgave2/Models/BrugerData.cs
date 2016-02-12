using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Opgave2.Models
{
    public class BrugerData
    {
        public int Id { get; set; }

        public string BrugerId { get; set; }

        [Required]
        public double Vaegt { get; set; }

        [Required]
        public string Tilstand { get; set; } // Voksen, syge/svækkende, hård træning

        public bool HasProfile { get; set; }
    }
}
