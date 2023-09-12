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
    public partial class FormularioDisco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if(!IsPostBack)
                {
                    TipoNegocio negocioT = new TipoNegocio();
                    List<Tipo> listaT = negocioT.listar();

                    ddlEdicion.DataSource = listaT;
                    ddlEdicion.DataValueField = "Id";
                    ddlEdicion.DataTextField = "Descripcion";
                    ddlEdicion.DataBind();

                    ddlEstilo.DataSource = listaT;
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataBind();

                    if(Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        List<Disco> ListaDisco;
                        DiscoNegocio negocio = new DiscoNegocio();
                        ListaDisco = negocio.listar();
                        Disco seleccionado = ListaDisco.Find(x => x.Id == id);

                        txtId.Text = seleccionado.Id.ToString();
                        txtTitulo.Text = seleccionado.Titulo;
                        txtCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();
                        txtUrlImagenTapa.Text = seleccionado.UrlImagenTapa;
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Disco nuevo = new Disco();
                DiscoNegocio negocio = new DiscoNegocio();

                nuevo.Titulo = txtTitulo.Text;
                nuevo.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                nuevo.UrlImagenTapa = txtUrlImagenTapa.Text;
                //nuevo.FechaLanzamiento = DateTime.Parse(txtFechaLanzamiento.Text);
                nuevo.FechaLanzamiento = txtFecha.SelectedDate;

                nuevo.TipoEdicion = new Tipo();
                nuevo.TipoEdicion.Id = int.Parse(ddlEdicion.SelectedValue);
                nuevo.Estilo = new Tipo();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);

                negocio.agregar(nuevo);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}