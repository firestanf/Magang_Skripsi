using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebPengajuanSkripsi
{
    public partial class Menu_reporting : System.Web.UI.Page
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
                DataTable dt = new DataTable();


                using (dbDataContext db = new dbDataContext())
                { 
                  GridView1.DataSource =  (from c in db.
                     orderby c.tgl_room descending
                     select c).ToList(); 
                GridView1.DataBind();
                }

                
                  

                dt.Columns.Add("semester", typeof(string));
                dt.Columns.Add("jml_mhs", typeof(string));
                dt.Rows.Add(new Object[] { "Ganjil 2019/2020", "100"});
                dt.Rows.Add(new Object[] { "Genap 2019/2020", "75"});
              
            }
        }
    }
}