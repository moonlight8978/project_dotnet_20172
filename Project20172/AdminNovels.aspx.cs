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
    public partial class AdminNovels : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }

        private void Display()
        {
            DisplayNovel();
            DisplayChapters();
        }

        private void DisplayNovel()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Novels where ID=" + Page.RouteData.Values["ID"].ToString(), conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adp.Fill(data);
            NovelName.Text = data.Tables[0].Rows[0]["Name"].ToString();
            conn.Close();
        }

        private void DisplayChapters()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Chapters where NovelID=" + Page.RouteData.Values["ID"].ToString(), conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adp.Fill(data);
            conn.Close();
            ChaptersList.DataSource = data;
            ChaptersList.DataBind();
        }

        protected void CreateChapter_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into Chapters values(N'"
                + Page.RouteData.Values["ID"].ToString() + "',N'"
                + NewChapterNumber.Text + "',N'"
                + NewChapterContent.Text + "')",
                conn
            );
            cmd.ExecuteNonQuery();
            conn.Close();
            DisplayChapters();
        }

        protected void DeleteChapter_Click(object sender, EventArgs e)
        {
            LinkButton deleteButton = (LinkButton)sender;
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                String.Format(
                    "DELETE FROM Chapters WHERE ID = {0}",
                    deleteButton.CommandArgument
                ),
                conn
            );
            cmd.ExecuteNonQuery();
            conn.Close();
            DisplayChapters();
        }

        protected void EditChapter_Click(object sender, EventArgs e)
        {
            LinkButton editButton = (LinkButton)sender;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Chapters where ID=" + editButton.CommandArgument, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            NewChapterNumber.Text = data.Tables[0].Rows[0]["Number"].ToString();
            NewChapterContent.Text = data.Tables[0].Rows[0]["Content"].ToString();
            UpdateChapter.CommandArgument = data.Tables[0].Rows[0]["ID"].ToString();
        }

        protected void UpdateChapter_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                String.Format(
                    "UPDATE Chapters SET Number = '{0}', Content = N'{1}' WHERE ID = {2}",
                    NewChapterNumber.Text, NewChapterContent.Text, updateButton.CommandArgument
                ),
                conn
            );
            cmd.ExecuteNonQuery();
            conn.Close();
            DisplayChapters();
        }
    }
}