//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjercicioParcial3Apl.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cursos
    {
        public cursos()
        {
            this.cursoDetalle = new HashSet<cursoDetalle>();
            this.grupos = new HashSet<grupos>();
            this.secciones = new HashSet<secciones>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string nivel { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<cursoDetalle> cursoDetalle { get; set; }
        public virtual ICollection<grupos> grupos { get; set; }
        public virtual ICollection<secciones> secciones { get; set; }
    }
}