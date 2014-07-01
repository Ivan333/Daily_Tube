<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DodavanjeVideo.aspx.cs" Inherits="DailyTube.DodavanjeVideo" %>
<%@ MasterType VirtualPath="~/AdminMaster.Master" %>
    
        <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Panel ID="Panel2" runat="server"><asp:Label ID="lblDodavanjeVideoErr" runat="server"></asp:Label></asp:Panel>
       <div class="uk-panel uk-panel-box uk-panel-box-primary" style="margin-top: 49px; margin-left: 30%; width: 40%"><h3 class="uk-panel-title uk-text-center">ДОДАВАЊЕ НОВО ВИДЕО</h3></div>
    <div class="uk-panel uk-panel-box" style="margin-top:-4px; margin-left: 30%; width: 40%">
        <div class="uk-form uk-form-horizontal">
            <div class="uk-form-row">
                <label class="uk-form-label" for="txtNaslovVideo">Наслов</label>
                <div class="uk-form-controls">
                <asp:TextBox ID="txtNaslovVideo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNaslovVideo" CssClass="uk-alert uk-alert-danger" ErrorMessage="Внесете наслов на видеото"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="uk-form-row">
                <label class="uk-form-label" for="txtUrlVideo">URL</label>
                <div class="uk-form-controls">
                <asp:TextBox ID="txtUrlVideo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUrlVideo" CssClass="uk-alert uk-alert-danger" ErrorMessage="Внесете URL на видеото"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="uk-form-row">
                <label class="uk-form-label" for="ddlSajt">Сајт</label>
                <div class="uk-form-controls">
                <asp:DropDownList ID="ddlSajt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSajt_SelectedIndexChanged">
                    <asp:ListItem>-Сајт-</asp:ListItem>
                <asp:ListItem Value="1">YouTube</asp:ListItem>
                <asp:ListItem Value="2">Dailymotion</asp:ListItem>
                <asp:ListItem Value="3">Vimeo</asp:ListItem>
            </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSajt" CssClass="uk-alert uk-alert-danger" ErrorMessage="Изберете сајт" InitialValue="-Сајт-"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="uk-form-row">
                <label class="uk-form-label" for="ddlKanal">Канал</label>
                <div class="uk-form-controls">
                <asp:DropDownList ID="ddlKanal" runat="server">
            </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlKanal" CssClass="uk-alert uk-alert-danger" ErrorMessage="Изберете канал"></asp:RequiredFieldValidator>
                </div>
            </div>
              <div class="uk-form-row">
                <label class="uk-form-label" for="ddlKategorija">Категорија</label>
                <div class="uk-form-controls">
                <asp:DropDownList ID="ddlKategorija" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlKategorija" CssClass="uk-alert uk-alert-danger" ErrorMessage="Изберете категорија"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="uk-form-row">
                <label class="uk-form-label" for="txtUrlSlika">URL на слика</label>
                <div class="uk-form-controls">
                <asp:TextBox ID="txtUrlSlika" runat="server" OnTextChanged="txtUrlSlika_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUrlSlika" CssClass="uk-alert uk-alert-danger" ErrorMessage="Внесете URL на сликата"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="uk-form-row">
                <asp:Image ID="imgVideoSlika" runat="server" Height="101px" Width="166px" OnLoad="imgVideoSlika_Load" />
            </div>
             <div class="uk-form-row">
                <label class="uk-form-label" for="txtOpisVideo">Опис</label>
                <div class="uk-form-controls">
                <asp:TextBox ID="txtOpisVideo" runat="server" TextMode="MultiLine" Height="124px" Width="255px"></asp:TextBox>
                </div>
            </div>
            <div class="uk-form-row" style="margin-left: 50%">
                <asp:Button ID="btnDodadiVideo" runat="server" OnClick="btnDodadiVideo_Click" CssClass="uk-button uk-button-success" Text="Додади"/>
            </div>
        </div>
    </div>
        </asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
        .auto-style3 {
            text-align: right;
            height: 54px;
        }
        .auto-style4 {
            height: 54px;
        }
        .auto-style5 {
            text-align: left;
            height: 54px;
        }
        .auto-style6 {
            text-align: right;
            height: 47px;
        }
        .auto-style7 {
            height: 47px;
        }
        .auto-style8 {
            text-align: left;
            height: 47px;
        }
    </style>
</asp:Content>