using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class add_pengajuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error_tipe.Visible = false;
            if (!Page.IsPostBack) // fungsi untuk cek postback kala
            {
                dbDataContext db = new dbDataContext();
                var data = db.tb_thn_akademiks.ToList();
                d1.DataSource = data;
                d1.DataTextField = "nama_thn_akademik";
                d1.DataValueField = "id_thn_akademik";
                d1.DataBind();

                var data2 = db.tb_peminatans.ToList();
                d2.DataSource = data2;
                d2.DataTextField = "nama_peminatan";
                d2.DataValueField = "id_peminatan";
                d2.DataBind();
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    tb_mahasiswa user = Session["user"] as tb_mahasiswa;
                    tb_proposal model = new tb_proposal();
                    model.id_thn_akademik = Int32.Parse(d1.SelectedValue);
                    model.id_peminatan = Int32.Parse(d2.SelectedValue);
                    model.tgl_submit = DateTime.Now;
                    model.id_mahasiswa = user.id_mahasiswa;
                    model.judul_skripsi = t1.Text.Trim();
                    string dir = Server.MapPath("file_pengajuan");
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);


                    if (Request.Files != null)
                    {
                        int i = 1;
                        bool isValidFile = false;
                        foreach (var file in f1.PostedFiles)
                        {
                            string[] validFileTypes = { "pdf", "docx", "PDF", "DOCX" };
                            string ext = System.IO.Path.GetExtension(f1.PostedFile.FileName);

                            for (int x = 0; x < validFileTypes.Length; x++)
                            {
                                if (ext == "." + validFileTypes[x])
                                {
                                    isValidFile = true;
                                    break;
                                }
                            }
                        }


                        if (!isValidFile)
                        {
                            error_tipe.Visible = true;
                        }
                        else
                        {
                            model.status_proposal = "Pending";
                            db.tb_proposals.InsertOnSubmit(model);
                            db.SubmitChanges();
                            i = 1;
                            foreach (var file in f1.PostedFiles)
                            {
                                string fn = i + "_" + file.FileName;

                                //file.SaveAs(dir + "/temp_laporan/" + fn);
                                string path =  Server.MapPath(@"jangan_buang\" + model.id_proposal + "\\");
                                if (!Directory.Exists( path))
                                    {
                                    Directory.CreateDirectory( path);
                                }
                                file.SaveAs(path + fn);

                                i++;
                            }
                         
                           
                            db.SubmitChanges();
                            Response.Redirect("pengajuan.aspx");
                        }


                    }



                }
            }

        }



    }
}