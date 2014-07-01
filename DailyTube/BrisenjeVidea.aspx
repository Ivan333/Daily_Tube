<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BrisenjeVidea.aspx.cs" Inherits="DailyTube.BrisenjeVidea" %>
<%@ MasterType VirtualPath="~/AdminMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server"><asp:Label ID="lblPoraka" runat="server"></asp:Label></asp:Panel>
     <div class="uk-panel uk-panel-box uk-panel-box-primary" style="margin-top: 49px"><h3 class="uk-panel-title uk-text-center">ПРЕГЛЕД И БРИШЕЊЕ ВИДЕА</h3></div>
       <div class="uk-grid" style="margin-top:-4px">
           <div class="uk-width-1-1">
               <div class="uk-panel uk-panel-box">
                   <div class="uk-form"><span>Пребарај:&nbsp;&nbsp;&nbsp;</span><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>Пребарај според дата на објава:&nbsp;&nbsp;&nbsp;</span><div class="uk-button-dropdown" data-uk-dropdown=""><button class="uk-button">Календар <i class="uk-icon-caret-down"></i></button><div class="uk-dropdown" style="width: 230px"><asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged">
                       <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                       <NextPrevStyle VerticalAlign="Bottom" />
                       <OtherMonthDayStyle ForeColor="#808080" />
                       <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                       <SelectorStyle BackColor="#CCCCCC" />
                       <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                       <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                       <WeekendDayStyle BackColor="#D7E4F4" />
                       </asp:Calendar></div></div>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Прикажи ги сите видеа</asp:LinkButton>
                  </div><br />
                   <asp:Panel ID="Panel2" runat="server">
                       <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                   </asp:Panel>
                   <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" CssClass="centeredTable" PageSize="5" DataKeyNames="video_id" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDeleted="GridView1_RowDeleted" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:ImageField DataImageUrlField="slika" ReadOnly="True">
                <ControlStyle Height="110px" Width="185px" />
                <HeaderStyle CssClass="tableHeader" />
                <ItemStyle Width="185px" />
            </asp:ImageField>
            <asp:BoundField DataField="video_naslov" HeaderText="Наслов" SortExpression="video_naslov">
            <ControlStyle Height="110px" Width="185px" />
            <HeaderStyle CssClass="tableHeader" Font-Underline="True" />
            </asp:BoundField>
            <asp:BoundField DataField="opis" HeaderText="Опис">
            <HeaderStyle CssClass="tableHeader" />
            </asp:BoundField>
            <asp:BoundField DataField="tag" HeaderText="Клучни зборови" ReadOnly="True">
            <HeaderStyle CssClass="tableHeader" />
            </asp:BoundField>
            <asp:BoundField DataField="data" HeaderText="Дата" SortExpression="data" ReadOnly="True">
            <HeaderStyle CssClass="tableHeader" Font-Underline="True" />
            </asp:BoundField>
            <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteText="Избриши" DeleteImageUrl="~/images/rsz_removepct20frompct20database.png" HeaderText="Избриши" >
            <HeaderStyle CssClass="tableHeader" />
            </asp:CommandField>
            <asp:CommandField CancelText="Откажи" DeleteText="" EditText="Промени" ShowEditButton="True" UpdateText="Ажурирај" >
            <HeaderStyle CssClass="tableHeader" />
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Small" />
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