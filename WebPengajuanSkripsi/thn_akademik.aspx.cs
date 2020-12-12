using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class thn_akademik : System.Web.UI.Page
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
                dbDataContext db = new dbDataContext();
                GridView1.DataSource = (from c in db.tb_thn_akademiks
                                        orderby c.nama_thn_akademik descending
                                        select c).ToList();
                GridView1.DataBind();

            }
        }
    }
}