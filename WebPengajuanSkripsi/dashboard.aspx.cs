using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class dashboard : System.Web.UI.Page
    {
        public string nama_user, posisi_user;
        public Object user;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            var x = Int32.Parse("" + Session["role"]);


            if (x == 0)
            {
                user = Session["user"] as tb_mahasiswa;
            }
            else {
                user = Session["user"];
            }

            /*for (int i = 0; i < Session.Count; i++)
            {
                string value = "Key: " + Session.Keys[i] + ", Value: " + Session[Session.Keys[i]].ToString();

                Response.Write(value);
            }*/

            if (user == null)
            {
                Response.Redirect("default.aspx");
                return;
            }
            using (dbDataContext db = new dbDataContext())
            {
                s1.InnerText = db.tb_proposals.Count() + "";
                s2.InnerText = db.tb_mahasiswas.Count() + "";
                s3.InnerText = db.tb_dosens.Count() + "";
                s4.InnerText = db.tb_kaprodis.Count() + "";

                int tipe = Int32.Parse("" + Session["role"]);
                if(tipe == 0)
                {
                    tb_mahasiswa user = Session["user"] as tb_mahasiswa;
                    t1.Text = user.nim;
                    t2.Text = user.nama;
                    t3.Text = (from c in db.tb_fakultas where c.id_fakultas == user.id_fakultas select c.nama_fakultas).FirstOrDefault();
                    t4.Text = (from c in db.tb_jurusans where c.id_jurusan == user.id_jurusan select c.nama_jurusan).FirstOrDefault();
                    

                }
                else if (tipe == 2)
                {
                    tb_dosen user = Session["user"] as tb_dosen;
                    t1.Text = user.nid;
                    t2.Text = user.nama;
                    t3.Text = (from c in db.tb_fakultas where c.id_fakultas == user.id_fakultas select c.nama_fakultas).FirstOrDefault();
                    t4.Text = (from c in db.tb_jurusans where c.id_jurusan == user.id_jurusan select c.nama_jurusan).FirstOrDefault();

                }
                else 
                {
                    tb_kaprodi user = Session["user"] as tb_kaprodi;
                    t1.Text = user.username;
                    t2.Text = user.nama;
                    t3.Text = (from c in db.tb_fakultas where c.id_fakultas == user.id_fakultas select c.nama_fakultas).FirstOrDefault();
                    t4.Text = (from c in db.tb_jurusans where c.id_jurusan == user.id_jurusan select c.nama_jurusan).FirstOrDefault();

                }
            }
                 
        }
    }
}