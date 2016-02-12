using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Opgave2.Models;

namespace Opgave2.ApiControllers
{
    [Authorize]
    public class ProteinIndtagController : ApiController
    {
        private Context db = new Context();

        // GET api/PersonligListe
        [ResponseType(typeof(List<FoedevareIndtag>))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            BrugerData user = db.BrugerData.FirstOrDefault(s => s.BrugerId == userId);

            PersonligListe myList = db.PersonligLister.FirstOrDefault(s => s.BrugerDataId == user.Id);

            if (myList == null) return NotFound();

            return Ok(myList.FoedevareIndtagListe);
        }

        // DEL api/Bruger
        [ResponseType(typeof(List<FoedevareIndtag>))]
        public async Task<IHttpActionResult> Delete()
        {
            var userId = User.Identity.Name;

            BrugerData user = db.BrugerData.FirstOrDefault(s => s.BrugerId == userId);

            PersonligListe myList = db.PersonligLister.FirstOrDefault(s => s.BrugerDataId == user.Id);

            if (myList != null && user != null)
            {
                myList.FoedevareIndtagListe.Clear();

                db.PersonligLister.AddOrUpdate(myList);

                await db.SaveChangesAsync();
            }

            return Ok(new List<FoedevareIndtag>());
        }

        // POST api/Bruger
        [ResponseType(typeof(List<FoedevareIndtag>))]
        public async Task<IHttpActionResult> Post([FromBody]FoedevareIndtag t)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = User.Identity.Name;

            BrugerData user = db.BrugerData.FirstOrDefault(s => s.BrugerId == userId);
            ProteinKilde proteinKilde = db.ProteinKilder.Find(t.ProteinKildeId);
            PersonligListe myList = db.PersonligLister.FirstOrDefault(s => s.BrugerDataId == user.Id);
            
            // Create a list for the user if the user not already has one
            if (myList == null)
            {
                myList = new PersonligListe
                {
                    BrugerDataId = user.Id,
                    Navn = userId + " personlige proteinliste",
                    BrugerData = user,
                    FoedevareIndtagListe = new List<FoedevareIndtag>()
                };

                t.ProteinKilde = proteinKilde;
                myList.FoedevareIndtagListe.Add(t);

                this.db.PersonligLister.Add(myList);
                await this.db.SaveChangesAsync();

                return Ok(myList.FoedevareIndtagListe);
            }

            if (myList.FoedevareIndtagListe == null) myList.FoedevareIndtagListe = new List<FoedevareIndtag>();

            t.ProteinKilde = proteinKilde;

            myList.FoedevareIndtagListe.Add(t);

            db.PersonligLister.AddOrUpdate(myList);
            await db.SaveChangesAsync();
            
            return Ok(myList.FoedevareIndtagListe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
