using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Opgave2.Models
{
    public class ProteinKilde
    {
        public int Id { get; set; }

        [Required]
        public string Navn { get; set; }

        [Required]
        public double Protein { get; set; }
    }
}