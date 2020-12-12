using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class add_thn_akademik : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // fungsi untuk cek postback kala
            {
                
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    tb_thn_akademik model = new tb_thn_akademik();
                    model.nama_thn_akademik = t1.Text;
                    
                    db.tb_thn_akademiks.InsertOnSubmit(model);
                    db.SubmitChanges();
                    Response.Redirect("thn_akademik.aspx");
                }
            }

        }
    }
}