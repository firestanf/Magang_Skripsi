using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebPengajuanSkripsi
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tombol_login(object sender, EventArgs e)
        {
            lblInvalidUsernamePassword.Visible = false;

            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    string username = t1.Text.Trim();
                    string password = t2.Text.Trim();
                    int tipe = 0;
                    if (username.StartsWith("koorskripsi")) tipe = 1;


                    if (tipe == 0)
                    {
                        var mhs = (from c in db.tb_mahasiswas where c.nim == username && c.password == password select c).FirstOrDefault();
                        if (mhs != null)
                        {
                            Session.Add("user", mhs);
                            Session.Add("role", tipe);
                            FormsAuthentication.RedirectFromLoginPage(username, false);
                            Response.Redirect("dashboard.aspx");
                        }
                        else
                        {
                            var dosen = (from c in db.tb_dosens where c.nid == username && c.password == password select c).FirstOrDefault();
                            if (dosen != null)
                            {
                                Session.Add("user", dosen);
                                Session.Add("role", 2);
                                FormsAuthentication.RedirectFromLoginPage(username, false);
                                Response.Redirect("dashboard.aspx");
                            }
                            else
                            {
                                lblInvalidUsernamePassword.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        var user = (from c in db.tb_kaprodis where c.username == username && c.password == password select c).FirstOrDefault();
                        if (user != null)
                        {
                            Session.Add("user", user);
                            Session.Add("role", tipe);
                            FormsAuthentication.RedirectFromLoginPage(username, false);
                            Response.Redirect("dashboard.aspx");
                        }
                        else
                        {
                            lblInvalidUsernamePassword.Visible = true;
                        }
                    }
                    
                }
            }
        }
    }
}