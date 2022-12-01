using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


using EjercicioParcial3Apl.WebApi.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace EjercicioParcial3Apl.WebApi.Controllers
{
    public class GruposController : ApiController
    {
        // GET: Grupos
        private readonly DBAcademiaNEntities _repo;
        public GruposController()
        {

            _repo = new DBAcademiaNEntities();

        }

        // GET: Facultad

        [HttpGet]
        public IEnumerable<grupos> Index()
        {
            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.grupos.ToList();
        }

        [HttpGet]
        public grupos SelectById(int id)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.grupos.FirstOrDefault(x => x.id.Equals(id));
        }

        [HttpGet]
        public grupos SelectByName(string name)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.grupos.FirstOrDefault(x => x.nombre.Contains(name));
        }


        [HttpPost]

        public IHttpActionResult create(grupos entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.grupos.Add(entity);
            _repo.SaveChanges();
            return Ok();


        }

        [HttpPut]
        public IHttpActionResult Edit(grupos entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.Entry(entity).State = System.Data.EntityState.Modified;
            _repo.SaveChanges();
            return Ok();


        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            _repo.grupos.Remove(_repo.grupos.FirstOrDefault(x => x.id.Equals(id)));
            _repo.SaveChanges();
            return Ok();

        }
    }
}