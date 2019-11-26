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
    public partial class rCambios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDivisa();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState["Cambios"] = new Cambios();
                BindGrid();
            }
        }
        private void FillDivisa()
        {
            RepositorioBase<Divisas> db = new RepositorioBase<Divisas>();
            var listado = new List<Divisas>();
            listado = db.GetList(p => true);
            DeDivisaDropDown.DataSource = listado;
            CualDivisaDropDown.DataSource = listado;
            DeDivisaDropDown.DataValueField = "DivisaId";
            CualDivisaDropDown.DataValueField = "DivisaId";
            DeDivisaDropDown.DataTextField = "Descripcion";
            CualDivisaDropDown.DataTextField = "Descripcion";
            DeDivisaDropDown.DataBind();
            CualDivisaDropDown.DataBind();
        }
        protected void BindGrid()
        {
            if (ViewState["Cambios"] != null)
            {
                Grid.DataSource = ((Cambios)ViewState["Cambios"]).Detalle;
                Grid.DataBind();
            }
        }
        private void Limpiar()
        {
            IDTextBox.Text = "0";
            PersonaTextBox.Text = "";
            DineroTextBox.Text = "";
            TotalCambiadoTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.BindGrid();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Cambios> Repositorio = new RepositorioBase<Cambios>();
            Cambios ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (ID != null);
        }
        private Cambios LlenaClase()
        {
            Cambios c = new Cambios();
            c = (Cambios)ViewState["Cambios"];
            c.CambiosId = Utils.ToInt(IDTextBox.Text);
            c.Nombre_Persona = PersonaTextBox.Text;
            c.Total_Cambiado = Utils.ToDecimal(TotalCambiadoTextBox.Text);
            c.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return c;
        }
        private void LlenaCampo(Cambios c)
        {
            ((Cambios)ViewState["Cambios"]).Detalle = c.Detalle;
            IDTextBox.Text = c.CambiosId.ToString();
            PersonaTextBox.Text = c.Nombre_Persona;
            TotalCambiadoTextBox.Text = c.Total_Cambiado.ToString();
            FechaTextBox.Text = c.Fecha.ToString("yyyy-MM-dd");
            this.BindGrid();
        }

        protected void AgregarGrid_Click(object sender, EventArgs e)
        {
            Cambios c = new Cambios();

            c = (Cambios)ViewState["Cambios"];

            Divisas D = new RepositorioBase<Divisas>().Buscar(Utils.ToInt(CualDivisaDropDown.SelectedValue));
            decimal Tasa = 0;
            if (OpcionDropDown.SelectedIndex == 0)
            {
                Tasa = D.Tasa_Compra;
            }
            else
            {
                Tasa = D.Tasa_Venta;
            }

            c.Detalle.Add(new CambiosDetalle(Utils.ToInt(DeDivisaDropDown.SelectedValue),Utils.ToInt(CualDivisaDropDown.SelectedValue),
                Utils.ToDecimal(DineroTextBox.Text),Utils.ToDecimal(DineroTextBox.Text)*Tasa,Utils.ToDateTime(FechaTextBox.Text)));

            ViewState["Detalle"] = c.Detalle;

            this.BindGrid();

            DineroTextBox.Text = string.Empty;

            decimal Total = 0;
            foreach (var item in c.Detalle.ToList())
            {
                Total += item.A;
            }
            TotalCambiadoTextBox.Text = Total.ToString();
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           Cambios c = new Cambios();

            c = (Cambios)ViewState["Cambios"];

            ViewState["Detalle"] = c.Detalle;

            int Fila = e.RowIndex;

            c.Detalle.RemoveAt(Fila);

            this.BindGrid();

            DineroTextBox.Text = string.Empty;
            decimal Total = 0;
            foreach (var item in c.Detalle.ToList())
            {
                Total += item.A;
            }
            TotalCambiadoTextBox.Text = Total.ToString();
        }

        protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid.DataSource = ViewState["Detalle"];

            Grid.PageIndex = e.NewPageIndex;

            Grid.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cambios> Repositorio = new RepositorioBase<Cambios>();

            Cambios c = new Cambios();

            c = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (c != null)
                LlenaCampo(c);
            else
                Utils.ShowToastr(this.Page, "No se ha encontrado", "Error", "Error");
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Cambios c = new Cambios();

            bool paso = false;

            c = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = BLL.CambiosBLL.Guardar(c);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
                    return;
                }
                paso = BLL.CambiosBLL.Modificar(c);
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
            RepositorioBase<Cambios> Repositorio = new RepositorioBase<Cambios>();

            var ID = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (ID != null)
            {
                if (BLL.CambiosBLL.Eliminar(Utils.ToInt(IDTextBox.Text)))
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
    }
}