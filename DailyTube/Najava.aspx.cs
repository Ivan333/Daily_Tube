using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using System.Drawing;


namespace WebApplication4
{
    public partial class Najava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleConnection oc = new OracleConnection("Data Source=localhost:1521/orcl;User ID=DBA_20132014L_GRP_010;Password=DailyTube123;Unicode=True");
            try
            {
                oc.Open();
                string sel = "select * from zahomepage WHERE username = " + "'" + tbIme.Text + "'";
                OracleCommand oCmd = new OracleCommand(sel, oc);
                oCmd.CommandType = System.Data.CommandType.Text;
                OracleDataReader odr = oCmd.ExecuteReader();
                odr.Read();
                if (odr["password"].ToString().Equals(tbPass.Text))
                {
                    Session["imeK"] = tbIme.Text;
                    Session["idK"] = odr["POSETITEL_ID"].ToString();
                    if (odr["admin_id"].ToString().Trim() == "")
                    {
                        string query = "select distinct korisnik_id from pretplata where korisnik_id = " + Session["idK"].ToString();
                        OracleCommand cmd = new OracleCommand(query, oc);
                        OracleDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        if (!reader.HasRows)
                        {
                            Session["posetitelId"] = odr["korisnik_id"].ToString();
                            Response.Redirect("Pretplata.aspx?id=" + Session["idK"].ToString());
                        }
                        else 
                        {
                            Response.Redirect("SiteVidea.aspx");
                            Session["posetitelId"] = odr["korisnik_id"].ToString();
                        }
                    }
                    else
                    {
                        
                        Response.Redirect("AdminPocetna.aspx");
                        Session["posetitelId"] = odr["admin_id"].ToString();
                    }
                }
                else
                {
                    lblPoraka.Text = "Погрешна лозинка";
                    Panel3.Attributes.Add("class", "centeredMessage uk-alert uk-alert-danger");
                }
            }
            catch (Exception ex)
            {
                lblPoraka.Text = "Се случи нешто, обидете се повторно " + ex.Message;
                Panel3.Attributes.Add("class", "centeredMessage uk-alert uk-alert-danger");
            }
            finally
            {
                oc.Close();
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
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
                oCommand = new OracleCommand("insert into korisnik values(seq_user.CURRVAL)", oCon);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();
                lblPoraka.Text = "Регистрацијата е успешна";
                Panel3.Attributes.Add("class", "porakaOk");
                string sqlSel = "select posetitel_id from posetitel where username = '" + username + "'";
                DataSet ds = new DataSet();
                oCommand = new OracleCommand(sqlSel, oCon);
                OracleDataAdapter adapter = new OracleDataAdapter(oCommand);
                adapter.Fill(ds, "Posetitel");
                string korId = ds.Tables[0].Rows[0]["posetitel_id"].ToString();
                Session["imeK"] = username;
                Response.Redirect("Pretplata.aspx?id=" + korId);

            }
            catch (Exception ex)
            {
                lblPoraka.Text = ex.Message;
                Panel3.Attributes.Add("class", "centeredMessage uk-alert uk-alert-danger");
            }
            finally
            {
                oCon.Close();
            }
        }
    }
}