using BLL;
using CasaDeCambio.Utilitarios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasaDeCambio.Consultas
{
    public partial class cCambios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Cambios, bool>> filtros = x => true;
            RepositorioBase<Cambios> repositorio = new RepositorioBase<Cambios>();
            List<Cambios> lista = new List<Cambios>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.CambiosId == criterio;
                    break; //ID
                case 2:
                    filtros = c => c.Nombre_Persona.Contains(CriterioTextBox.Text);
                    break; //Nombre Persona
                case 3:
                    filtros = c => c.Total_Cambiado == criterio;
                    break; //Total Cambiado
            }
            if (CheckBoxFecha.Checked == true)
            {
                lista = repositorio.GetList(filtros).Where(x => x.Fecha.Date >= Desde && x.Fecha.Date <= Hasta).ToList();
            }
            else
            {
                lista = repositorio.GetList(filtros);
            }
            Grid.DataSource = lista;
            Grid.DataBind();
        }
    }
}