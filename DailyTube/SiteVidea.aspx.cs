using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;

namespace DailyTube
{
    public partial class SiteVidea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.CssClass = "";
            Label1.Text = "";
            if (!IsPostBack)
            {
                GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
                string commandText = "select * from \"Videa_so_kategorii\"";
                string kat = "kategorija_ime";
                g.generate(commandText, kat, true);
            }
        }
        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
            string s = tbSearch.Text.Replace(" ", "%");
            string query = "select * from \"Videa_so_tagovi\" natural join \"Videa_so_kategorii\" where tag like '%" + s.ToLower() + "%'";
            string kat = "kategorija_ime";
            g.generate(query, kat, true, Label1, Panel2);
        }
    }
}