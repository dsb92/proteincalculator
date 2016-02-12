using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<BrugerData> BrugerData { get; set; }

        public DbSet<PersonligListe> PersonligLister { get; set; }

        public DbSet<FoedevareIndtag> FoedevareIndtag { get; set; }
        public DbSet<ProteinKilde> ProteinKilder { get; set; }
    }
}
