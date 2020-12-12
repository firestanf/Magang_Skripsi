using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebPengajuanSkripsi
{
    public partial class list_pengajuan : System.Web.UI.Page
    {

        public string jurusan_anda;
        public int jumlah_mhs;

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
                jurusan_anda = "aaa";
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
            tb_kaprodi user = Session["user"] as tb_kaprodi;

            //DataTable dt = new DataTable();
            //string querystring = "select A.id_proposal, B.nim, A.tgl_submit, A.status_proposal, A.judul_skripsi , B.nama, C.nama as dosen_1, D.nama as dosen_2 from tb_proposal as A left join tb_mahasiswa as B on B.id_mahasiswa = A.id_mahasiswa left join tb_dosen as C on C.id_dosen = A.id_pembimbing_1 left join tb_dosen as D on D.id_dosen = A.id_pembimbing_2 where B.id_jurusan = "+user.id_jurusan;
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["bimbingan_onlineConnectionString"].ToString()))
            //{
            //    SqlCommand command = new SqlCommand(
            //        querystring, connection);
            //    connection.Open();
            //    using (SqlDataReader reader = command.ExecuteReader())

            //    {
            //        dt.Load(reader);

            //    }
            //}
            //var count = 0;
            //List<tb_pengajuan> tbp = new List<tb_pengajuan>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    tb_pengajuan tb = new tb_pengajuan()
            //    {
            //        nim = (string)dr["nim"],
            //        nama = (string)dr["nama"],
            //        judul_skripsi = (dr["judul_skripsi"] == null) ? String.Empty : (string)dr["judul_skripsi"],
            //        tgl_submit= (DateTime)dr["tgl_submit"],
            //        status_proposal = (dr["status_proposal"] == null) ? String.Empty : (string)dr["status_proposal"],
            //        id_proposal = (int)dr["id_proposal"],
            //        dosen_1 = (dr["dosen_1"] == null) ? (string)dr["dosen_1"] : String.Empty,
            //        dosen_2 = (dr["dosen_2"] == null) ? (string)dr["dosen_2"] : String.Empty
            //    };
            //    tbp.Add(tb);
            //    count++;
            //}

            //jumlah_mhs = count;
            //this.GridView1.DataSource = tbp;
            dbDataContext db = new dbDataContext();
            this.GridView1.DataSource = (from c in db.v_proposals
                                        where c.id_jurusan == user.id_jurusan
                                         orderby c.tgl_submit descending
                                         select c).ToList();

            this.GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("view"))
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
             
                Response.Redirect("aksi_pengajuan.aspx?id=" + id);
            }
          
        }
        public class tb_pengajuan
        {
            public String nim   { get; set; }
          
            public string nama { get; set; }
            public string judul_skripsi { get; set; }
            public string status_proposal { get; set; }
            public string dosen_1 { get; set; }
            public string dosen_2 { get; set; }
            public DateTime tgl_submit { get; set; }
            public int id_proposal { get; set; }

        };
    

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}