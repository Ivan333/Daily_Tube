﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideaOdKategorija.aspx.cs" Inherits="DailyTube.VideaOdKategorija" MasterPageFile="~/SiteMaster.Master" %>

<%@ Register Src="~/GledanjeNaVidea.ascx" TagPrefix="uc1" TagName="GledanjeNaVidea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script src="http://code.jquery.com/jquery-latest.min.js"
        type="text/javascript"></script>
    <link href="SkriptsIvan/CssOvi.css" rel="stylesheet" type="text/css" />
    <link href="SkriptsIvan/CssZaPregledVidea.css" rel="stylesheet" type="text/css" />
    <script src="SkriptsIvan/skripta.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
     <span class="uk-icon-search" style="margin-top: -33px; position: absolute; margin-left: 92%; z-index: 13;"></span><div class="uk-form" style="float: right; margin-top: -40px; margin-right: 61px; position: absolute; margin-left: 80%;"><asp:TextBox ID="tbSearch" runat="server" AutoPostBack="True" OnTextChanged="tbSearch_TextChanged">Пребарај видеа...</asp:TextBox></div>
        <uc1:GledanjeNaVidea runat="server" ID="GledanjeNaVidea1" />
    <div class="giveMargin">
        <asp:Button ID="Button1" CssClass="uk-button uk-button-primary" runat="server" OnClick="Button1_Click" Text="< Назад" /><br /><br />
        <asp:Panel ID="Panel2" runat="server"><asp:Label ID="Label1" runat="server"></asp:Label></asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </div>
</asp:Content>