using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3PensieroSebastian
{
    public partial class DetallesArtículo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            ddlMarca.Enabled = false;
            ddlCategoria.Enabled = false;
            txtPrecio.Enabled = false;
            txtDescripcion.Enabled = false;
            
            MarcasNegocio negocio1 = new MarcasNegocio();
            List<Marcas> lista = negocio1.listar();

            ddlMarca.DataSource = lista;
            ddlMarca.DataValueField = "id";
            ddlMarca.DataTextField = "descripcion";
            ddlMarca.DataBind();

            CategoriasNegocio negocio2 = new CategoriasNegocio();
            List<Categorias> lista1 = negocio2.listar();

            ddlCategoria.DataSource = lista1;
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "descripcion";
            ddlCategoria.DataBind();

            try
			{                
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulos seleccionado = (negocio.listar(id))[0];

                    //guardo el articulo seleccionado en sesion
                    Session.Add("articuloSeleccionado", seleccionado);

                    //cargo los campos
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    imgNuevoPerfil.ImageUrl = seleccionado.ImagenUrl;
                }

            }
			catch (Exception ex)
			{

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}