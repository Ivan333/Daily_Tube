<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="WebApplication4.Najava" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link href="Skripts/CssOvi.css" rel="stylesheet" type="text/css" />
   <link rel="stylesheet" href="Skripts/uikit-2.6.0/css/uikit.gradient.min.css" />
        <script src="Skripts/uikit-2.6.0/js/jquery-2.1.1.min.js"></script>
        <script src="Skripts/uikit-2.6.0/js/uikit.min.js"></script>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 60px;
        }
        .auto-style2 {
            height: 53px;
        }
        .auto-style3 {
            height: 52px;
        }
        .auto-style4 {
            height: 54px;
        }
        .auto-style5 {
            height: 48px;
        }
    </style>
</head>
<body class="najavaBg">
    <form id="form1" runat="server">
        <div class="cent uk-animation-scale-down">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.png" Height="186px" Width="485px" />
            </div>
        <asp:Panel ID="Panel3" runat="server"><asp:Label ID="lblPoraka" runat="server"></asp:Label></asp:Panel>
            <div class="centrir1">
                <asp:Panel ID="Panel1" runat="server" CssClass="najavaBox">
           <div class="uk-form">
    <fieldset data-uk-margin>
        <div class="uk-form-row" style="margin-bottom: -19px;"><h4 style="color: black">Корисничко име</h4></div>
        <div class="uk-form-row"><asp:TextBox ID="tbIme" runat="server"></asp:TextBox></div>
        <div class="uk-form-row" style="margin-bottom: -19px;"><h4 style="color: black">Лозинка</h4></div>
        <div class="uk-form-row" style="margin-top: 0px"><asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox></div><br />
        <div class="uk-form-row"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="uk-button uk-button-success" Text="Најави се" /></div>
    </fieldset>
</div>     
                </asp:Panel><br />
                <asp:Panel ID="Panel2" runat="server" CssClass="najavaBox">
  <div class="uk-form">
    <fieldset data-uk-margin style="margin-top: -24px;">
        <div class="uk-form-row" style="margin-bottom: -19px;"><h4 style="color: black">Корисничко име</h4></div>
        <div class="uk-form-row"><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></div>
        <div class="uk-form-row" style="margin-bottom: -23px;"><h4 style="color: black">Лозинка</h4></div>
        <div class="uk-form-row" style="margin-top: 0px"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></div>
        <div class="uk-form-row" style="margin-bottom: -19px;"><h4 style="color: black">E-mail</h4></div>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <div class="uk-form-row" style="padding-top: 13px"><asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" CssClass="uk-button uk-button-success" Text="Регистрирај се" /></div>
    </fieldset>
</div>     
                </asp:Panel>
            </div>
    </form>
</body>
</html>