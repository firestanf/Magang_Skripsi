using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebPengajuanSkripsi
{
    public partial class pengajuan : System.Web.UI.Page
    {
        protected Boolean CanUpdate(string iid)
        {
            Object user = Session["user"];
            if (user == null)
            {
                return false;
            }

            using (dbDataContext db = new dbDataContext())
            {
                int id = Int32.Parse(iid);
                return (from c in db.tb_proposals where c.status_proposal == "Pending" && c.id_proposal == id select c).Any();
            }
        }
        protected Boolean NotSend(string iid)
        {
            Object user = Session["user"];
            if (user == null)
            {
                return false;
            }

            using (dbDataContext db = new dbDataContext())
            {
                int id = Int32.Parse(iid);
                return (from c in db.tb_proposals where c.status_proposal == "Pending" && c.id_proposal == id select c).Any();
            }
        }


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
            this.GridView1.DataSource = (from c in db.v_proposals
                                         where c.id_mahasiswa == user.id_mahasiswa
                                         orderby c.tgl_submit descending
                                         select c).ToList();
            this.GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("update"))
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                Response.Redirect("edit_pengajuan.aspx?id=" + id);
            }
            else if (e.CommandName.Equals("view"))
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                Response.Redirect("view_pengajuan.aspx?id=" + id);
            }
            else if (e.CommandName.Equals("delete"))
            {
                dbDataContext db = new dbDataContext();

                int id = Int32.Parse(e.CommandArgument.ToString());
                var model = (from c in db.tb_proposals where c.id_proposal == id select c).SingleOrDefault();
                if (model != null)
                {
                    db.tb_proposals.DeleteOnSubmit(model);
                    db.SubmitChanges();
                    Response.Redirect("pengajuan.aspx");
                }
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