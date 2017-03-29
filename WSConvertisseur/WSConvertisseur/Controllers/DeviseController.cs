using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSConvertisseur.Models;
using System.Web.Http.Description;

namespace WSConvertisseur.Controllers
{
    public class DeviseController : ApiController //Always inherits
    {
        List<Devise> devises;
        public DeviseController()
        {
            devises = new List<Devise>();
            Devise dollar = new Devise(1, "Dollar", 1.07);
            Devise fr_suise = new Devise(2, "Franc Suisse", 120);
            Devise yen = new Devise(3, "Yen", 1.08);


            devises.Add(dollar);
            devises.Add(fr_suise);
            devises.Add(yen);
        }
        // GET: api/Devise
        public IEnumerable<Devise> Get()
        {
            /*
             * La méthode Get récupérant toutes les devises est maintenant 
             * fonctionnelle et se consomme de cettefaçon : GET /Devise
             */
            return this.devises.AsQueryable();
        }

        // GET: api/Devise/5
        [ResponseType(typeof(Devise))]
        public IHttpActionResult Get(int id)
        {
            Devise devise = devises.FirstOrDefault((d) => d.id == id);
            if (devise == null)
            {
                return NotFound();
            }

            /*
                 * 
                 * Si un objet de type Devise a été trouvé, c’est la méthode Ok(T) de la classe ApiController qui est
                    appelée. Le message http finalement retourné contient le statut HttpStatusCode.OK (correspondant
                    au code 200 OK) et la représentation de l’objet (au format JSON ou XML, par exemple) passée en
                    paramètre de la méthode Ok.

            */
            return Ok(devise);

        }

        //POST
        [ResponseType(typeof(Devise))]
        public IHttpActionResult Post(Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("DefaultApi", new { id = devise.id }, devise);
        }

        // PUT: api/Devise/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.id)
            {
                return BadRequest();
            }

            int index = devises.FindIndex((d) => d.id == id);
            if (index < 0)
            {
                return NotFound();
            }

            /*
             * Ici, nous avons fait le choix de ne pas retourner l’objet Devise modifié 
             * (return Ok<devise>), mais
             * 
             * */
            devises[index] = devise;
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Devise/
        public IEnumerable<Devise> Delete()
        {
            /*
             * La méthode Get récupérant toutes les devises est maintenant 
             * fonctionnelle et se consomme de cettefaçon : GET /Devise
             */
            return this.devises.AsQueryable();
        }

        // DELETE: api/Devise/
        [ResponseType(typeof(Devise))]
        public IHttpActionResult Delete(int id)
        {
            Devise devise = devises.FirstOrDefault((d) => d.id == id);
            if (devise == null)
            {
                return NotFound();
            }

            devises.Remove(devise);

            devises.Count();
                        
            return Ok(devise);
        }
        
    }
}
