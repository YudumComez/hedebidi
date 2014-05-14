using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hedebidi
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["beniHatirla"]!=null)
            {
                //cookie var
                HttpCookie mookie = Request.Cookies["beniHatirla"];
                TextBox1.Text = mookie.Values["kullaniciAdi"].ToString();
                TextBox2.Text = mookie.Values["sifre"].ToString();
                CheckBox1.Checked = Convert.ToBoolean(mookie.Values["tikliMi"].ToString()) == true
                    ? true
                    : false;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (CheckBox1.Checked)
            {
                //beni hatırla
                HttpCookie cookie = new HttpCookie("beniHatirla");
                cookie.Expires = DateTime.Now.AddMinutes(3d);
                cookie.Values.Add("kullaniciAdi", TextBox1.Text);
                cookie.Values.Add("sifre",TextBox2.Text);
                cookie.Values.Add("tikliMi","true");

                Response.Cookies.Add(cookie);

            }
            else
            { 
            //beni hatırlama

            }

        }
    }
}