using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class detail_bimbingan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Int32.Parse(Request.QueryString["id"]);
                using (dbDataContext db = new dbDataContext())
                {
                    var model = (from c in db.v_rooms where c.id_room == id select c).FirstOrDefault();
                    t1.Text = model.judul_skripsi;
                    t2.Text = model.nim;
                    t3.Text = model.nama;
                    LoadData();
                }
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == (string)ViewState["SortColumn"])
            {

                e.SortDirection =
                    ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }

            ViewState["SortColumn"] = e.SortExpression;
            ViewState["SortColumnDirection"] = e.SortDirection;
            LoadData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadData();
        }

        private void LoadData()
        {
            tb_dosen user = Session["user"] as tb_dosen;
            dbDataContext db = new dbDataContext();
            int id = Int32.Parse(Request.QueryString["id"]);
            this.GridView1.DataSource = (from c in db.v_chats
                                         where c.id_room == id
                                         orderby c.id_chat descending
                                         select c).ToList();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (dbDataContext db = new dbDataContext())
                {
                    int id = Int32.Parse(Request.QueryString["id"]);
                    var model = (from c in db.v_rooms where c.id_room == id select c).FirstOrDefault();
                    tb_mahasiswa user = Session["user"] as tb_mahasiswa;
                    if(user != null)
                    {
                        tb_chat c = new tb_chat();
                        c.id_room = id;
                        c.id_sender = user.id_mahasiswa;
                        c.isi = t4.Text.Trim();
                        c.status = 0;
                        c.id_recipient = model.id_pembimbing;
                        db.tb_chats.InsertOnSubmit(c);
                    }
                    else
                    {
                        tb_dosen user2 = Session["user"] as tb_dosen;
                        if (user2 != null)
                        {
                            tb_chat c = new tb_chat();
                            c.id_room = id;
                            c.status = 1;
                            c.id_sender = user2.id_dosen;
                            c.isi = t4.Text.Trim();
                            c.id_recipient = model.id_mahasiswa;
                            db.tb_chats.InsertOnSubmit(c);
                        }
                    }
                   
                    db.SubmitChanges();
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }

        }
    }
}