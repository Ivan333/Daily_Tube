using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;

namespace DailyTube
{
    public partial class OmileniVidea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.CssClass = "";
            Label1.Text = "";
            if (Session["imeK"] == null)
            {
                Response.Redirect("Najava.aspx");
            }
            if (!IsPostBack)
            {
                string ime = Session["imeK"].ToString();
                string commandText = "select * from \"Omileni_videa_na_korisnici\" where username = '" + ime + "'";
                string tip = "kanal_ime";
                GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
                g.generate(commandText, tip, true, Label1, Panel2, "omileno");
            }
        }
        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
            string s = tbSearch.Text.Replace(" ", "%");
            string query = "select * from \"Videa_so_tagovi\" natural join \"Omileni_videa_na_korisnici\" where tag like '%" + s.ToLower()
                + "%' and username = '" + Session["imeK"].ToString() + "'";
            string kat = "kanal_ime";
            g.generate(query, kat, true, Label1, Panel2);
        }
    }
}