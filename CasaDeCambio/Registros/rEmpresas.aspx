<%@ Page Title="Crear Empresas" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rEmpresas.aspx.cs" Inherits="CasaDeCambio.Registros.rEmpresas" %>
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
                         <asp:LinkButton ID="BuscarButton" CssClass="btn btn-dark btn-block btn-md" CausesValidation="false" runat="server" Text="Buscar" ></asp:LinkButton>
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
                 <label for="Direccion" class="col-sm-1 col-form-label">Direccion</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="DireccionTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVDireccion" runat="server" MaxLength="100" ControlToValidate="DireccionTextBox" ErrorMessage="Direccion no valida" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                    <div class="form-group row">
                 <label for="Telefono" class="col-sm-1 col-form-label">Telefono</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="TelefonoTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVTelefono" runat="server" MaxLength="100" ControlToValidate="TelefonoTextBox" ErrorMessage="Telefono no valido" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>

                 </div>
            </div>
     <div class="panel-footer">
     <div class="text-center">
        <div class="form-group" style="display: inline-block">

              <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" CausesValidation="false" style="color:#fff" runat="server" ID="NuevoButton" />
              <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton"/>
              <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" CausesValidation="false" runat="server" ID="EliminarButton" />

        </div>
       </div>

 </div>
</div>
</asp:Content>
