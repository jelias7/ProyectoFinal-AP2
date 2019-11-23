﻿<%@ Page Title="Consulta de Divisas" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cDivisas.aspx.cs" Inherits="CasaDeCambio.Consultas.cDivisas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<div class="panel panel-primary">
          <div class="panel-heading" style="font-size: 20px; color: white; padding:15px; background-color:darkgoldenrod">CONSULTA DE DIVISAS</div><br />
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
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Tasa de Compra</asp:ListItem>
                        <asp:ListItem>Tasa de Venta</asp:ListItem>
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
    <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="DivisaId" CellPadding="4" ForeColor="Black" GridLines="None">
                    <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
    </asp:GridView>
    </div>
</asp:Content>
