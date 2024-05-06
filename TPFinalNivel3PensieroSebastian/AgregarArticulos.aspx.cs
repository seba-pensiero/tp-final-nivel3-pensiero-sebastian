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
    public partial class AgregarArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            //Configuración inicial de pantalla
            if (!IsPostBack)
            {
                MarcasNegocio negocio = new MarcasNegocio();
                List<Marcas> lista = negocio.listar();

                ddlMarca.DataSource = lista;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                CategoriasNegocio negocio2 = new CategoriasNegocio();
                List<Categorias> lista2 = negocio2.listar();

                ddlCategoria.DataSource = lista2;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Precio = float.Parse(txtPrecio.Text);
                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categorias();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                negocio.agregarConSp(nuevo);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}