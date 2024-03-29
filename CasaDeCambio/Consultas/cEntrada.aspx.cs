﻿using BLL;
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
    public partial class cEntrada : System.Web.UI.Page
    {
        List<EntradaMonedas> lista = new List<EntradaMonedas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private void Reporte(List<EntradaMonedas> List)
        {
            MyViewer.LocalReport.Refresh();
            MyViewer.ProcessingMode = ProcessingMode.Local;
            MyViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoEntrada.rdlc");
            MyViewer.LocalReport.DataSources.Add(new ReportDataSource("EntradaMoneda", List));
            MyViewer.LocalReport.Refresh();
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<EntradaMonedas, bool>> filtros = x => true;
            RepositorioBase<EntradaMonedas> repositorio = new RepositorioBase<EntradaMonedas>();
            
            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int criterio =  Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0: filtros = x => true;
                break; //todo
                case 1: filtros = c => c.EntradaId == criterio;
                break; //ID
                case 2: filtros = c => c.DivisaId == criterio;
                break; //ID de Divisa
                case 3: filtros = c => c.Existencia == criterio;
                break; //Existencia
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