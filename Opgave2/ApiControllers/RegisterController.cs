using System;
using System.Collections.Generic;
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
    public class RegisterController : ApiController
    {
        private Context db = new Context();

        // GET api/Proteinkilde
        [ResponseType(typeof(List<ProteinKilde>))]
        public async Task<IHttpActionResult> Get()
        {
            List<ProteinKilde> proteinkilder = new List<ProteinKilde>(db.ProteinKilder);

            return this.Ok(proteinkilder);
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
