<%@ Page Title="Consulta de Entrada de Moneda" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cEntrada.aspx.cs" Inherits="CasaDeCambio.Consultas.cEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<div class="panel panel-primary">
        <div class="panel-heading" style="font-size: 20px; color: black; padding:15px; background-color:beige">CONSULTA DE ENTRADA DE MONEDA</div><br />
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
                        <asp:ListItem>ID de Divisa</asp:ListItem>
                        <asp:ListItem>Existencia</asp:ListItem>
                    </asp:DropDownList>
                </div>
                   <label for="CheckBox" class="col-sm-1 col-form-label">Fecha?</label>
                <div class="col-xs-1">
                    <asp:CheckBox runat="server" CssClass="custom-checkbox" ID="CheckBoxFecha" />
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
    <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="EntradaId" CellPadding="4" ForeColor="Black" GridLines="None">
                    <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
    </asp:GridView>
    </div>
</asp:Content>
