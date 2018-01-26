using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project20172
{
    public partial class Admin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }

        protected void CreateNewNovel_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Novels values(N'" + NewNovelName.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            NewNovelName.Text = String.Empty;
            Display();
        }

        private void Display()
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Novels", conn);
            DataSet data = new DataSet();
            adapter.Fill(data);
            NovelsList.DataSource = data;
            NovelsList.DataBind();
        }
    }
}