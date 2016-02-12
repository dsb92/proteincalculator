using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2.Models
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);

            var proteinKilder = new List<ProteinKilde>();

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Oksekød",
                Protein = 20.0
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Svinekød",
                Protein = 20.0
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Kylling",
                Protein = 20.0
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Æg",
                Protein = 12.6
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Mini mælk",
                Protein = 3.5
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Havregryn",
                Protein = 13.3
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Rugbrød",
                Protein = 6.2
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Grønne bønner",
                Protein = 2.0
            });

            proteinKilder.Add(new ProteinKilde
            {
                Navn = "Kartoffel",
                Protein = 1.9
            });

            proteinKilder.ForEach(a => context.ProteinKilder.Add(a));

            context.SaveChanges();
        }
    }
}
