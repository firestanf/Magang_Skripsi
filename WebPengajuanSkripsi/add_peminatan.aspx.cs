using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class add_peminatan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // fungsi untuk cek postback kala
            {
                dbDataContext db = new dbDataContext();
                var data = db.tb_fakultas.ToList();
                t1.DataSource = data;
                t1.DataTextField = "nama_fakultas";
                t1.DataValueField = "id_fakultas";
                t1.DataBind();

                var data2 = db.tb_jurusans.ToList();
                t2.DataSource = data2;
                t2.DataTextField = "nama_jurusan";
                t2.DataValueField = "id_jurusan";
                t2.DataBind();
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {

                    tb_peminatan model = new tb_peminatan();
                    model.nama_peminatan = t3.Text;
                    model.id_fakultas = Int32.Parse(t1.SelectedValue);
                    model.id_jurusan = Int32.Parse(t2.SelectedValue);

                    db.tb_peminatans.InsertOnSubmit(model);
                    db.SubmitChanges();
                    Response.Redirect("peminatan.aspx");
                }
            }

        }
    }
}