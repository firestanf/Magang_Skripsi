using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class add_bimbingan : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // fungsi untuk cek postback kala
            {
                using (dbDataContext db = new dbDataContext())
                {
                    tb_dosen user = Session["user"] as tb_dosen;
                    var data = (from c in db.v_proposals
                                where c.status_proposal == "Disetujui" && c.id_pembimbing_1 == user.id_dosen
       || c.id_pembimbing_2 == user.id_dosen
                                select new
                                {
                                    c.id_proposal,
                                    judul_skripsi = c.judul_skripsi + " - " + c.nama + " - " + c.nim
                                }).ToList();
                    t1.DataSource = data;
                    t1.DataTextField = "judul_skripsi";
                    t1.DataValueField = "id_proposal";
                    t1.DataBind();
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    tb_dosen user = Session["user"] as tb_dosen;
                    tb_room model = new tb_room();
                    model.tgl_room = DateTime.Parse(t2.Text.Trim());                    
                    model.id_proposal = Int32.Parse(t1.SelectedValue);
                    model.id_mahasiswa = (from c in db.tb_proposals where c.id_proposal == model.id_proposal select c.id_mahasiswa).FirstOrDefault();
                    model.id_pembimbing = user.id_dosen;
                    
                    db.tb_rooms.InsertOnSubmit(model);
                    db.SubmitChanges();
                    Response.Redirect("bimbingan.aspx");
                }
            }

        }
    }
}