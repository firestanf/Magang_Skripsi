using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class view_pengajuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Int32.Parse(Request.QueryString["id"]);
                List<file_info> fi = new List<file_info>();
                using (dbDataContext db = new dbDataContext())
                {
                    v_proposal model = (from c in db.v_proposals where c.id_proposal == id select c).FirstOrDefault();
                    t1.Text = model.judul_skripsi;
                    t2.Text = model.nama_thn_akademik;
                    t3.Text = model.nama_peminatan;
                    catatan_kaprodi.Text = model.catatan_kaprodi;
                    // a1.HRef = "file_pengajuan/" + model.file_permohonan;
                    string path =  Server.MapPath(@"jangan_buang\" + model.id_proposal + "\\");
                   
                    foreach (string fileName in Directory.GetFiles(path))
                        {
                            // fileName  is the file name
                            file_info fi_i = new file_info();
                            fi_i.nama_file = fileName;
                            fi_i.lokasi_file = @"jangan_buang\" + model.id_proposal + "\\" + Path.GetFileName(fileName);
                            fi.Add(fi_i);
                        }
                    RptDownload.DataSource = fi;
                    RptDownload.DataBind();
                }
            }
        }

        class file_info
        {
            public string nama_file { get; set; }
            public string lokasi_file { get; set; }
        }


    }
}