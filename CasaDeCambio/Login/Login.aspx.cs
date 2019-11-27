using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasaDeCambio.Login
{
    public partial class Login : System.Web.UI.Page
    {
        private RepositorioBase<Usuarios> BLL = new RepositorioBase<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void MostrarMensaje(string mensaje)
        {
            Mensaje.Text = mensaje;
            Mensaje.CssClass = "alert alert-danger";
        }
        protected void EntrarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtrar = x => true;
            Usuarios Usuario = new Usuarios();

            filtrar = t => t.Username.Equals(UsernameTextBox.Text) && t.Password.Equals(PasswordTextBox.Text);

            if (BLL.GetList(filtrar).Count() != 0)
            {
                FormsAuthentication.RedirectFromLoginPage(Usuario.Username, true);
            }
            else
            {
                MostrarMensaje("Incorrecto.");
            }
        }
    }
}