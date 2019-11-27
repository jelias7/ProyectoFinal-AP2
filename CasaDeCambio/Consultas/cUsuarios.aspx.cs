using BLL;
using CasaDeCambio.Utilitarios;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasaDeCambio.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private void Reporte(List<Usuarios> List)
        {
            MyViewer.LocalReport.Refresh();
            MyViewer.ProcessingMode = ProcessingMode.Local;
            MyViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoUsuarios.rdlc");
            MyViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", List));
            MyViewer.LocalReport.Refresh();
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtros = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> lista = new List<Usuarios>();
            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.UsuarioId == criterio;
                    break; //ID
                case 2:
                    filtros = c => c.Username.Contains(CriterioTextBox.Text);
                    break; //Username
                case 3:
                    filtros = c => c.Password.Contains(CriterioTextBox.Text);
                    break; //Password
                case 4:
                    filtros = c => c.Tipo_Usuario.Contains(CriterioTextBox.Text);
                    break; //Tipo
            }
            if (DesdeFecha.Text != "" && HastaFecha.Text != "")
            {
                lista = repositorio.GetList(filtros).Where(x => x.Fecha.Date >= Desde && x.Fecha.Date <= Hasta).ToList();
            }
            else
            {
                lista = repositorio.GetList(filtros);
            }
            Reporte(lista);
            Grid.DataSource = lista;
            Grid.DataBind();
        }
    }
}