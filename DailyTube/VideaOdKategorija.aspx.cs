using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class VideaOdKategorija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Panel2.CssClass = "";
            if (!IsPostBack && Request.UrlReferrer != null)
            {
                Session["RefUrl"] = Request.UrlReferrer.ToString();
            }
            if (!IsPostBack)
            {
                GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
                string commandText = "select * from \"Videa_so_kategorii\" where kategorija_ime = '" + Request.QueryString["katIme"] + "'";
                string kat = "kategorija_ime";
                g.generate(commandText, kat, false);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            object refUrl;
            refUrl = Session["RefUrl"];
            if (refUrl != null)
            {
                Label1.Text = (string)refUrl;
                Response.Redirect((string)refUrl);
            }
        }
        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
            string s = tbSearch.Text.Replace(" ", "%");
            string query = "select * from \"Videa_so_tagovi\" natural join \"Videa_so_kategorii\" where kategorija_ime = '" + Request.QueryString["katIme"]
                + "' and tag like '%" + s.ToLower() + "%'";
            string kat = "kategorija_ime";
            g.generate(query, kat, true, Label1, Panel2);
        }
    }
}