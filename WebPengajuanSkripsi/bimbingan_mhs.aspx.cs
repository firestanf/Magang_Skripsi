using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPengajuanSkripsi
{
    public partial class bimbingan_mhs : System.Web.UI.Page
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
                LoadData();
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
            tb_mahasiswa user = Session["user"] as tb_mahasiswa;
            dbDataContext db = new dbDataContext();
            this.GridView1.DataSource = (from c in db.v_rooms
                                         where c.id_mahasiswa == user.id_mahasiswa
                                         orderby c.tgl_room descending
                                         select c).ToList();
            this.GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("join"))
            {
                dbDataContext db = new dbDataContext();

                int id = Int32.Parse(e.CommandArgument.ToString());
               
                Response.Redirect("detail_bimbingan.aspx?id=" + id);
                
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}