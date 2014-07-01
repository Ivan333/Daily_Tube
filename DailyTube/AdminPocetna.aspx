<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPocetna.aspx.cs" Inherits="DailyTube.AdminPocetna" %>
<%@ MasterType VirtualPath="~/AdminMaster.Master" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Skripts/jqwidgets/styles/jqx.base.css" rel="stylesheet" type="text/css" />
    <script src="Skripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Skripts/jqwidgets/jqxcore.js" type="text/javascript"></script>
    <script src="Skripts/jqwidgets/jqxdata.js" type="text/javascript"></script>
    <script src="Skripts/jqwidgets/jqxchart.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var source1 = {
                datafields: [{ name: 'KATEGORIJA_IME' }, { name: 'ZASTAPENOST' }],
                record: "Table",
                datatype: "xml",
                url: 'AdminPocetna.aspx/GetKategorii'
            }
            var source2 = {
                datafields: [{ name: 'SAJT_IME' }, { name: 'PROC_ZASTAPENOST' }],
                record: "Table",
                datatype: "xml",
                url: 'AdminPocetna.aspx/GetSajtovi'
            }
            var dataAdapter1 = new $.jqx.dataAdapter(source1    ,
              { async: false, autoBind: true, contentType: 'application/json; charset=utf-8' }
          );
            var dataAdapter2 = new $.jqx.dataAdapter(source2,
               { async: false, autoBind: true, contentType: 'application/json; charset=utf-8' }
           );
            var settings1 = {
                title: "",
                description: "",
                enableAnimations: true,
                showLegend: true,
                legendLayout: { left: 430, top: 120, width: 100, height: 200, flow: 'vertical' },
                padding: { left: 0, top: 5, right: 5, bottom: 5 },
                titlePadding: { left: 0, top: 0, right: 0, bottom: 10 },
                source: dataAdapter1,
                colorScheme: 'scheme05',
                seriesGroups:
                        [
                            {
                                type: 'pie',
                                showLabels: true,
                                series: [{
                                    dataField: 'ZASTAPENOST',
                                    displayText: 'KATEGORIJA_IME',
                                    labelRadius: 100,
                                    initialAngle: 15,
                                    radius: 120,
                                    centerOffset: 0,
                                    formatFunction: function (value) {
                                        if (isNaN(value))
                                            return value;
                                        return parseFloat(value) + '%';
                                    },
                                }]
                            }
                        ]
            };
            var settings2 = {
                title: "",
                description: "",
                enableAnimations: true,
                showLegend: true,
                legendLayout: { left: 450, top: 160, width: 100, height: 200, flow: 'vertical' },
                padding: { left: 5, top: 5, right: 5, bottom: 5 },
                titlePadding: { left: 0, top: 0, right: 0, bottom: 10 },
                source: dataAdapter2,
                colorScheme: 'scheme06',
                seriesGroups:
                        [
                            {
                                type: 'pie',
                                showLabels: true,
                                series: [{
                                    dataField: 'PROC_ZASTAPENOST',
                                    displayText: 'SAJT_IME',
                                    labelRadius: 100,
                                    initialAngle: 15,
                                    radius: 120,
                                    centerOffset: 0,
                                    formatFunction: function (value) {
                                        if (isNaN(value))
                                            return value;
                                        return parseFloat(value) + '%';
                                    },
                                }]
                            }
                        ]
            };
            $('#jqxChart1').jqxChart(settings1);
            $('#jqxChart2').jqxChart(settings2);
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 313px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLStr %>" ProviderName="<%$ ConnectionStrings:SQLStr.ProviderName %>" SelectCommand="SELECT * FROM &quot;Zastapenost_po_kategorii&quot;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLStr %>" ProviderName="<%$ ConnectionStrings:SQLStr.ProviderName %>" SelectCommand="SELECT * FROM &quot;ProcZastNaSajtoviPoVId&quot;"></asp:SqlDataSource>
        <div style="width: 100%; margin-top: 49px; margin-bottom: 40px;text-align: center;">
             <div class="uk-grid">
                <div class ="uk-width-1-1">
                    <div class="uk-panel uk-panel-box">
                        <p class="uk-text-large uk-text-primary">А Д М И Н И С Т Р А Ц И Ј А</p>
                    </div>
                    <div class="uk-panel uk-panel-box">
                        <div class="uk-grid">
                            <div class="uk-width-1-3">
                                <div class="uk-panel uk-panel-box-primary">
                                    <h1 class="uk-panel-title">
                                        <i class="uk-icon-plus-circle"></i><br />
                                        <a href="DodavanjeVideo.aspx">Додадавање видео</a>
                                    </h1>
                                </div>
                            </div>
                            <div class="uk-width-1-3">
                                <div class="uk-panel uk-panel-box-primary">
                                    <h1 class="uk-panel-title">
                                        <i class="uk-icon-comments"></i><br />
                                        <a href="BrisenjeKomentari.aspx">Преглед на коментарите</a>
                                    </h1>
                                </div>
                            </div>
                            <div class="uk-width-1-3">
                                <div class="uk-panel uk-panel-box-primary">
                                     <h1 class="uk-panel-title">
                                        <i class="uk-icon-film"></i><br />
                                        <a href="BrisenjeVidea.aspx">Преглед на видеата</a>
                                    </h1>
                                </div>
                            </div>
                        </div>
                        <div class="uk-grid">
                            <div class="uk-width-1-3">
                                <div class="uk-panel uk-panel-box-primary">
                                    <h1 class="uk-panel-title">
                                        <i class="uk-icon-users"></i><br />
                                        <a href="PregledKorisnici.aspx">Менаџирање корисници</a>
                                    </h1>
                                </div>
                            </div>
                             <div class="uk-width-1-3">
                                <div class="uk-panel uk-panel-box-primary">
                                    <h1 class="uk-panel-title">
                                        <i class="uk-icon-refresh"></i><br />
                                        <a href="AvtomatskoAzuriranje.aspx">Автоматско додавање видеа</a>
                                    </h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="uk-grid">
                <div class="uk-width-1-1">
                    <div class="uk-panel uk-panel-box">
                        <p class="uk-text-large uk-text-primary">С Т А Т И С Т И К А</p>
                    </div>
                </div>
            </div>
        <div class="uk-grid" data-uk-grid-match="{target:'.uk-panel'}">
            <div class="uk-width-1-2">
                <div class="uk-panel uk-panel-box">
                    <p class="uk-text-bold">Застапеност на видеа по категории</p>
                    <div id='jqxChart1' style="width: 570px; height: 400px; margin-left: auto; margin-right:auto">
    </div>
                </div>
            </div>
            <div class="uk-width-1-2">
                    <div class="uk-panel uk-panel-box">
                        <p class="uk-text-bold">Застапеност на видеа по сајтови</p>
                         <div id='jqxChart2' style="width: 570px; height: 400px; margin-left: auto; margin-right:auto">
    </div>
                    </div>
                </div>
            </div>
            <div class="uk-grid" data-uk-grid-match="{target:'.uk-panel'}">
                 <div class="uk-width-1-2">
                <div class="uk-panel uk-panel-box">
                   <p class="uk-text-bold">Топ 5 видеа</p>
                     <div style="margin-left: 19%; margin-right: 19%"><asp:GridView ID="gvTopVidea" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="VIDEO_NASLOV" HeaderText="Видео" />
                <asp:BoundField DataField="REJTING" HeaderText="Рејтинг" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView></div>
                </div>
            </div>
                <div class="uk-width-1-2">
                <div class="uk-panel uk-panel-box">
                    <p class="uk-text-bold">Најкоментирани видеа</p>
                      <div style="margin-left: 19%; margin-right: 19%"><asp:GridView ID="gvNajkomentirani" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="video_naslov" HeaderText="Видео" />
                <asp:BoundField DataField="procenti" HeaderText="Kоментари" DataFormatString="{0:P1}" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView></div>
                </div>
            </div>
            </div>
        </div>
</asp:Panel>
</asp:Content>
