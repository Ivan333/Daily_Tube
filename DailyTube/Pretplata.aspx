<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeBehind="Pretplata.aspx.cs" Inherits="DailyTube.Pretplata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="Skripts/CssOvi.css" rel="stylesheet" type="text/css" />
   <link rel="stylesheet" href="Skripts/uikit-2.6.0/css/uikit.gradient.min.css" />
        <script src="Skripts/uikit-2.6.0/js/jquery-2.1.1.min.js"></script>
        <script src="Skripts/uikit-2.6.0/js/uikit.min.js"></script>
    <style type="text/css">
        .auto-style11 {
            width: 1187px;
        }
    </style>
</head>
<body class="najavaBg">
    <form id="form1" runat="server">
        <div class="cent">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/logo.png" Height="186px" Width="485px" />
            </div>
            <br /><br /><div class="uk-alert" style="width: 63%; margin-left: 18%;">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div><br /><br /><br />
        <table align="center">
            <tr>
                <td class="auto-style11">
                     <div class="uk-grid">
                <div class="uk-width-1-4">
                    <div class="uk-panel uk-panel-box uk-panel-box-secondary" style="text-align: center">
                <asp:Button ID="btnYouTube" runat="server" CssClass="youtubeBtn" OnClick="btnYouTube_Click" /><br />
                <asp:Button ID="btnVimeo" runat="server" CssClass="vimeoBtn" OnClick="btnVimeo_Click" /><br />
                <asp:Button ID="btnDailyMotion" runat="server" CssClass="dmotionBtn" OnClick="btnDailyMotion_Click" /><br />
                <asp:Button ID="btnMetacafe" runat="server" CssClass="metacafeBtn" Height="66px" Width="202px" OnClick="btnMetacafe_Click" /><br />
                <asp:Button ID="btnVeoh" runat="server" CssClass="veohBtn" OnClick="btnVeoh_Click" />
                        </div>
                </div>
            <div class="uk-width-3-4">
                <div class="uk-panel uk-panel-box uk-panel-box-secondary">
                    <asp:Panel ID="Panel1" runat="server" Height="340px" ScrollBars="Auto">
                 <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="vwYouTube" runat="server">
                                <asp:CheckBoxList ID="cblYouTube" runat="server" OnSelectedIndexChanged="cblYouTube_SelectedIndexChanged" CssClass="uk-table uk-table-hover uk-table-striped uk-table-condensed">
                                </asp:CheckBoxList>
                            </asp:View>
                            <asp:View ID="vwViemo" runat="server">
                                <asp:CheckBoxList ID="cblVimeo" runat="server" OnSelectedIndexChanged="cblYouTube_SelectedIndexChanged" CssClass="uk-table uk-table-hover uk-table-striped uk-table-condensed">
                                </asp:CheckBoxList>
                            </asp:View>
                            <asp:View ID="vwDailymotion" runat="server">
                                <asp:CheckBoxList ID="cblDailymotion" runat="server" OnSelectedIndexChanged="cblYouTube_SelectedIndexChanged" style="text-align: left" CssClass="uk-table uk-table-hover uk-table-striped uk-table-condensed">
                                </asp:CheckBoxList>
                            </asp:View>
                            <asp:View ID="vwMetacafe" runat="server">
                                <asp:CheckBoxList ID="cblMetacafe" runat="server" OnSelectedIndexChanged="cblYouTube_SelectedIndexChanged" style="text-align: left" CssClass="uk-table uk-table-hover uk-table-striped uk-table-condensed">
                                </asp:CheckBoxList>
                            </asp:View>
                            <asp:View ID="vwVeoh" runat="server">
                                <asp:CheckBoxList ID="cblVeoh" runat="server" OnSelectedIndexChanged="cblYouTube_SelectedIndexChanged" CssClass="uk-table uk-table-hover uk-table-striped uk-table-condensed">
                                </asp:CheckBoxList>
                            </asp:View>
                        </asp:MultiView>
                        </asp:Panel>
                    </div>
            </div>
                </div>
                    <br />
                </td>
            </tr>
            <tr style="text-align: right">
                <td class="auto-style11"><div class="uk-grid">
                <div class="uk-width-1-1">
                    <asp:Button ID="Button1" runat="server" CssClass="uk-button uk-button-primary" Text="Продолжи без претплата" OnClick="Button1_Click" />
                <asp:Button ID="btnPretplatiSe" CssClass="uk-button uk-button-success " runat="server" OnClick="btnPretplatiSe_Click" Text="Претплати се"/>
                    </div>
            </div></td>
            </tr>
        </table>
    </form>
</body>
</html>