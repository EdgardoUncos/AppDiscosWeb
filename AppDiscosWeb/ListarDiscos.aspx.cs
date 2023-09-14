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
            Session.Add("listaDiscos", negocio.listar());
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();
        }

        // Evento Click Accion pasa por parametros el id a FormularioDisco
        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDisco.aspx?id=" + id, false);
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> lista = (List<Disco>)Session["listaDiscos"];
            List<Disco> listaFiltrada = lista.FindAll(x => x.Titulo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvDiscos.DataSource = listaFiltrada;
            dgvDiscos.DataBind();
        }

        protected void Unnamed_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
                dgvDiscos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("erro", ex);
                throw;
            }
        }

        

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Cantidad Canciones")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }
    }
}