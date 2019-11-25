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
    public partial class rEntrada : System.Web.UI.Page
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
            RepositorioBase<EntradaMonedas> Repositorio = new RepositorioBase<EntradaMonedas>();
            EntradaMonedas ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (ID != null);
        }
        private EntradaMonedas LlenaClase()
        {
            EntradaMonedas Caja = new EntradaMonedas();

            Caja.EntradaId = Utils.ToInt(IDTextBox.Text);
            Caja.DivisaId = Utils.ToInt(DivisaDropDown.SelectedValue);
            Caja.Existencia = Utils.ToDecimal(ExistenciaTextBox.Text);
            Caja.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return Caja;
        }
        private void LlenaCampo(EntradaMonedas Caja)
        {
            IDTextBox.Text = Caja.EntradaId.ToString();
            DivisaDropDown.SelectedValue = Caja.DivisaId.ToString();
            ExistenciaTextBox.Text = Caja.Existencia.ToString();
            FechaTextBox.Text = Caja.Fecha.ToString("yyyy-MM-dd");
        }
        private void Limpiar()
        {
            IDTextBox.Text = "0";
            ExistenciaTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
            protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            EntradaMonedas Caja = new EntradaMonedas();

            bool paso = false;

            Caja = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = BLL.EntradaBLL.Guardar(Caja);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
                    return;
                }
                paso = BLL.EntradaBLL.Modificar(Caja);
                Limpiar();
            }

            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado", "Exito", "Success");
                return;
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<EntradaMonedas> Repositorio = new RepositorioBase<EntradaMonedas>();

            var ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (ID != null)
            {
                if (BLL.EntradaBLL.Eliminar(Utils.ToInt(IDTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Se ha borrado", "Exito", "Success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No se ha borrado", "Error", "Error");
            }
            else
                Utils.ShowToastr(this.Page, "Error", "Error", "Error");

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<EntradaMonedas> Repositorio = new RepositorioBase<EntradaMonedas>();

            EntradaMonedas Caja = new EntradaMonedas();

            Caja = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (Caja != null)
                LlenaCampo(Caja);
            else
                Utils.ShowToastr(this.Page, "No se ha encontrado", "Error", "Error");

        }
    }
}