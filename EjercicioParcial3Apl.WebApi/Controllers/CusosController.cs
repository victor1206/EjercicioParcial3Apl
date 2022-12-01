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
    public class CusosController : ApiController
    {
        // GET: Cusos
        private readonly DBAcademiaNEntities _repo;
        public CusosController()
        {

            _repo = new DBAcademiaNEntities();

        }

        // GET: Facultad

        [HttpGet]
        public IEnumerable<cursos> Index()
        {
            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursos.ToList();
        }

        [HttpGet]
        public cursos SelectById(int id)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursos.FirstOrDefault(x => x.id.Equals(id));
        }

        [HttpGet]
        public cursos SelectByName(string name)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursos.FirstOrDefault(x => x.nombre.Contains(name));
        }


        [HttpPost]

        public IHttpActionResult create(cursos entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.cursos.Add(entity);
            _repo.SaveChanges();
            return Ok();


        }

        [HttpPut]
        public IHttpActionResult Edit(clases entity)
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

            _repo.clases.Remove(_repo.clases.FirstOrDefault(x => x.id.Equals(id)));
            _repo.SaveChanges();
            return Ok();

        }
    }
}