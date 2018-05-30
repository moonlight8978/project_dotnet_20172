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
	public partial class Admin : System.Web.UI.Page
	{
		Connector connector = new Connector();
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Display();
			}
		}

		protected void CreateNewNovel_Click(object sender, EventArgs e)
		{
			string name = NovelName.Text.ToString();
			string sql = String.Format("insert into Novels values(N'{0}')", name);
			connector.excute(sql);
			NovelName.Text = String.Empty;
			Display();
		}

		protected void UpdateNovel_Click(object sender, EventArgs e)
		{
			LinkButton btn = (LinkButton)sender;
			string id = btn.CommandArgument.ToString();
			string name = NovelName.Text.ToString();
			string sql = String.Format("UPDATE Novels SET Name = N'{0}' WHERE ID = {1}", name, id);
			connector.excute(sql);
			Display();
		}

		protected void EditNovel_Click(object sender, EventArgs e)
		{
			LinkButton btn = (LinkButton)sender;
			string id = btn.CommandArgument.ToString();
			DataSet data = connector.query("SELECT * FROM Novels WHERE ID = " + id);
			NovelName.Text = data.Tables[0].Rows[0]["Name"].ToString();
			UpdateNovel.CommandArgument = id;
		}

		protected void DeleteNovel_Click(object sender, EventArgs e)
		{
			LinkButton btn = (LinkButton)sender;
			string id = btn.CommandArgument.ToString();
			string sql = String.Format("DELETE FROM Novels WHERE ID = {0}", id);
			connector.excute(sql);
			Display();
		}

		private void Display()
		{
			DataSet data = connector.query("SELECT * FROM Novels");
			NovelsList.DataSource = data;
			NovelsList.DataBind();
		}
	}
}