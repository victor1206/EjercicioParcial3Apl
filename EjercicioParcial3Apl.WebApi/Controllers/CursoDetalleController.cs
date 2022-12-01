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
    public class CursoDetalleController : ApiController
    {
        // GET: CursoDetalle
        private readonly DBAcademiaNEntities _repo;
        public CursoDetalleController()
        {

            _repo = new DBAcademiaNEntities();

        }

        // GET: Facultad

        [HttpGet]
        public IEnumerable<cursoDetalle> Index()
        {
            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursoDetalle.ToList();
        }

        [HttpGet]
        public cursoDetalle SelectById(int id)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursoDetalle.FirstOrDefault(x => x.id.Equals(id));
        }

        [HttpGet]
        public cursoDetalle SelectByName(string name)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursoDetalle.FirstOrDefault(x => x.descripcion_corta.Contains(name));
        }

        [HttpGet]
        public cursoDetalle SelectByIdCurso(int idcurso)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.cursoDetalle.FirstOrDefault(x => x.idcurso.Equals(idcurso));
        }


        [HttpPost]

        public IHttpActionResult create(cursoDetalle entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.cursoDetalle.Add(entity);
            _repo.SaveChanges();
            return Ok();


        }

        [HttpPut]
        public IHttpActionResult Edit(cursoDetalle entity)
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

            _repo.cursoDetalle.Remove(_repo.cursoDetalle.FirstOrDefault(x => x.id.Equals(id)));
            _repo.SaveChanges();
            return Ok();

        }
    }
}