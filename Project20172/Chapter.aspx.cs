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
			ChapterNumber.Text = data.Tables[0].Rows[0]["Number"].ToString();
			ChapterContent.Text = data.Tables[0].Rows[0]["Content"].ToString();
		}
	}
}