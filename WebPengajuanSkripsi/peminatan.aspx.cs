using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebPengajuanSkripsi
{
    public partial class peminatan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Object user = Session["user"];
            if (user == null)
            {
                Response.Redirect("default.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    GridView1.DataSource = db.v_peminatans.ToList();
                    GridView1.DataBind();
                }
            }
        }
    }
}