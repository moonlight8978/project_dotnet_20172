using Project20172.P;
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
		Connector connector = new Connector();
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
			string id = Page.RouteData.Values["ID"].ToString();
			string sql = String.Format("SELECT * FROM Novels WHERE ID = {0}", id);
			DataSet data = connector.query(sql);

            NovelName.Text = data.Tables[0].Rows[0]["Name"].ToString();
        }

        private void DisplayChapters()
        {
			string novelId = Page.RouteData.Values["ID"].ToString();
			string sql = String.Format("SELECT * FROM Chapters WHERE NovelID = {0}", novelId);
			DataSet data = connector.query(sql);

            ChaptersList.DataSource = data;
            ChaptersList.DataBind();
        }

        protected void CreateChapter_Click(object sender, EventArgs e)
        {
			string novelId = Page.RouteData.Values["ID"].ToString();
			string number = NewChapterNumber.Text.ToString();
			string content = NewChapterContent.Text.ToString();
			string sql = String.Format(
				"INSERT INTO Chapters VALUES(N'{0}', N'{1}', N'{2}')",
				novelId, number, content
			);
			connector.excute(sql);

            DisplayChapters();
        }

        protected void DeleteChapter_Click(object sender, EventArgs e)
        {
            LinkButton deleteButton = (LinkButton)sender;
			string id = deleteButton.CommandArgument.ToString();
			String sql = String.Format("DELETE FROM Chapters WHERE ID = {0}", id);
			connector.excute(sql);

            DisplayChapters();
        }

        protected void EditChapter_Click(object sender, EventArgs e)
        {
            LinkButton editButton = (LinkButton)sender;
			string id = editButton.CommandArgument.ToString();
			string sql = String.Format("SELECT * FROM Chapters WHERE ID = {0}", id);
			DataSet data = connector.query(sql);

            NewChapterNumber.Text = data.Tables[0].Rows[0]["Number"].ToString();
            NewChapterContent.Text = data.Tables[0].Rows[0]["Content"].ToString();
            UpdateChapter.CommandArgument = data.Tables[0].Rows[0]["ID"].ToString();
        }

        protected void UpdateChapter_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;
			string id = updateButton.CommandArgument.ToString();
			string number = NewChapterNumber.Text.ToString();
			string content = NewChapterContent.Text.ToString();
			string sql = String.Format(
				"UPDATE Chapters SET Number = '{0}', Content = N'{1}' WHERE ID = {2}",
				number, content, id
			);
			connector.excute(sql);

            DisplayChapters();
        }
    }
}