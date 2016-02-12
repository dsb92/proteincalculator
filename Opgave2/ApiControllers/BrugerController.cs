using System;
using System.Collections.Generic;
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
    public class BrugerController : ApiController
    {
        private Context db = new Context();

        // GET api/Bruger
        [ResponseType(typeof(BrugerData))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            BrugerData user = db.BrugerData.FirstOrDefault(s => s.BrugerId == userId);

            // Create the user if not yet created
            if (user == null)
            {
                user = new BrugerData
                {
                    BrugerId = userId,
                    HasProfile = false,
                    Tilstand = "Voksen"
                };

                this.db.BrugerData.AddOrUpdate(user);

                await this.db.SaveChangesAsync();
            }

            return Ok(user);
        }

        // POST api/Bruger
        [ResponseType(typeof(BrugerData))]
        public async Task<IHttpActionResult> Post([FromBody]BrugerData user)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            BrugerData existingUser = db.BrugerData.FirstOrDefault(s => s.BrugerId == user.BrugerId);
            if (existingUser != null)
            {
                existingUser.Vaegt = user.Vaegt;
                existingUser.Tilstand = user.Tilstand;

                this.db.BrugerData.AddOrUpdate(existingUser);
            }

            await this.db.SaveChangesAsync();

            return Ok(user);
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
