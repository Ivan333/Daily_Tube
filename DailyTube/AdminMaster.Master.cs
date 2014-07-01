using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["imeK"] != null)
                Label1.Text = Session["imeK"].ToString();
        }
        public string lblUser_Text
        {
            get { return Label1.Text; }
            set { Label1.Text = value; }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Najava.aspx");
        }
    }
}