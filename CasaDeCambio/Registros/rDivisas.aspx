<%@ Page Title="Registrar Divisas" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rDivisas.aspx.cs" Inherits="CasaDeCambio.Registros.rDivisas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<div class="panel panel-primary">
        <div class="panel-body">
              <div class="form-horizontal col-md-12" role="form">
                  <div class="form-group row">
                    <label for="ID" class="col-sm-1 col-form-label">ID</label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox type="number" ID="IDTextBox" runat="server" min=0 class="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-sm-2 col-xs-4">
                         <asp:LinkButton ID="BuscarButton" CssClass="btn btn-dark btn-block btn-md" CausesValidation="false" runat="server" Text="Buscar" OnClick="BuscarButton_Click" ></asp:LinkButton>
                    </div>    
                    <label for="Fecha" class="col-xs-1 col-form-label">Fecha</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFecha" runat="server" MaxLength="200" ControlToValidate="FechaTextBox" ErrorMessage="Fecha no valida" ForeColor="Black" Display="None" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                </div>
                 <div class="form-group row">
                 <label for="Descripcion" class="col-sm-1 col-form-label">Descripcion</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="DescripcionTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" MaxLength="100" ControlToValidate="DescripcionTextBox" ErrorMessage="Descripcion no valida" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                   <div class="form-group row">
                 <label for="TasaCompra" class="col-sm-1 col-form-label">Tasa de Compra</label>
                     <div class="col-md-1 col-sm-2 col-xs-4">
                         <asp:TextBox type="number" runat="server" CssClass="form-control input-sm" ID="TasaCompraTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVCompra" runat="server" MaxLength="100" ControlToValidate="TasaCompraTextBox" ErrorMessage="Debe ingresar tasa de compra" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                   <div class="form-group row">
                 <label for="TasaVenta" class="col-sm-1 col-form-label">Tasa de Venta</label>
                     <div class="col-md-1 col-sm-2 col-xs-4">
                         <asp:TextBox type="number" runat="server" CssClass="form-control input-sm" ID="TasaVentaTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVVenta" runat="server" MaxLength="100" ControlToValidate="TasaVentaTextBox" ErrorMessage="Debe ingresar tasa de venta" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                 </div>
            <div class="col-md-5">
                <asp:ValidationSummary runat="server" ID="SummaryValidation"
                    ForeColor="red"
                    DisplayMode="List"
                    ShowSummary="true"
                    EnableClientScript="True"
                    Font-Bold="True"
                    CssClass=" alert alert-light" />
            </div>
            </div>
    <div class="panel-footer">
     <div class="text-center">
        <div class="form-group" style="display: inline-block">

              <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" CausesValidation="false" style="color:#fff" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
              <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton" OnClick="GuardarButton_Click"/>
              <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" CausesValidation="false" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

        </div>
       </div>

 </div>
    </div>
</asp:Content>
