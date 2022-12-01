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
    public class HorarioController : ApiController
    {
        // GET: Horario
        private readonly DBAcademiaNEntities _repo;
        public HorarioController()
        {

            _repo = new DBAcademiaNEntities();

        }

        // GET: Facultad

        [HttpGet]
        public IEnumerable<horario> Index()
        {
            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.horario.ToList();
        }

        [HttpGet]
        public horario SelectById(int id)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.horario.FirstOrDefault(x => x.id.Equals(id));
        }

        [HttpGet]
        public horario SelectByIdProfesor(int idprofesor)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.horario.FirstOrDefault(x => x.id_profesor.Equals(idprofesor));
        }

        [HttpGet]
        public horario SelectByIdGrupo(int idgrupo)
        {

            _repo.Configuration.ProxyCreationEnabled = false;
            return _repo.horario.FirstOrDefault(x => x.id_grupo.Equals(idgrupo));
        }


        [HttpPost]

        public IHttpActionResult create(horario entity)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            _repo.horario.Add(entity);
            _repo.SaveChanges();
            return Ok();


        }

        [HttpPut]
        public IHttpActionResult Edit(horario entity)
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

            _repo.horario.Remove(_repo.horario.FirstOrDefault(x => x.id.Equals(id)));
            _repo.SaveChanges();
            return Ok();

        }
    }
}