using Project20172.Find;
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
    public partial class _Default : Page
    {
		SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");
		Finder finder;
		protected void Page_Load(object sender, EventArgs e)
        {
			Display();
			finder = new Finder("1");
			//FindingResult.Text = finder.data.Count.ToString();
		}

		private void Display()
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand("select * from Chapters where NovelID=1", conn);
			SqlDataAdapter adp = new SqlDataAdapter(cmd);
			DataSet data = new DataSet();
			adp.Fill(data);
			conn.Close();
			ChaptersList.DataSource = data;
			ChaptersList.DataBind();
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