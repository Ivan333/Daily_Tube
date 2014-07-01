using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class Kanali : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Panel2.CssClass = "";
            if (!IsPostBack)
            {
                GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
                string commandText = "select * from \"VideoSoKanal\" order by KANAL_IME";
                string kat = "KANAL_IME";

                g.generate(commandText, kat, true);
            }
        }
        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
            string s = tbSearch.Text.Replace(" ", "%");
            string query = "select * from \"VideoSoKanal\" where lower(kanal_ime) like '%" + s.ToLower() + "%'";
            string kat = "kanal_ime";
            g.generate(query, kat, true, Label1, Panel2);
        }
    }
}