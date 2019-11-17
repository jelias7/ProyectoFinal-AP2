﻿<%@ Page Title="Caja Registradora" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rCaja.aspx.cs" Inherits="CasaDeCambio.Registros.rCaja" %>
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
                 <label for="Pesos" class="col-sm-1 col-form-label">Pesos</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="PesosTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVPesos" runat="server" MaxLength="100" ControlToValidate="PesosTextBox" ErrorMessage="Cantidad de pesos invalida" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                   <div class="form-group row">
                 <label for="Dolar" class="col-sm-1 col-form-label">Dolares</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="DolarTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVDolar" runat="server" MaxLength="100" ControlToValidate="DolarTextBox" ErrorMessage="Cantidad de dolares invalida" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                   <div class="form-group row">
                 <label for="Euro" class="col-sm-1 col-form-label">Euros</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="EuroTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVEuro" runat="server" MaxLength="100" ControlToValidate="EuroTextBox" ErrorMessage="Cantidad de euros invalida" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     </div>
                 </div>
                   <div class="form-group row">
                 <label for="LibraEsterlina" class="col-sm-1 col-form-label">Libra Esterlina</label>
                     <div class="col-lg-3">
                         <asp:TextBox runat="server" CssClass="form-control input-sm" ID="LibraTextBox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVLibra" runat="server" MaxLength="100" ControlToValidate="LibraTextBox" ErrorMessage="Cantidad de libras invalida" ForeColor="Black" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
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

              <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" CausesValidation="false" style="color:#fff" runat="server" ID="NuevoButton" />
              <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton"/>
              <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" CausesValidation="false" runat="server" ID="EliminarButton" />

        </div>
       </div>

 </div>
</div>
</asp:Content>