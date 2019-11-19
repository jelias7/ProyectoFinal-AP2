using BLL;
using CasaDeCambio.Utilitarios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasaDeCambio.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (ID != null);
        }
        private Usuarios LlenaClase()
        {
            Usuarios Usuario = new Usuarios();

            Usuario.UsuarioId = Utils.ToInt(IDTextBox.Text);
            Usuario.Username = UsernameTextBox.Text;
            Usuario.Password = PasswordTextBox.Text;
            Usuario.Tipo_Usuario = TipoDropDown.SelectedValue;
            Usuario.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return Usuario;
        }
        private void LlenaCampo(Usuarios User)
        {
            IDTextBox.Text = User.UsuarioId.ToString();
            UsernameTextBox.Text = User.Username;
            PasswordTextBox.Text = User.Password;
            TipoDropDown.SelectedValue = User.Tipo_Usuario;
            FechaTextBox.Text = User.Fecha.ToString("yyyy-MM-dd");
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios User = new Usuarios();
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();

            bool paso = false;

            User = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(User);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error");
                    return;
                }
                paso = Repositorio.Modificar(User);
                Response.Redirect(Request.RawUrl);
            }

            if (paso)
            {
                Utils.ShowToastr(this.Page, "Exito", "success");
                return;
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();

            var ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (ID != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Exito", "success");
                }
                else
                    Utils.ShowToastr(this.Page, "Error", "Error");
            }
            else
                Utils.ShowToastr(this.Page, "Error", "Error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();

            Usuarios User = new Usuarios();

            User = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (User != null)
                LlenaCampo(User);
            else
                Utils.ShowToastr(this.Page, "Error", "Error");
        }
    }
}