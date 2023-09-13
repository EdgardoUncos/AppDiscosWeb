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
                // Configuracion inicial de la pantalla
                if(!IsPostBack)
                {
                    TipoNegocio negocioT = new TipoNegocio();
                    //List<Tipo> listaT = negocioT.listar();

                    ddlEdicion.DataSource = negocioT.listar();
                    ddlEdicion.DataValueField = "Id";
                    ddlEdicion.DataTextField = "Descripcion";
                    ddlEdicion.DataBind();

                    ddlEstilo.DataSource = negocioT.ListarTipo(); ;
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataBind();

                    // Configuracion si estamos modificando.

                    if(Request.QueryString["id"] != null)
                    {
                        DiscoNegocio negocio = new DiscoNegocio();
                        List<Disco> lista = negocio.listar(Request.QueryString["id"].ToString());
                        Disco seleccionado = lista[0];

                        txtId.Text = seleccionado.Id.ToString();
                        txtTitulo.Text = seleccionado.Titulo;
                        txtCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();
                        txtUrlImagenTapa.Text = seleccionado.UrlImagenTapa;
                        txtFechaLanzamiento.Text = seleccionado.FechaLanzamiento.ToString();

                        ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                        ddlEdicion.SelectedValue = seleccionado.TipoEdicion.Id.ToString();

                        txtUrlImagenTapa_TextChanged(sender, e);
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
                nuevo.FechaLanzamiento = DateTime.Parse(txtFechaLanzamiento.Text);
                //nuevo.FechaLanzamiento = txtFecha.SelectedDate;

                nuevo.TipoEdicion = new Tipo();
                nuevo.TipoEdicion.Id = int.Parse(ddlEdicion.SelectedValue);
                nuevo.Estilo = new Tipo();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"].ToString());
                    negocio.modificar(nuevo);

                }
                else
                {
                    //negocio.agregarConSP(nuevo);
                    negocio.agregar(nuevo);

                }

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void txtUrlImagenTapa_TextChanged(object sender, EventArgs e)
        {
            imgDisco.ImageUrl = txtUrlImagenTapa.Text;
        }
    }
}