using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppDiscosWeb.dominio;
using AppDiscosWeb.negocio;

namespace AppDiscosWeb
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Disco> ListaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            ListaDiscos = negocio.listar();

        }
    }
}