<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PregledKorisnici.aspx.cs" Inherits="DailyTube.PregledKorisnici" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label4" runat="server"></asp:Label></asp:Panel>
    <div class="uk-panel uk-panel-box uk-panel-box-primary" style="margin-top: 49px"><h3 class="uk-panel-title uk-text-center">МЕНАЏИРАЊЕ КОРИСНИЦИ</h3></div>
    <div class="uk-grid" style="margin-top: -4px; margin-bottom:10px">
        <div class="uk-width-1-1">
            <div class="uk-panel uk-panel-box">
                <h3 style="margin-bottom: 0px;">Корисници</h3>
                 <span>Вкупно:&nbsp;</span><asp:Label ID="totalUsers" runat="server" Text="0" CssClass="uk-badge uk-badge-danger"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="centeredTable" AllowPaging="True" ForeColor="#333333" GridLines="None" DataKeyNames="posetitel_id" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Корисничко име">
                        <HeaderStyle CssClass="tableHeader" />
                        </asp:BoundField>
                        <asp:BoundField DataField="email" HeaderText="E-mail">
                        <HeaderStyle CssClass="tableHeader" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Приказ на коментари" ShowSelectButton="True">
                        <HeaderStyle CssClass="tableHeader" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/rsz_501301.png" ShowDeleteButton="True" HeaderText="Избриши">
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
                <div style="margin-top:20px">
                    <h3 style="margin-bottom: 0px;">Администратори</h3>
                    <span>Вкупно:&nbsp;</span><asp:Label ID="totalAdmins" runat="server" Text="0" CssClass="uk-badge uk-badge-danger"></asp:Label>
                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="centeredTable" AllowPaging="True" ForeColor="#333333" GridLines="None" DataKeyNames="posetitel_id" OnRowDeleting="GridView2_RowDeleting">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Корисничко име">
                        <HeaderStyle CssClass="tableHeader" />
                        </asp:BoundField>
                        <asp:BoundField DataField="email" HeaderText="E-mail">
                        <HeaderStyle CssClass="tableHeader" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/rsz_501301.png" ShowDeleteButton="True" HeaderText="Избриши">
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
                <div class="uk-grid">
                    <div class="uk-width-1-1">
              <div class="uk-panel uk-panel-box uk-panel-box-primary uk-width-1-2 uk-container-center uk-text-center" id="addNewAdmin" style="margin-top:10px">
                  <h3 class="uk-panel-title"><i class="uk-icon-user"></i><i class="uk-icon-plus"></i>&nbsp;&nbsp;Додадавање нов корисник<i class="uk-icon-angle-down" style="float:right"></i></h3>
              </div>
                        </div>
                    </div>
                <div class="uk-grid">
                    <div class="uk-width-1-1">
                        <div class="uk-panel uk-panel-box uk-panel-box-secondary uk-width-1-2 uk-container-center uk-text-center" id="newAdminForm" style="text-align: center; margin-top: -42px;">
                            <div class="uk-form">
    <fieldset data-uk-margin>
        <div class="uk-form-row">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="uk-alert uk-alert-danger" />
            <asp:Label ID="Label1" runat="server" Text="Корисничко име"></asp:Label></div>
        <div class="uk-form-row">
        <asp:TextBox ID="newAdminName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="uk-alert uk-alert-danger" ErrorMessage="Внесете корисничко име" ControlToValidate="newAdminName" Display="None"></asp:RequiredFieldValidator>
        </div>
         <div class="uk-form-row"><asp:Label ID="Label2" runat="server" Text="Лозинка"></asp:Label></div>
        <div class="uk-form-row">
        <asp:TextBox ID="newAdminPass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="uk-alert uk-alert-danger" ErrorMessage="Внесете лозинка" ControlToValidate="newAdminPass" Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="uk-form-row"><asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label></div>
        <div class="uk-form-row">
        <asp:TextBox ID="newAdminMail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="uk-alert uk-alert-danger" ErrorMessage="Внесете e-mail" ControlToValidate="newAdminMail" Display="None"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="newAdminMail" CssClass="uk-alert uk-alert-danger" Display="None" ErrorMessage="Внесете валидна email адреса" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <div class="uk-form-row">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow">
                <asp:ListItem Value="0">Обичен корисник</asp:ListItem>
                <asp:ListItem Value="1">Администратор</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="uk-alert uk-alert-danger" ErrorMessage="Изберете тип на корисник" ControlToValidate="RadioButtonList1" Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="uk-form-row">
            <asp:Button ID="Button1" runat="server" Text="Додади" CssClass="uk-button" OnClick="Button1_Click"/></div>
    </fieldset>
</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>