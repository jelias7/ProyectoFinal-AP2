<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CasaDeCambio.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Casa de Cambio</title>
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
   <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <form id="form1" runat="server">
        <div style="max-width: 100%;">
            <div class="panel panel-default"><br />
                <div class="panel-heading h4 text-primary text-center">
Login</div>
<div class="panel-body" style="margin-left:250px;margin-top:50px;">
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="txtmobile">Username</label>
                            <div class="col-sm-10">
                                <asp:textbox class="form-control" id="UsernameTextBox" placeholder="Username" runat="server"></asp:textbox>
                            </div>
</div>
<div class="form-group">
                            <label class="col-sm-2 control-label" for="txtpwd">Password</label>
                            <div class="col-sm-10">
                                <asp:textbox class="form-control" id="PasswordTextBox" placeholder="Password" runat="server" textmode="Password"></asp:textbox>
                            </div>
</div>
<div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:label cssclass="col-form-label-lg" id="Mensaje" runat="server"></asp:label>
                            </div>
</div>
<div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:button cssclass="btn btn-success" id="btnLogin" OnClick="EntrarButton_Click" runat="server" text="ENTRAR">
                            </asp:button></div>
</div>
</div>
</div>
</div>
</div>
    </form>
</body>
</html>
