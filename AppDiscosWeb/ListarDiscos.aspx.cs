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
    public partial class ListarDiscos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            dgvDiscos.DataSource = negocio.listar();
            dgvDiscos.DataBind();
        }
    }
}