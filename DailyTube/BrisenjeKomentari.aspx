<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BrisenjeKomentari.aspx.cs" Inherits="DailyTube.BrisenjeKomentari" %>
<%@ MasterType VirtualPath="~/AdminMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server"><asp:Label ID="lblPoraka" runat="server"></asp:Label></asp:Panel>
    <div class="uk-panel uk-panel-box uk-panel-box-primary" style="margin-top: 49px"><h3 class="uk-panel-title uk-text-center">ПРЕГЛЕД И БРИШЕЊЕ КОМЕНТАРИ</h3></div>
        <div class="uk-grid" style="margin-top:-4px">
           <div class="uk-width-1-1">
               <div class="uk-panel uk-panel-box">
                   <asp:Panel ID="Panel2" runat="server">
                       <asp:Label ID="Label3" runat="server"></asp:Label>
                   </asp:Panel>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" CssClass="centeredTable" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="komentar_id">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="username" HeaderText="Корисник" />
            <asp:BoundField DataField="komentar" HeaderText="Коментар" />
            <asp:BoundField DataField="data" HeaderText="Дата" />
            <asp:CommandField ButtonType="Image" DeleteText="Избриши" ShowDeleteButton="True" DeleteImageUrl="~/images/rsz_comment-delete-icon.png" HeaderText="Избриши" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" CssClass="tableHeader" Font-Size="Smaller" />
       <PagerSettings FirstPageText="Прва" LastPageText="Последна" Mode="NextPreviousFirstLast" NextPageImageUrl="~/images/rsz_rightarrow.png" NextPageText="" PreviousPageImageUrl="~/images/rsz_left_arrow.png" PreviousPageText="" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="tableHeader" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
                   </div>
           </div>
    </div>
</asp:Content>