using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class GledanjeNaVidea : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnOmleno.Visible = false;
            btnTrgniOmileno.Visible = false;
            idvideo.Attributes.Add("style", "display: none");
            RadioButtonList1.Style.Add("float", "left");
            Label3.Attributes.Add("style", "float: right; margin-right: 11px; font-size: 11px");
            Label4.Attributes.Add("style", "float: right; margin-right: 11px; font-size: 11px");
            if (Session["idK"] == null)
            {
                Panel4.Attributes.Add("style", "display: none");
                return;
            }
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!url.Contains("OmileniVidea.aspx"))
            {
                btnOmleno.Visible = true;
            }
            if (url.Contains("OmileniVidea.aspx"))
            {
                btnTrgniOmileno.Visible = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            string commandText = "SELECT * FROM \"VideoSpoenoSoKorisnikIKomentar\" WHERE video_id = " + idvideo.Text;
            OracleConnection oc = new OracleConnection(conStr);
            OracleCommand ocmd = new OracleCommand(commandText, oc);
            OracleDataAdapter oda = new OracleDataAdapter(ocmd);
            DataSet ds = new DataSet();
            Panel p = new Panel();
            p.Height = 170;
            p.ScrollBars = ScrollBars.Vertical;
            try
            {
                oc.Open();
                oda.Fill(ds, "Tab");
            }
            catch (Exception err)
            {
                Label l = new Label();
                l.Text = err.ToString();
                UpdatePanel1.ContentTemplateContainer.Controls.Add(l);
                oc.Close();
                return;
            }
            finally
            {
                oc.Close();
            }
            if (ds.Tables["Tab"].Rows.Count == 0)
            {
                Label l = new Label();
                l.Text = "Нема коментари";
                UpdatePanel1.ContentTemplateContainer.Controls.Add(l);
                return;
            }
            foreach (DataRow r in ds.Tables["Tab"].Rows)
            {
                Label l = new Label();
                l.Text = "<span style='font-weight: bold; color: #39F'>" + r["username"] + "</span>" + "&nbsp;&nbsp;&nbsp;&nbsp;<span style='color: #585858; font-size: 11px;'>" + r["data"].ToString() + "</span><br />" + r["komentar"].ToString() + "<hr /><br />";
                p.Controls.Add(l);
            }
            UpdatePanel1.ContentTemplateContainer.Controls.Add(p);
        }

        protected void btnAddC_Click(object sender, EventArgs e)
        {
            TextBox label = idvideo;
            string korisnik_id = Session["idK"].ToString();
            string video_id = label.Text;
            string commnet = TextBox1.Text;
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string insertUser = "insert into komentar (komentar_id, video_id, data, korisnik_id ,komentar) values (seq_komentar.NEXTVAL, "
                + video_id + ", " + "sysdate" + ", " + int.Parse(Session["idK"].ToString()) + ", '" + commnet + "')";
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                mojEror.Text = "Коментарот е успешно внесен";
                mojEror.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                mojEror.Text = ex.Message;
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            string commandText = "select seq_rejting.nextval from rejting";
            OracleConnection oCon = new OracleConnection(conString);
            OracleCommand ocmd = new OracleCommand(commandText, oCon);
            OracleDataAdapter oda = new OracleDataAdapter(ocmd);
            DataSet ds = new DataSet();
            try
            {
                oCon.Open();
                oda.Fill(ds, "Tabela");
            }
            catch (Exception err)
            {
                rejtEror.Text = err.ToString();
            }
            string cmddd = "select * from dava_rejting where korisnik_id = " + int.Parse(Session["idK"].ToString()) + " and video_id = " + int.Parse(idvideo.Text);
            OracleCommand cmd3 = new OracleCommand(cmddd, oCon);
            oda = new OracleDataAdapter(cmd3);
            oda.Fill(ds, "Prov");
            string rejting_id = null;
            if (ds.Tables["Prov"].Rows.Count >= 1)
            {
                foreach (DataRow d in ds.Tables["Prov"].Rows)
                {
                    rejting_id = d["rejting_id"].ToString();
                    break;
                }
                string sqlUpdaite = "UPDATE rejting SET rejting = " + int.Parse(RadioButtonList1.SelectedValue) + "   WHERE rejting_id = " + rejting_id + " and video_id = " + int.Parse(idvideo.Text);
                try
                {
                    OracleCommand oCommand = new OracleCommand(sqlUpdaite, oCon);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();
                    rejtEror.Text = "Рејтингот е успешно додаден";
                }
                catch (Exception ex)
                {
                    rejtEror.Text = ex.Message;
                    throw;
                }
                finally
                {
                    oCon.Close();

                }
                return;
            }
            foreach (DataRow d in ds.Tables["Tabela"].Rows)
            {
                rejting_id = d["nextval"].ToString();
                break;
            }
            if (rejting_id == null)
                return;
            string insertUser = "insert into rejting (rejting_id, video_id, rejting) values ( " + rejting_id + ", "
                + int.Parse(idvideo.Text) + ", " + int.Parse(RadioButtonList1.SelectedValue) + ")";
            string insertUser2 = "insert into dava_rejting (rejting_id, video_id, korisnik_id) values ( " + rejting_id + ", "
                + int.Parse(idvideo.Text) + ", " + int.Parse(Session["idK"].ToString()) + ")";
            try
            {
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                OracleCommand c2 = new OracleCommand(insertUser2, oCon);
                c2.CommandType = CommandType.Text;
                c2.ExecuteNonQuery();
                rejtEror.Text = "Рејтингот е успешно додаден";
                rejtEror.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                rejtEror.Text = ex.Message;
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void Омилено_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string korisnik_id = Session["idK"].ToString();
            string video_id = idvideo.Text;
            string insertUser = "insert into ima_omileno (korisnik_id ,video_id) values ("
                + korisnik_id + ", " + video_id + ")";
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                omilenoErr.Text = "Видеото сега е омилено";
                omilenoErr.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                omilenoErr.Text = "Ова видео веќе е омилено";
                omilenoErr.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void btnTrgniOmileno_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string korisnik_id = Session["idK"].ToString();
            string video_id = idvideo.Text;
            string insertUser = "Delete FROM ima_omileno where korisnik_id = " + korisnik_id + "AND video_id = " + video_id;
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                omilenoErr.Text = "Видеото е отстрането од омилени";
                omilenoErr.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                omilenoErr.Text = ex.Message;
                omilenoErr.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void incrimetViews_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string korisnik_id = Session["imeK"].ToString();
            string video_id = idvideo.Text;
            string insertUser = "BEGIN UPDATE video SET br_pregledi = br_pregledi + 1 WHERE video_id = " + video_id + "; COMMIT; END;";
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            iframek.Src = TextBox2.Text;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            iframek.Src = "";
            Label2.Text = "";
            lblPregledi.Text = "";
            omilenoErr.Text = "";
            mojEror.Text = "";
        }
    }
}