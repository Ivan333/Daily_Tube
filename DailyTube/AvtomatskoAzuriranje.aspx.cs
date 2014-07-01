using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace DailyTube
{
    public partial class AvtomatskoAzuriranje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
                OracleConnection oCon = new OracleConnection(conString);
                string sajt = "YouTube";
                string selectKanal = "select * from \"Kanali_od_sajtovi\" where sajt_ime = '" + sajt + "'";
                try
                {
                    oCon.Open();
                    OracleCommand oCommand = new OracleCommand(selectKanal, oCon);
                    oCommand.CommandType = CommandType.Text;
                    OracleDataReader oReader = oCommand.ExecuteReader();
                    while (oReader.Read())
                    {

                        DropDownList1.Items.Add(new ListItem(oReader["kanal_ime"].ToString(), oReader["kanal_id"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    oCon.Close();
                }
            }
        }
        private void fillRSS(string channel, int days)
        {
            List<Feeds> feeds = new List<Feeds>();
            XDocument xDoc = new XDocument();
            xDoc = XDocument.Load("http://www.youtube.com/rss/user/"+ channel+ "/feed.rss");
            var items = (from x in xDoc.Descendants("item")
                         select new
                         {
                             title = x.Element("title").Value,
                             link = x.Element("link").Value,
                             pubDate = DateTime.Parse(x.Element("pubDate").Value)
                         });
            if (items != null)
            {
                foreach (var i in items)
                {
                    Feeds f = new Feeds
                    {
                        Title = i.title,
                        Link = i.link,
                        Date = i.pubDate.ToString()
                    };
                    if((DateTime.Now - i.pubDate).TotalDays <= days)
                    feeds.Add(f);
                }
            }
            GridView1.DataSource = feeds;
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label3.Text = "";
            Panel2.CssClass = "";
            string channel = "";
            if (DropDownList1.SelectedIndex == 1)
                channel = "JustForLaughsTV";
            else if (DropDownList1.SelectedIndex == 5)
                channel = "DiscoveryNetworks";
            else if (DropDownList1.SelectedIndex == 6)
                channel = "Paramount";
            else if (DropDownList1.SelectedIndex == 4)
                channel = "AndroidAuthority";
            else
                channel = DropDownList1.SelectedItem.Text.Replace(" ", "");
            fillRSS(channel, Convert.ToInt32(DropDownList2.SelectedValue));
            Button1.Enabled = true;
            if(GridView1.Rows.Count == 0)
            {
                Label3.Text = "Не постојат видеа со избраното време на објава.";
                Panel2.CssClass = "uk-alert uk-alert-warning";
                Button1.Enabled = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string sajt = "YouTube";
            try
            {
                oCon.Open();
                OracleCommand cmd;
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    string naslov = gvr.Cells[0].Text;
                    string[] tmp = gvr.Cells[1].Text.Split('&');
                    string urlVideo = tmp[0];
                    string kanal = DropDownList1.SelectedItem.Text;
                    string kategorija = "";
                    string kategorijaID = "0";
                    if (kanal == "Robbaz" || kanal == "LetsPlay")
                    {
                        kategorija = "Gaming";
                        kategorijaID = "1";
                    }
                    else if (kanal == "kipkay" || kanal == "Android Authority")
                    {
                        kategorija = "Science&Technology";
                        kategorijaID = "3";
                    }
                    else if (kanal == "Just For Laughs Gags")
                    {
                        kategorija = "Comedy";
                        kategorijaID = "2";
                    }
                    else if (kanal == "Discovery")
                    {
                        kategorija = "Entertainment";
                        kategorijaID = "4";
                    }
                    else if (kanal == "Paramount Pictures" || kanal == "movieclips")
                    {
                        kategorija = "Film&Animation";
                        kategorijaID = "5";
                    }
                    tmp = urlVideo.Split('=');
                    string urlSlika = "http://i1.ytimg.com/vi/" + tmp[1] + "/mqdefault.jpg";
                    string kanalId = DropDownList1.SelectedValue.ToString();
                    string sajtId = "1";
                    string insertVideo = "insert into video (video_id, video_naslov, br_pregledi, video_url, video_rejting, kategorija_id, sajt_id, kanal_id, opis, slika, data) values (seq_video.NEXTVAL, '"
                + naslov + "', " + "0, '" + urlVideo + "', 0, " + kategorijaID + ", " + "1" + ", " + kanalId + ", '" + "" + "', '" + urlSlika + "', sysdate)";
                    cmd = new OracleCommand(insertVideo, oCon);
                    cmd.ExecuteNonQuery();
                    string insertTag = "insert into tagovi values (seq_video.CURRVAL, :tagovi)";
                    string cleared = naslov.Replace("(", "");
                    cleared = naslov.Replace(")", "");
                    cleared = naslov.Replace("-", "");
                    string tagovi = cleared.Replace(" ", ", ");
                    cmd = new OracleCommand(insertTag, oCon);
                    cmd.Parameters.AddWithValue("tagovi", tagovi.ToLower());
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                oCon.Close();
                Label1.Text = "Базата е успешно ажурирана.";
                Panel1.CssClass = "uk-alert uk-alert-success";
            }
        }
    }
}