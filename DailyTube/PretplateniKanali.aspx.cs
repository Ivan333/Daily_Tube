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
    public partial class PretplateniKanali : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.CssClass = "";
            if (Session["imeK"] == null)
            {
                Response.Redirect("Najava.aspx");
            }
            if (!IsPostBack)
            {
                string ime = Session["imeK"].ToString();
                string commandText = "select * from \"ZaPretplataGolemSQL\" where username = '" + ime + "' ORDER BY kanal_ime";
                string tip = "kanal_ime";
                GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
                g.generate(commandText, tip, true, Label1, Panel2, "pretplateni", Session["idK"].ToString());
            }
        }
        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            GeneriranjeNaVidea g = new GeneriranjeNaVidea(Panel1, Label1);
            string s = tbSearch.Text.Replace(" ", "%");
            string query = "select * from \"ZaPretplataGolemSQL\" where lower(kanal_ime) like '%" + s.ToLower() + "%' and username = '" + Session["imeK"].ToString() + "'";
            string kat = "kanal_ime";
            g.generate(query, kat, true, Label1, Panel2);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string korisnik_id = Session["idK"].ToString();
            string kanal_id = TextBox1.Text ;
            string insertUser = "Delete FROM pretplata where korisnik_id = " + korisnik_id + "AND kanal_id = " + kanal_id;
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                Label2.Text = "Каналот е отстранет од претплати";
                Label2.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                oCon.Close();
           }
        }
    }
}