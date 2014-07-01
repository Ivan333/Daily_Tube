using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class BrisenjeVidea : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["imeK"] != null)
                this.Master.lblUser_Text = Session["imeK"].ToString();
            if (!IsPostBack)
            {
                OracleConnection oCon = new OracleConnection(conString);
                string selectSql = "select * from video join tagovi on video.video_id = tagovi.video_id";
                try
                {
                    oCon.Open();
                    OracleCommand com = new OracleCommand(selectSql, oCon);
                    OracleDataAdapter adapter = new OracleDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "video");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    ViewState["dataset"] = ds;
                }
                catch (Exception ex)
                {
                    lblPoraka.Text = "Се случи грешка при комуникација со базата на податоци\n" + ex.Message;
                    Panel1.Attributes.Add("class", "porakaError");
                }
                finally
                {
                    oCon.Close();
                }
            }
        }
        private DataSet getData()
        {
            OracleConnection oCon = new OracleConnection(conString);
                string selectSql = "select * from video join tagovi on video.video_id = tagovi.video_id";
                DataSet ds = null;
                try
                {
                    oCon.Open();
                    OracleCommand com = new OracleCommand(selectSql, oCon);
                    OracleDataAdapter adapter = new OracleDataAdapter(com);
                    ds = new DataSet();
                    adapter.Fill(ds, "video");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    ViewState["dataset"] = ds;
                }
                catch (Exception ex)
                {
                    lblPoraka.Text = "Се случи грешка при комуникација со базата на податоци\n" + ex.Message;
                    Panel1.Attributes.Add("class", "porakaError");
                }
                finally
                {
                    oCon.Close();
                }
                return ds;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataSet)ViewState["dataset"];
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            OracleConnection oCon = new OracleConnection(conString);
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string deleteKom = "delete from komentar where video_id = " + id;
            string deleteTag = "delete from tagovi where video_id = " + id;
            string deleteOmil = "delete from ima_omileno where video_id = " + id;
            string deleteRejting = "delete from rejting where video_id = " + id;
            string deleteVideo = "delete from video where video_id = " + id;
            DataSet ds = new DataSet();
             try
                {
                    oCon.Open();
                    OracleCommand cmd = new OracleCommand(deleteKom, oCon);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand(deleteOmil, oCon);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand(deleteRejting, oCon);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand(deleteTag, oCon);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand(deleteVideo, oCon);
                    cmd.ExecuteNonQuery();
                    GridView1.DataSource = getData();
                     GridView1.DataBind();
                    lblPoraka.Text = "Видеото е успешно избришано";
                    Panel1.CssClass = "uk-alert uk-alert-success";
                }
             catch (Exception ex)
             {
                 lblPoraka.Text = "Се случи грешка при комуникација со базата на податоци\n" + ex.Message;
                 Panel1.CssClass = "uk-alert uk-alert-danger";
             }

             finally
             {
                 oCon.Close();
             }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["dataset"];
            DataView dv = ds.Tables[0].DefaultView;
            if (ViewState["nasoka"] == null)
                ViewState["nasoka"] = "ASC";
            if ((string)ViewState["nasoka"] == "DESC")
            {
                dv.Sort = e.SortExpression + " DESC";
                ViewState["nasoka"] = "ASC";
            }
            else
            {
                dv.Sort = e.SortExpression + " ASC";
                ViewState["nasoka"] = "DESC";
            }
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        private void prebaraj(string s, string date)
        {
            Panel2.CssClass = "";
            Label1.Text = "";
            OracleConnection oCon = new OracleConnection(conString);
            string str = s.Replace(" ", "%");
            string selectSql;
            if (date == "" && s!="")
                selectSql = "select * from video join tagovi on video.video_id = tagovi.video_id where tag like '%" + str.ToLower() + "%'";
            else if(s == "" && date!="")
                selectSql = "select * from video join tagovi on video.video_id = tagovi.video_id where to_char(data) = to_char(to_date('" + date + "', 'MM/DD/YYYY'))";
            else
                selectSql = "select * from video join tagovi on video.video_id = tagovi.video_id";
            try
            {
                oCon.Open();
                OracleCommand com = new OracleCommand(selectSql, oCon);
                OracleDataAdapter adapter = new OracleDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "video");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                ViewState["dataset"] = ds;
                if(GridView1.Rows.Count == 0 && s=="")
                {
                    Label1.Text = "Не постојат видеа објавени на " + date;
                    Panel2.CssClass = "uk-alert uk-alert-warning";
                }

            }
            catch (Exception ex)
            {
                lblPoraka.Text = "Се случи грешка при комуникација со базата на податоци\n" + ex.Message;
                Panel1.Attributes.Add("class", "porakaError");
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            prebaraj(TextBox1.Text, "");
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            int m = Calendar1.SelectedDate.Month;
            int d = Calendar1.SelectedDate.Day;
            int y = Calendar1.SelectedDate.Year;
            string mo;
            string da;
            if (m >= 10)
                mo = m.ToString();
            else
                mo = "0" + m.ToString();
            if (d >= 10)
                da = d.ToString();
            else
                da = "0" + d.ToString();
            string ye = y.ToString();
            prebaraj("", mo + "/" + da + "/" + ye);
          
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            prebaraj("", "");
        }
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            prebaraj("", "");
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["dataset"];
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["dataset"];
            GridView1.EditIndex = -1;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OracleConnection oCon = new OracleConnection(conString);
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string query = "update video set opis = :opis, video_naslov = :naslov where video_id = :id";
            OracleCommand com = new OracleCommand(query, oCon);
            TextBox tb = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            com.Parameters.AddWithValue("naslov", tb.Text);
            tb = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            com.Parameters.AddWithValue("opis", tb.Text);
            com.Parameters.AddWithValue("id", id);
            int efekt = 0;
            try
            {
                oCon.Open();
                efekt = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblPoraka.Text = "Се случи грешка при комуникација со базата на податоци\n" + ex.Message;
                Panel1.Attributes.Add("class", "porakaError");
            }
            finally
            {
                oCon.Close();
                GridView1.EditIndex = -1;
            }
            if (efekt != 0)
            {
                GridView1.DataSource = getData();
                GridView1.DataBind();
                lblPoraka.Text = "Видеото е успешно ажурирано";
                Panel1.CssClass = "uk-alert uk-alert-success";
            }
        }
    }
}