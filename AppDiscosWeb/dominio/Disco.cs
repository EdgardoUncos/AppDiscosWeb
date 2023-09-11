using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDiscosWeb.dominio
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagenTapa { get; set; }

        public Tipo Estilo { get; set; }
        public Tipo TipoEdicion { get; set; }
    }
}