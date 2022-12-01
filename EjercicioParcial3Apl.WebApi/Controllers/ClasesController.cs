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
    public class ClasesController : ApiController
    {
        // GET: Clases
        private readonly DBAcademiaNEntities _repo;
        public ClasesController()
        {

            _repo = new DBAcademiaNEntities();

        }

        // GET: Facultad

        [HttpGet]
        public IEnumerable<clases> Index()
        {
            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.clases.ToList();
        }

        [HttpGet]
        public clases SelectById(int id)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.clases.FirstOrDefault(x => x.id.Equals(id));
        }

        [HttpGet]
        public clases SelectByIdProfesor(int idprofesor)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.clases.FirstOrDefault(x => x.idprofesor.Equals(idprofesor));
        }

        [HttpGet]
        public clases SelectByIdGrupo(int idhorario)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.clases.FirstOrDefault(x => x.idhorario.Equals(idhorario));
        }


        [HttpPost]

        public IHttpActionResult create(clases entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.clases.Add(entity);
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