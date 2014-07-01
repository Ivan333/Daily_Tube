<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GledanjeNaVidea.ascx.cs" Inherits="DailyTube.GledanjeNaVidea" %>



<asp:Panel ID="PnlWrap" runat="server" CssClass="pozicija">
    <asp:Panel ID="pnlInnerWrap" CssClass="innerWrp" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="Scriptmanager1" runat="server"> 
    </asp:ScriptManager>
    <asp:Panel ID="Panel3" runat="server" CssClass="inner">
        <asp:Button ID="btnClose" runat="server" Text="X" OnClientClick="return false" CssClass="exitFloat uk-close uk-close-alt " /><br />
        <asp:Panel ID="Panel8" runat="server" CssClass="Poz">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <iframe id="iframek" class="ifrejm" width="650" height="350" runat="server"></iframe>
                    <asp:Button ID="Button4" runat="server" Text="Button" CssClass="removeIframe" OnClick="Button4_Click"/>
                    <asp:Button ID="Button2" runat="server" Text="Button" CssClass="loadIframe" OnClick="Button2_Click"/>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="dispNone"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
    <br/>
        <asp:Panel ID="Panel6" runat="server" CssClass="cont">
        <asp:Panel ID="Panel1" runat="server" CssClass="">
            <asp:Label ID="lblPregledi" runat="server" CssClass="labelPregledi uk-badge uk-badge-notification"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label3" CssClass="labelVData uk-badge uk-badge-notification" runat="server"></asp:Label>
            <br />
            &nbsp;<asp:Label ID="lblVkRejting" CssClass="labelVkRejting uk-badge uk-badge-notification uk-badge-warning" runat="server"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="Label4" CssClass="labelInfo uk-badge uk-badge-notification" runat="server"></asp:Label>
            <br />
            <asp:Panel ID="Panel7" runat="server" CssClass="floatright">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnOmleno" CssClass="uk-button uk-button-danger" runat="server" Text="Омилено" OnClick="Омилено_Click" Width="88px" />
                    <asp:Button ID="btnTrgniOmileno" CssClass="uk-button uk-button-danger" runat="server" Text="Отстрани од омилени" Width="175px" OnClick="btnTrgniOmileno_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="Panel11" runat="server" CssClass="floatright">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
            <asp:Label ID="omilenoErr" runat="server" CssClass="clr1"></asp:Label>
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnOmleno" EventName="Click"/>
                    <asp:AsyncPostBackTrigger ControlID="btnTrgniOmileno" EventName="Click"/>
                </Triggers>
                </asp:UpdatePanel>
                </asp:Panel>
        </asp:Panel>
    </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" >
                <asp:Panel ID="Panel9" runat="server" >
            <asp:Label ID="Label2" runat="server" CssClass="clr2" ></asp:Label>
                    <asp:Panel ID="Panel10" runat="server">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                 <ContentTemplate>
                    <span ID="Label1" runat="server" Text="Label" class="floatleft">Оцени:</span> 
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Size="0.9em" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" CssClass="radioButtons">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="rejtEror" runat="server" CssClass="clr3"></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>
                        </asp:Panel>
        </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
            &nbsp;<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="45px" CssClass="comentBox"></asp:TextBox>
            &nbsp;<asp:Button ID="btnAddC" runat="server" CssClass="uk-button uk-button-primary" Text="Додади коментар" OnClick="btnAddC_Click" /><asp:Label ID="mojEror" runat="server"></asp:Label>
                    <asp:Button ID="incrimetViews" runat="server" Text="Button" OnClick="incrimetViews_Click" CssClass="incrimentViews" />
                     </ContentTemplate>
                </asp:UpdatePanel>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="belaPozadina">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="uk-button" Text="Прикажи коментари" OnClick="Button1_Click" Width="643px" />
                <asp:TextBox ID="idvideo" runat="server" CssClass="tbIdVideo">dsdd</asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
            </asp:Panel>
        </asp:Panel>
        </asp:Panel>
        </asp:Panel>
</asp:Panel>