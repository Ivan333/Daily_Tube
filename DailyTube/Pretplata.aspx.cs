using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class Pretplata : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["imeK"] == null)
                Response.Redirect("Najava.aspx");
            btnYouTube.CssClass = "youtubeBtn";
            btnVimeo.CssClass = "vimeoBtn";
            btnMetacafe.CssClass = "metacafeBtn";
            btnDailyMotion.CssClass = "dmotionBtn";
            btnVeoh.CssClass = "veohBtn";
            Label1.Text = Session["imeK"].ToString() + ", сè уште се немате претплатено на ниту еден канал."
                + " Доколку сакате, тоа може да го сторите избирајќи сајт и канали од листата подолу или да се претплатите подоцна.";
        }

        public void Ispolni(string sajt, CheckBoxList cbl)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            string query = "SELECT * FROM \"Kanali_info\" WHERE sajt_ime = '" + sajt + "'";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Kanali_info");
                foreach (DataRow dr in ds.Tables[0].Rows){
                    ListItem li = new ListItem("<span style='color: black; text-transform:uppercase; font-weight:bold; font-size:14pt'>" + dr["kanal_ime"].ToString() + "</span><br /><span class='uk-badge'>Број на видеа: " + dr["br_videa"] + "</span>&nbsp&nbsp<span class='uk-badge'> Број на претплатници: " +
                        ((dr["br_pret"].ToString() != "") ? dr["br_pret"] : "0") + "</span>", dr["kanal_id"].ToString());
                    cbl.Items.Add(li);
                }
                cbl.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        protected void btnYouTube_Click(object sender, EventArgs e)
        {
            cblYouTube.Items.Clear();
            Ispolni("YouTube", cblYouTube);
            btnYouTube.CssClass = "youtubeBtnA";
            if (ViewState["cblYouTube"] != null)
            {
                foreach (int i in (List<int>)ViewState["cblYouTube"])
                    cblYouTube.Items[i].Selected = true;
            }
            MultiView1.SetActiveView(vwYouTube);
        }
        protected void btnVimeo_Click(object sender, EventArgs e)
        {
            cblVimeo.Items.Clear();
            Ispolni("Vimeo", cblVimeo);
            btnVimeo.CssClass = "vimeoBtnA";
            if (ViewState["cblVimeo"] != null)
            {
                foreach (int i in (List<int>)ViewState["cblVimeo"])
                    cblVimeo.Items[i].Selected = true;
            }
            MultiView1.SetActiveView(vwViemo);
        }
        protected void btnDailyMotion_Click(object sender, EventArgs e)
        {
            cblDailymotion.Items.Clear();
            Ispolni("Dailymotion", cblDailymotion);
            btnDailyMotion.CssClass = "dmotionBtnA";
            if (ViewState["cblDailymotion"] != null)
            {
                foreach (int i in (List<int>)ViewState["cblDailymotion"])
                    cblDailymotion.Items[i].Selected = true;
            }
            MultiView1.SetActiveView(vwDailymotion);
        }
        protected void btnMetacafe_Click(object sender, EventArgs e)
        {
            cblMetacafe.Items.Clear();
            Ispolni("Metacafe", cblMetacafe);
            btnMetacafe.CssClass = "metacafeBtnA";
            if (ViewState["cblMetacafe"] != null)
            {
                foreach (int i in (List<int>)ViewState["cblMetacafe"])
                    cblMetacafe.Items[i].Selected = true;
            }
            MultiView1.SetActiveView(vwMetacafe);
        }
        protected void btnVeoh_Click(object sender, EventArgs e)
        {
            cblVeoh.Items.Clear();
            Ispolni("Veoh", cblVeoh);
            btnVeoh.CssClass = "veohBtnA";
            if (ViewState["cblVeoh"] != null)
            {
                foreach (int i in (List<int>)ViewState["cblVeoh"])
                    cblVeoh.Items[i].Selected = true;
            }
            Label l = new Label();
            l.Text = "Во моментов не постојат канали од Veoh.";
            vwVeoh.Controls.Add(l);
            MultiView1.SetActiveView(vwVeoh);
        }
        protected void cblYouTube_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            CheckBoxList cbl = (CheckBoxList)sender;
            string id = cbl.ID;
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Selected)
                    list.Add(i);
            }
            ViewState[id] = list;
        }
        protected void btnPretplatiSe_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString);
            string sqlInsert = "INSERT INTO PRETPLATA (KORISNIK_ID, KANAL_ID, SAJT_ID) VALUES (:korisnik_id, :kanal_id, :sajt_id)";
            string userId = Request.QueryString["id"].ToString();
            OracleCommand cmd = new OracleCommand(sqlInsert, con);
            try
            {
                con.Open();
                if (ViewState["cblYouTube"] != null)
                {
                    List<int> list = (List<int>)ViewState["cblYouTube"];
                    foreach (int i in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("korisnik_id", userId);
                        cmd.Parameters.AddWithValue("kanal_id", cblYouTube.Items[i].Value);
                        cmd.Parameters.AddWithValue("sajt_id", "1");
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                if (ViewState["cblVimeo"] != null)
                {
                    List<int> list = (List<int>)ViewState["cblVimeo"];
                    foreach (int i in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("korisnik_id", userId);
                        cmd.Parameters.AddWithValue("kanal_id", cblVimeo.Items[i].Value);
                        cmd.Parameters.AddWithValue("sajt_id", "3");
                        cmd.ExecuteNonQuery();
                    }
                   
                }
                if (ViewState["cblVeoh"] != null)
                {
                    List<int> list = (List<int>)ViewState["cblVeoh"];
                    foreach (int i in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("korisnik_id", userId);
                        cmd.Parameters.AddWithValue("kanal_id", cblVeoh.Items[i].Value);
                        cmd.Parameters.AddWithValue("sajt_id", "5");
                        cmd.ExecuteNonQuery();
                    }
                    
                }
                if (ViewState["cblMetacafe"] != null)
                {
                    List<int> list = (List<int>)ViewState["cblMetacafe"];
                    foreach (int i in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("korisnik_id", userId);
                        cmd.Parameters.AddWithValue("kanal_id", cblMetacafe.Items[i].Value);
                        cmd.Parameters.AddWithValue("sajt_id", "4");
                        cmd.ExecuteNonQuery();
                    }

                }
                if (ViewState["cblDailymotion"] != null)
                {
                    List<int> list = (List<int>)ViewState["cblDailymotion"];
                    foreach (int i in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("korisnik_id", userId);
                        cmd.Parameters.AddWithValue("kanal_id", cblDailymotion.Items[i].Value);
                        cmd.Parameters.AddWithValue("sajt_id", "2");
                        cmd.ExecuteNonQuery();
                    }
                }
                Response.Redirect("SiteVidea.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteVidea.aspx");
        }
    }
}