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
    public partial class rDivisas : System.Web.UI.Page
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
            RepositorioBase<Divisas> Repositorio = new RepositorioBase<Divisas>();
            Divisas ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (ID != null);
        }
        private Divisas LlenaClase()
        {
            Divisas Divisa = new Divisas();

            Divisa.DivisaId = Utils.ToInt(IDTextBox.Text);
            Divisa.Descripcion = DescripcionTextBox.Text;
            Divisa.Existencia = Utils.ToDecimal(ExistenciaTextBox.Text);
            Divisa.Tasa_Compra = Utils.ToDecimal(TasaCompraTextBox.Text);
            Divisa.Tasa_Venta = Utils.ToDecimal(TasaVentaTextBox.Text);
            Divisa.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return Divisa;
        }
        private void LlenaCampo(Divisas Divisa)
        {
            IDTextBox.Text = Divisa.DivisaId.ToString();
            DescripcionTextBox.Text = Divisa.Descripcion;
            ExistenciaTextBox.Text = Divisa.Existencia.ToString();
            TasaCompraTextBox.Text = Divisa.Tasa_Compra.ToString();
            TasaVentaTextBox.Text = Divisa.Tasa_Venta.ToString();
            FechaTextBox.Text = Divisa.Fecha.ToString("yyyy-MM-dd");
        }
        private void Limpiar()
        {
            IDTextBox.Text = "0";
            DescripcionTextBox.Text = "";
            ExistenciaTextBox.Text = "";
            TasaCompraTextBox.Text = "";
            TasaVentaTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Divisas Div = new Divisas();
            RepositorioBase<Divisas> Repositorio = new RepositorioBase<Divisas>();

            bool paso = false;

            Div = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Div);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
                    return;
                }
                paso = Repositorio.Modificar(Div);
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
            RepositorioBase<Divisas> Repositorio = new RepositorioBase<Divisas>();

            var ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (ID != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
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
            RepositorioBase<Divisas> Repositorio = new RepositorioBase<Divisas>();

            Divisas Div = new Divisas();

            Div = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (Div != null)
                LlenaCampo(Div);
            else
                Utils.ShowToastr(this.Page, "No se ha encontrado", "Error", "Error");
        }
    }
}