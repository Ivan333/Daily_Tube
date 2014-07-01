using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DailyTube
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string thispage = this.Page.AppRelativeVirtualPath;
            int slashpos = thispage.LastIndexOf('/');
            string pagename = thispage.Substring(slashpos + 1);
            foreach (MenuItem mi in MenuPocetna.Items)
            {
                if (mi.NavigateUrl.Contains(pagename))
                {
                    mi.Selected = true;
                    break;
                }
            }
            if (Session["imeK"] != null)
            {
                userPocetna.Text = Session["imeK"].ToString();
                MenuPocetna.Items[4].NavigateUrl = "~/Pretplata.aspx?id=" + Session["idK"].ToString();
            }
        }
        public string lblUserText
        {
            get { return userPocetna.Text; }
            set { userPocetna.Text = value; }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Najava.aspx");
        }
    }
}