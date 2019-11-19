using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CasaDeCambio.Utilitarios;

namespace CasaDeCambio.Registros
{
    public partial class rCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FillDivisa();
            }
        }
        private void FillDivisa()
        {
            RepositorioBase<Divisas> db = new RepositorioBase<Divisas>();
            var listado = new List<Divisas>();
            listado = db.GetList(p => true);
            DivisaDropDown.DataSource = listado;
            DivisaDropDown.DataValueField = "DivisaId";
            DivisaDropDown.DataTextField = "Descripcion";
            DivisaDropDown.DataBind();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<CajaRegistradora> Repositorio = new RepositorioBase<CajaRegistradora>();
            CajaRegistradora ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (ID != null);
        }
        private CajaRegistradora LlenaClase()
        {
            CajaRegistradora Caja = new CajaRegistradora();

            Caja.CajaId = Utils.ToInt(IDTextBox.Text);
            Caja.DivisaId = Utils.ToInt(DivisaDropDown.SelectedValue);
            Caja.Existencia = Utils.ToDecimal(ExistenciaTextBox.Text);
            Caja.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return Caja;
        }
        private void LlenaCampo(CajaRegistradora Caja)
        {
            IDTextBox.Text = Caja.CajaId.ToString();
            DivisaDropDown.SelectedValue = Caja.DivisaId.ToString();
            ExistenciaTextBox.Text = Caja.Existencia.ToString();
            FechaTextBox.Text = Caja.Fecha.ToString("yyyy-MM-dd");
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            CajaRegistradora Caja = new CajaRegistradora();
            RepositorioBase<CajaRegistradora> Repositorio = new RepositorioBase<CajaRegistradora>();

            bool paso = false;

            Caja = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Caja);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error");
                    return;
                }
                paso = Repositorio.Modificar(Caja);
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
            RepositorioBase<CajaRegistradora> Repositorio = new RepositorioBase<CajaRegistradora>();

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
            RepositorioBase<CajaRegistradora> Repositorio = new RepositorioBase<CajaRegistradora>();

            CajaRegistradora Caja = new CajaRegistradora();

            Caja = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (Caja != null)
                LlenaCampo(Caja);
            else
                Utils.ShowToastr(this.Page, "Error", "Error");

        }
    }
}