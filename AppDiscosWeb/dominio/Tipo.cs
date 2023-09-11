using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDiscosWeb.dominio
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}