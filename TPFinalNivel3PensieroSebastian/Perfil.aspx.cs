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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                
                    if (Seguridad.sessionActiva(Session["usuario"]))
                    {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtEmail.Text = usuario.Email;
                    txtEmail.ReadOnly = true;
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    if (!string.IsNullOrEmpty(usuario.ImagenPefil))
                        imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.ImagenPefil;
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];
                //Escribir imagen si se cargó algo
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenPefil = "perfil-" + usuario.Id + ".jpg";
                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                //Guardar datos al perfil
                negocio.actualizar(usuario);


                //Leer imagen
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + usuario.ImagenPefil;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}