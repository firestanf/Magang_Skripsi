using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class aksi_pengajuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                show_error.Visible = false;
                int id = Int32.Parse(Request.QueryString["id"]);

             
                tb_kaprodi us = Session["user"] as tb_kaprodi;
                using (dbDataContext db = new dbDataContext())
                {
                    tb_proposal model = (from c in db.tb_proposals where c.id_proposal == id  select c).FirstOrDefault();
                    if (model != null)
                    {
                        t1.Text = model.judul_skripsi;
                        catatan_kaprodi.Text = model.catatan_kaprodi;

                        tb_mahasiswa tm = (from c in db.tb_mahasiswas where c.id_mahasiswa == model.id_mahasiswa select c).FirstOrDefault();
                        nama_mhs.Text = tm.nama;
                        ipk_mhs.Text = tm.ipk + "";
                        nim_mhs.Text = tm.nim;
                        alamat.Text = tm.alamat;
                        telp.Text = tm.telp;
                        fakultas.Text = (from c in db.tb_fakultas where c.id_fakultas == tm.id_fakultas select c.nama_fakultas).FirstOrDefault();
                        jurusan.Text = (from c in db.tb_jurusans where c.id_jurusan == tm.id_jurusan select c.nama_jurusan).FirstOrDefault();

                        List<file_info> fi = new List<file_info>();
                        string path = Server.MapPath(@"jangan_buang\" + model.id_proposal + "\\");

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

                        var data = (from c in db.tb_dosens where c.id_jurusan == us.id_jurusan orderby c.nama select c).ToList();
                        data.Insert(0, new tb_dosen()
                        {
                            nama = "-",
                            nid = "",
                        });
                        d3.DataSource = data;
                        d3.DataTextField = "nama";
                        d3.DataValueField = "id_dosen";
                        d3.DataBind();

                        d2.DataSource = data;
                        d2.DataTextField = "nama";
                        d2.DataValueField = "id_dosen";
                        d2.DataBind();
                    }
                    else
                    {
                        Response.Redirect("list_pengajuan.aspx");
                    }
                  
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (d1.SelectedValue.Equals("Disetujui") && d2.SelectedValue.ToString() != "0"  && d3.SelectedValue.ToString() != "0")
                {
                    tb_kaprodi user = Session["user"] as tb_kaprodi;
                    using (dbDataContext db = new dbDataContext())
                    {
                        int id = Int32.Parse(Request.QueryString["id"]);
                        tb_proposal model = (from c in db.tb_proposals where c.id_proposal == id select c).FirstOrDefault();
                        model.status_proposal = d1.SelectedValue;
                        try
                        {
                            model.id_pembimbing_1 = Int32.Parse(d2.SelectedValue);
                        }
                        catch
                        {

                        }
                        try
                        {
                            model.id_pembimbing_2 = Int32.Parse(d3.SelectedValue);
                        }
                        catch
                        {

                        }
                        model.id_kaprodi = user.id_pengguna;
                        model.catatan_kaprodi= catatan_kaprodi.Text;
                        db.SubmitChanges();
                        Response.Redirect("list_pengajuan.aspx");
                    }
                }
                else
                {
                    show_error.Visible = true;
                    
                }
    
            }

        }
    }
    class file_info
    {
        public string nama_file { get; set; }
        public string lokasi_file { get; set; }
    }
}