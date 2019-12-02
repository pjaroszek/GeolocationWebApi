using GeolocationWebApi.Interfaces;
using GeolocationWebApi.Models;
using GeolocationWebApi.Services;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace GeolocationWebApi.Controllers
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
            GeoLocalization geoLocalization = db.GeoLocalizations.Find(url);
            if (geoLocalization == null)
            {
                return NotFound();
            }

            return Ok(geoLocalization);
        }

        // PUT: api/GeoLocalizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGeoLocalization(int id, GeoLocalization geoLocalization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != geoLocalization.id)
            {
                return BadRequest();
            }

            db.Entry(geoLocalization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoLocalizationExists(id))
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
        public IHttpActionResult DeleteGeoLocalization(int id)
        {
            GeoLocalization geoLocalization = db.GeoLocalizations.Find(id);
            if (geoLocalization == null)
            {
                return NotFound();
            }

            db.GeoLocalizations.Remove(geoLocalization);
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
    }
}