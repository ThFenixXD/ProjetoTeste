<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_Login.aspx.cs" Inherits="ProjetoTeste.Pages.Page_Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com" rel="preconnect" />
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet" />
    <link href="../CSS/style.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <asp:Panel ID="pnlLogin" CssClass="pnlLogin" runat="server">

            <h2 class="loginTitle">GCA</h2>

            <div class="pnlLogin_info">
                <telerik:RadLabel ID="lbLogin" runat="server" Text="Login"></telerik:RadLabel>
                <telerik:RadTextBox ID="txtLogin" Width="100%" runat="server"></telerik:RadTextBox>
            </div>

            <div class="pnlLogin_info">
                <telerik:RadLabel ID="lbSenha" runat="server" Text="Senha"></telerik:RadLabel>
                <telerik:RadTextBox ID="txtSenha" Width="100%" runat="server"></telerik:RadTextBox>
            </div>

            <div class="loginButton">
                <telerik:RadButton ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></telerik:RadButton>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
