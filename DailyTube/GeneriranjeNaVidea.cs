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
    public class GeneriranjeNaVidea
    {
        public Panel Panel1 { get; set; }
        public Label Label1 { get; set; }
        public GeneriranjeNaVidea(Panel p, Label l)
        {
            Panel1 = p;
            Label1 = l;
        }
        public void generate(string sql, string tipNaKat, bool b, Label lbl = null, Panel pan = null, string tip = "", string id="")
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["SQLStr"].ConnectionString;
            string commandText = sql;
            commandText = sql;
            OracleConnection oc = new OracleConnection(conStr);
            OracleCommand ocmd = new OracleCommand(commandText, oc);
            OracleDataAdapter oda = new OracleDataAdapter(ocmd);
            DataSet ds = new DataSet();
            try
            {
                oc.Open();
                oda.Fill(ds, "Tabela");
                if (ds.Tables[0].Rows.Count == 0 && lbl != null && tip == "")
                {
                    lbl.Text = "Не се пронајдени видеа.";
                    pan.CssClass = "uk-alert";
                }
                else if (ds.Tables[0].Rows.Count == 0 && lbl != null && tip == "omileno")
                {
                    lbl.Text = "Немате омилени видеа.";
                    pan.CssClass = "uk-alert";
                }
                else if (ds.Tables[0].Rows.Count == 0 && lbl != null && tip == "pretplateni")
                {
                    lbl.Text = "Не сте претплатени на ниту еден канал. ";
                    LinkButton btn = new LinkButton();
                    btn.Text = "Претплатете се сега.";
                    btn.PostBackUrl = "Pretplata.aspx?id=" + id;
                    pan.Controls.Add(btn);
                    pan.CssClass = "uk-alert";
                }
            }
            catch (Exception err)
            {

                Label1.Text = err.ToString();
            }
            finally
            {
                oc.Close();
            }
            if (ds.Tables["Tabela"] == null)
            {
                return;
            }
            string kat_ime = "";
            int i = 0;
            Panel tmp = null;
            foreach (DataRow r in ds.Tables["Tabela"].Rows)
            {
                if (kat_ime == null || !kat_ime.Equals(r[tipNaKat].ToString()))
                {
                    if (tmp != null)
                    {
                        Label l3 = new Label();
                        l3.Attributes.Add("style", "display: none");
                        l3.CssClass = "brojac";
                        l3.Text = i.ToString();
                        i = 0;
                        tmp.Controls.Add(l3);
                    }
                    kat_ime = r[tipNaKat].ToString();
                    Panel p2 = new Panel();
                    HyperLink l = new HyperLink();
                    l.Text = r[tipNaKat].ToString();
                    if (b)
                    {
                        l.CssClass = "Zolto";
                    }
                    else
                    {
                        l.CssClass = "belo";
                    }
                    if (tipNaKat.ToLower().Contains("kategorija") && b)
                    {
                        l.NavigateUrl = "VideaOdKategorija.aspx?katIme=" + r[tipNaKat].ToString().Replace("&","%26");
                    }
                    if (tipNaKat.ToLower().Contains("kanal") && b)
                    {
                        l.NavigateUrl = "VideaOdKanal.aspx?kanalIme=" + r[tipNaKat].ToString().Replace("&", "%26");
                    }
                    p2.Controls.Add(l);
                    p2.Attributes.Add("class", "naslovV");
                    if (tip == "pretplateni")
                    {
                        Button bTrgni = new Button();
                        bTrgni.Text = "Отстрани";
                        p2.Controls.Add(bTrgni);
                        bTrgni.CssClass = "uk-button uk-button-danger btnRemovePretplata";
                        bTrgni.OnClientClick = "return false";
                        TextBox t = new TextBox();
                        t.CssClass = "kanalId";
                        p2.Controls.Add(t);
                        t.Text = r["KANAL_ID"].ToString();
                    }
                    Panel slider = new Panel();
                    tmp = new Panel();
                    Panel1.Controls.Add(p2);
                    if (b)
                        tmp.CssClass = "jqClass";
                    else
                    {
                        tmp.CssClass = "jqOld";
                    }
                    slider.Controls.Add(tmp);
                    Panel p3 = new Panel();
                    if (b)
                    {
                        ImageButton bL = new ImageButton();
                        bL.CssClass = "buttonLeft";
                        ImageButton bR = new ImageButton();
                        bR.CssClass = "buttonRight";
                        bL.OnClientClick = "return false;";
                        bR.OnClientClick = "return false;";
                        bL.ImageUrl = "../images/rsz_left_arrow.png";
                        bR.ImageUrl = "../images/rsz_rightarrow.png";
                        p3.Controls.Add(bL);
                        p3.Controls.Add(bR);
                    }
                    slider.CssClass = "sliderCS";
                    p3.Controls.Add(slider);
                    p3.Attributes.Add("class", "vmetnatELem");
                    Panel1.Controls.Add(p3);
                }
                i++;
                Panel p = new Panel();
                Label hl = new Label();
                hl.Attributes.Add("class", "videoHeader");
                string s = r["video_naslov"].ToString();
                s.Replace("/n", " ");
                if (s.Length > 20)
                {
                    s = s.Substring(0, 20);
                }
                hl.Text = s + "...<br/>";
                p.Controls.Add(hl);
                Image img = new Image();
                img.ImageUrl = r["slika"].ToString();
                img.Attributes.Add("class", "slika");
                img.ImageAlign = ImageAlign.Left;
                p.Controls.Add(img);
                p.Attributes.Add("class", "videa");
                Label l2 = new Label();
                s = r["opis"].ToString();
                if (s.Length > 50)
                {
                    s = s.Substring(0, 50);
                }
                l2.Text = s + "...";
                l2.Attributes.Add("class", "cssFloatLeft");
                p.Controls.Add(l2);
                dodadiLabeli(r, p, tmp);
                tmp.Controls.Add(p);
            }
        }
        private void dodadiLabeli(DataRow r, Panel p, Panel tmp)
        {
            Label l3 = new Label();
            l3.Attributes.Add("style", "display: none");
            l3.CssClass = "url";
            l3.Text = r["video_url"].ToString();
            p.Controls.Add(l3);
            Label l4 = new Label();
            l4.Attributes.Add("style", "display: none");
            l4.CssClass = "vId";
            l4.Text = r["video_id"].ToString();
            p.Controls.Add(l4);
            Label l5 = new Label();
            l5.Attributes.Add("style", "display: none");
            l5.CssClass = "brPreg";
            l5.Text = r["br_pregledi"].ToString();
            p.Controls.Add(l5);
            Label l6 = new Label();
            l6.Attributes.Add("style", "dsplay: none");
            l6.CssClass = "vkRejting";
            l6.Text = r["video_rejting"].ToString();
            p.Controls.Add(l6);
            Label l7 = new Label();
            l7.Attributes.Add("style", "dsplay: none");
            l7.CssClass = "vData";
            l7.Text = (r["video_data"].ToString().Split(' '))[0];
            p.Controls.Add(l7);
            Label l8 = new Label();
            l8.Attributes.Add("style", "dsplay: none");
            l8.CssClass = "vSajt";
            l8.Text = r["sajt"].ToString();
            p.Controls.Add(l8);
            Label l9 = new Label();
            l9.Attributes.Add("style", "dsplay: none");
            l9.CssClass = "vKanal";
            l9.Text = r["kanal"].ToString();
            p.Controls.Add(l9);
        }
    }
}




