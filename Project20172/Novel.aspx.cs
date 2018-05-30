using Project20172.Find;
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
	public partial class Novel : System.Web.UI.Page
	{
		Connector connector = new Connector();
		Finder finder;
		protected void Page_Load(object sender, EventArgs e)
		{
			Display();
			finder = new Finder("1");
			//FindingResult.Text = finder.data.Count.ToString();
		}

		private void Display()
		{
			string id = Page.RouteData.Values["ID"].ToString();
			DisplayNovelInfo(id);
			DisplayChapters(id);
		}

		private void DisplayNovelInfo(string id)
		{
			string sql = String.Format("SELECT * FROM Novels WHERE ID = {0}", id);
			DataSet data = connector.query(sql);

			string name = data.Tables[0].Rows[0]["Name"].ToString();
			NovelName.Text = name;
			NovelFullName.Text = name;
			EditNovelLink.NavigateUrl = String.Format(
				"/admin_novels/{0}", 
				data.Tables[0].Rows[0]["ID"].ToString()
			);
		}

		private void DisplayChapters(string id)
		{
			string sql = String.Format("SELECT * FROM Chapters WHERE NovelID = {0}", id);
			DataSet data = connector.query(sql);

			ChapterList.DataSource = data;
			ChapterList.DataBind();
		}

		protected void Find_Click(object sender, EventArgs e)
		{
			string keyword = FindingKeyword.Text;
			List<FindingResult> results = finder.FindSentences(keyword);
			//FindingResult.Text = results.Count.ToString();
			ResultText.DataSource = results;
			ResultText.DataBind();
		}
	}
}