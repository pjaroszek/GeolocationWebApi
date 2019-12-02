using GeolocationWebApi.Models;
using Jaroszek.ProofOfConcept.GeolocationWebApi.Interfaces;
using Jaroszek.ProofOfConcept.GeolocationWebApi.Services;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace Jaroszek.ProofOfConcept.GeolocationWebApi.Controllers
{
    public class GeoLocalizationsController : ApiController
    {
        private GeoLocalizationContexr db = new GeoLocalizationContexr();
        private IIpInfoServices infoServices;

        // GET: api/GeoLocalizations
        public IQueryable<GeoLocalization> GetGeoLocalizations()
        {
            return db.GeoLocalizations;
        }

        // GET: api/GeoLocalizations/5
        [ResponseType(typeof(GeoLocalization))]
        public IHttpActionResult GetGeoLocalization(string url)
        {
            var geoLocalization = db.GeoLocalizations.Where(x => x.url == url);

            if (geoLocalization.Count() == 0)
            {
                return NotFound();
            }

            return Ok(geoLocalization);
        }

        // PUT: api/GeoLocalizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGeoLocalization(string url, GeoLocalization geoLocalization)
        {
            GeoLocalization geo = new GeoLocalization();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (geoLocalization != null)
            {
                geo = geoLocalization;
            }
            else
            {
                geo = db.GeoLocalizations.First(x => x.url == url);
            }


            if (url != geo.url)
            {
                return BadRequest();
            }

            db.Entry(geo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoLocalizationExists(url))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GeoLocalizations/url

        public IHttpActionResult PostGeoLocalizationFromUrl(string url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            infoServices = new IpInfoServices();
            var geoDetas = infoServices.GetDataIpInfo(url);


            var geoLocalization = db.GeoLocalizations.Where(x => x.url == url);
            if (geoLocalization.Count() == 0)
            {
                db.GeoLocalizations.Add(geoDetas);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = geoDetas.id }, geoDetas);
        }

        // POST: api/GeoLocalizations
        [ResponseType(typeof(GeoLocalization))]
        public IHttpActionResult PostGeoLocalization(GeoLocalization geoLocalization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.GeoLocalizations.Add(geoLocalization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = geoLocalization.id }, geoLocalization);
        }

        // DELETE: api/GeoLocalizations/5
        [ResponseType(typeof(GeoLocalization))]
        public IHttpActionResult DeleteGeoLocalization(string url)
        {
            var geoLocalization = db.GeoLocalizations.Where(u => u.url == url);
            if (geoLocalization.Count() == 0)
            {
                return NotFound();
            }

            foreach (var item in geoLocalization)
            {
                db.GeoLocalizations.Remove(item);
            }

            db.SaveChanges();

            return Ok(geoLocalization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeoLocalizationExists(int id)
        {
            return db.GeoLocalizations.Count(e => e.id == id) > 0;
        }

        private bool GeoLocalizationExists(string url)
        {
            return db.GeoLocalizations.Count(e => e.url == url) > 0;
        }
    }
}