<%@ Page Title="Consulta de Cambios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cCambios.aspx.cs" Inherits="CasaDeCambio.Consultas.cCambios" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="panel panel-primary">
      <div class="panel-heading" style="font-size: 20px; color: white; padding:15px; background-color:darkslategray">CONSULTA DE CAMBIOS
      </div><br />
        <div class="panel-body">
            <div class="form-group row">
                <label for="Desde" class="col-sm-1 col-form-label">Desde</label>
                <div class="col-md-2">
                    <asp:TextBox type="date" runat="server" ID="DesdeFecha" Class="form-control input-sm"></asp:TextBox>
                </div>
              <label for="Hasta" class="col-xs-1 col-form-label">Hasta</label>
                <div class="col-md-2">
                  <asp:TextBox type="date" runat="server" ID="HastaFecha" Class="form-control input-sm"></asp:TextBox>
                </div>
            </div>

              <div class="form-group row">
              <label for="Filtro" class="col-sm-1 col-form-label">Filtro</label>
            <div class="col-md-2">
                    <asp:DropDownList ID="FiltroDropDown" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>Nombre Persona</asp:ListItem>
                        <asp:ListItem>Total Cambiado</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
             <div class="form-group row">
                <label for="Criterio" class="col-sm-1 col-form-label">Criterio</label>
                <div class="col-md-6">
                    <asp:TextBox ID="CriterioTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Consultar" OnClick="BuscarButton_Click"/>
                </div>
            </div>
        </div>
    <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" ShowHeaderWhenEmpty="True" DataKeyNames="CambiosId" CellPadding="4" AutoGenerateColumns="false" ForeColor="Black" GridLines="None">
         <Columns>
                        <asp:BoundField DataField="CambiosId" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre_Persona" HeaderText="Persona" />
                        <asp:BoundField DataField="Total_Cambiado" HeaderText="Total Cambiado" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" /><asp:BoundField />

                    </Columns>                
        <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
    </asp:GridView>
     <div class="col-md-6">
              <button type="button" class="btn btn-warning" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
          <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
               <div class="modal-dialog" style="max-width: 900px!important; min-width: 600px!important;max-height:800px!important; min-height:500px!important">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">REPORTE CAMBIOS</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <%--Viewer--%>
                            <rsweb:ReportViewer ID="MyViewer" runat="server" ProcessingMode="Local" Height="500px" Width="800px">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                            </rsweb:ReportViewer>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
          </div>
     </div>
    </div>
</asp:Content>
