using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using EjercicioParcial3Apl.WebApi.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace EjercicioParcial3Apl.WebApi.Controllers
{
    public class ProfesoresController : ApiController
    {
        // GET: Profesores
        // GET: Cusos
        private readonly DBAcademiaNEntities _repo;
        public ProfesoresController()
        {

            _repo = new DBAcademiaNEntities();

        }

        // GET: Facultad

        [HttpGet]
        public IEnumerable<profesores> Index()
        {
            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.profesores.ToList();
        }

        [HttpGet]
        public profesores SelectById(int id)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.profesores.FirstOrDefault(x => x.id.Equals(id));
        }

        [HttpGet]
        public profesores SelectByName(string name)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.profesores.FirstOrDefault(x => x.nombre.Contains(name));
        }


        [HttpPost]

        public IHttpActionResult create(profesores entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.profesores.Add(entity);
            _repo.SaveChanges();
            return Ok();


        }

        [HttpPut]
        public IHttpActionResult Edit(profesores entity)
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

            _repo.profesores.Remove(_repo.profesores.FirstOrDefault(x => x.id.Equals(id)));
            _repo.SaveChanges();
            return Ok();

        }
    }
}