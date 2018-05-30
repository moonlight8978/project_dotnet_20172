using Project20172.P;
using Project20172.Spelling;
using Spelling;
using Spelling.Rules;
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
	public partial class Chapter : System.Web.UI.Page
	{
		SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");
		Connector connector = new Connector();
		Splitter splitter = new Splitter();
		Highlighter highlighter = new Highlighter();
		protected void Page_Load(object sender, EventArgs e)
		{
			Display();
		}

		private void Display()
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand("select * from Chapters where ID=" + Page.RouteData.Values["ID"].ToString(), conn);
			SqlDataAdapter adp = new SqlDataAdapter(cmd);
			DataSet data = new DataSet();
			adp.Fill(data);
			conn.Close();
			ChapterNumber.Text = "Hồi " + data.Tables[0].Rows[0]["Number"].ToString();
			ChapterContent.Text = data.Tables[0].Rows[0]["Content"].ToString();
			ShowNovel(data.Tables[0].Rows[0]["NovelID"].ToString());
			ChapterFullName.Text = NovelName.Text + " - " + ChapterNumber.Text;
		}

		private void ShowNovel(String ID)
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(
				String.Format("select * from Novels where ID= {0}", ID), 
				conn
			);
			SqlDataAdapter adp = new SqlDataAdapter(cmd);
			DataSet data = new DataSet();
			adp.Fill(data);
			conn.Close();
			NovelName.Text = data.Tables[0].Rows[0]["Name"].ToString();
		}

		protected void SpellCheck_Click(object sender, EventArgs e)
		{
			List<string> invalidWords = new List<string>();
			SpellChecker sc = new SpellChecker();

			string sql = String.Format("select * from Chapters where ID= {0}", Page.RouteData.Values["ID"].ToString());
			DataSet data = connector.query(sql);
			string content = data.Tables[0].Rows[0]["Content"].ToString();
			string[] words = splitter.split(content);

			foreach (string word in words)
			{
				if (!sc.Check(word))
				{
					invalidWords.Add(word);
				}
			}

			System.IO.File.WriteAllLines(@"E:\invalid_words.txt", invalidWords);

			foreach (string word in invalidWords)
			{
				content = highlighter.highlight(content, word);
			}
			ChapterContent.Text = content;
			InvalidCount.Text = String.Format("{0} lỗi", invalidWords.Count);
			//InvalidCount.Text = String.Join("...", invalidWords.ToArray());
			//InvalidCount.Text = words.Length.ToString();
		}
	}
}