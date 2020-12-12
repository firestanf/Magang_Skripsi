using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class edit_pengajuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                error_tipe.Visible = false;
                int id = Int32.Parse(Request.QueryString["id"]);
                using (dbDataContext db = new dbDataContext())
                {
                    tb_proposal model = (from c in db.tb_proposals where c.id_proposal == id select c).FirstOrDefault();
                    t1.Text = model.judul_skripsi;
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    int id = Int32.Parse(Request.QueryString["id"]);
                    tb_mahasiswa user = Session["user"] as tb_mahasiswa;
                    tb_proposal model = (from c in db.tb_proposals where c.id_proposal == id select c).FirstOrDefault();
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
                            foreach (var file in f1.PostedFiles)
                            {
                                string fn = i + "_" + file.FileName;

                                //file.SaveAs(dir + "/temp_laporan/" + fn);
                                string path = Server.MapPath(@"jangan_buang\" + model.id_proposal + "\\");
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                file.SaveAs(path + fn);

                                i++;
                            }
                            model.status_proposal = "Pending";
                            db.SubmitChanges();
                            Response.Redirect("pengajuan.aspx");
                        }


                    }
                    else
                    {
                        model.status_proposal = "Pending";
                        db.SubmitChanges();
                        Response.Redirect("pengajuan.aspx");
                    }

                }
            }

        }
    }
}