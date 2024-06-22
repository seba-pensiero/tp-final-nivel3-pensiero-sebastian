using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3PensieroSebastian
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Default || Page is Registro))
            {
                if (!Seguridad.sessionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    lblUser.Text = usuario.Email;
                    if (!string.IsNullOrEmpty(usuario.ImagenPefil))
                        imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPefil;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}