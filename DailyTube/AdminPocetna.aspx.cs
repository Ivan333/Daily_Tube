using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class AdminPocetna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["imeK"] != null)
                this.Master.lblUser_Text = Session["imeK"].ToString();
            Ispolni(gvTopVidea, "SELECT * FROM \"Top5_videa\"");
            Ispolni(gvNajkomentirani, "SELECT * FROM \"ProcZastNaKom\"");
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
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public static string GetKategorii()
        {
            string query = "select * from \"Zastapenost_po_kategorii\"";
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query, con);
            DataSet data;
            try
            {
                con.Open();
                data = GetData(cmd);
                System.IO.StringWriter writer = new System.IO.StringWriter();
                data.Tables[0].WriteXml(writer, XmlWriteMode.WriteSchema, false);
                return writer.ToString();

            }
            catch
            {

            }
            return "";
            
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
        public static string GetSajtovi()
        {
            string query = "select * from \"ProcZastNaSajtoviPoVId\"";
            string conString = ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(query, con);
            DataSet data;
            try
            {
                con.Open();
                data = GetData(cmd);
                System.IO.StringWriter writer = new System.IO.StringWriter();
                data.Tables[0].WriteXml(writer, XmlWriteMode.WriteSchema, false);
                return writer.ToString();

            }
            catch
            {

            }
            return "";

        }
        private static DataSet GetData(OracleCommand cmd)
        {
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

    }
}