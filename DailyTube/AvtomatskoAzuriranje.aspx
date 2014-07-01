<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AvtomatskoAzuriranje.aspx.cs" Inherits="DailyTube.AvtomatskoAzuriranje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" runat="server"></asp:Label></asp:Panel>
    <div class="uk-panel uk-panel-box uk-panel-box-primary" style="margin-top: 49px; margin-left: 12%; width: 69%"><h3 class="uk-panel-title uk-text-center">АВТОМАТСКО ДОДАВАЊЕ ВИДЕА</h3></div>
    <div class="uk-panel uk-panel-box" style="margin-top: -4px; margin-left: 12%; width: 69%;">
        <span>Избери канал:</span>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;<span>Време на објава:</span>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">Денес</asp:ListItem>
            <asp:ListItem Value="10">Последни 10 дена</asp:ListItem>
            <asp:ListItem Value="15">Последни 15 дена</asp:ListItem>
            <asp:ListItem Value="30">Последни 30 дена</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" CssClass="uk-button uk-button-primary" Text="Прикажи" OnClick="Button2_Click" />
         &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="uk-button uk-button-success" runat="server" Text="Ажурирај ја базата" Enabled="False" OnClick="Button1_Click" /><br /><br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </asp:Panel>
        <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Наслов" >
            <HeaderStyle CssClass="tableHeader" />
            </asp:BoundField>
            <asp:BoundField DataField="Link" HeaderText="URL" >
            <HeaderStyle CssClass="tableHeader" />
            </asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Дата" >
            <HeaderStyle CssClass="tableHeader" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        <br />
        </div>
</asp:Content>
