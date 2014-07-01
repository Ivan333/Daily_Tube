using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class PregledKorisnici : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ispolni(GridView1, "select * from \"Korisnici\"");
            Ispolni(GridView2, "select * from \"Administratori\"");
            totalUsers.Text = GridView1.Rows.Count.ToString();
            totalAdmins.Text = GridView2.Rows.Count.ToString();
        }
        public void Ispolni(GridView gv, string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            try
            {
                con.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Tabela");
                gv.DataSource = ds;
                gv.DataBind();
            }
            catch (Exception ex)
            {
                Label4.Text = ex.Message;
                Panel1.CssClass = "uk-alert uk-alert-danger";
            }
            finally
            {
                con.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = newAdminName.Text;
            string password = newAdminPass.Text;
            string email = newAdminMail.Text;
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string insertUser = "insert into posetitel (posetitel_id, username, password, email) values (seq_user.NEXTVAL, '"
                + username + "', '" + password + "', '" + email + "')";
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(insertUser, oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                if(RadioButtonList1.SelectedIndex == 1)
                    oCommand = new OracleCommand("insert into administrator values(seq_user.CURRVAL)", oCon);
                else
                {
                    oCommand = new OracleCommand("insert into korisnik values(seq_user.CURRVAL)", oCon);
                }
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                Ispolni(GridView1, "select * from \"Korisnici\"");
                Ispolni(GridView2, "select * from \"Administratori\"");
                totalUsers.Text = GridView1.Rows.Count.ToString();
                totalAdmins.Text = GridView2.Rows.Count.ToString();
                Label4.Text = "Корисникот е успешно додаден.";
                Panel1.CssClass = "uk-alert uk-alert-success";
            }
            catch (Exception ex)
            {
                Label4.Text = ex.Message;
                Panel1.CssClass = "uk-alert uk-alert-danger";
            }
            finally
            {
                oCon.Close();
            }
        }
        public void removeUser(string type, string id)
        {
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection oCon = new OracleConnection(conString);
            string sqlDel = "";
            string sqlDel2 = "";
            string sqlDel3 = "";
            string sqlDel4 = "";
            string sqlDel5 = "";
            if (type == "admin")
            {
                sqlDel = "delete from administrator where admin_id = " + id;
                sqlDel2 = "delete from posetitel where posetitel_id = " + id;
            }
            else
            {
                sqlDel = "delete from ima_omileno where korisnik_id = " + id;
                sqlDel2 = "delete from komentar where korisnik_id = " + id;
                sqlDel3 = "delete from pretplata where korisnik_id = " + id;
                sqlDel4 = "delete from korisnik where korisnik_id = " + id;
                sqlDel5 = "delete from posetitel where posetitel_id = " + id;
            }
            try
            {
                oCon.Open();
                OracleCommand oCommand = new OracleCommand(sqlDel, oCon);
                oCommand.ExecuteNonQuery();
                oCommand = new OracleCommand(sqlDel2, oCon);
                oCommand.ExecuteNonQuery();
                if (sqlDel3 != "" && sqlDel4 != "" && sqlDel5 != "")
                {
                    oCommand = new OracleCommand(sqlDel3, oCon);
                    oCommand.ExecuteNonQuery();
                    oCommand = new OracleCommand(sqlDel4, oCon);
                    oCommand.ExecuteNonQuery();
                    oCommand = new OracleCommand(sqlDel5, oCon);
                    oCommand.ExecuteNonQuery();
                }
                Ispolni(GridView1, "select * from \"Korisnici\"");
                Ispolni(GridView2, "select * from \"Administratori\"");
                totalUsers.Text = GridView1.Rows.Count.ToString();
                totalAdmins.Text = GridView2.Rows.Count.ToString();
                Label4.Text = "Корисникот е успешно избришан.";
                Panel1.CssClass = "uk-alert uk-alert-success";
            }
            catch (Exception ex)
            {
                Label4.Text = ex.Message;
                Panel1.CssClass = "uk-alert uk-alert-danger";
            }
            finally
            {
                oCon.Close();
            }
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView2.DataKeys[e.RowIndex].Value.ToString();
            removeUser("admin", id);
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            removeUser("user", id);
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string user = GridView1.SelectedRow.Cells[0].Text;
            Response.Redirect("~/BrisenjeKomentari.aspx?user=" + user);
        }
    }
}