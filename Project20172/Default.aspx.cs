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
    public partial class _Default : Page
    {
		Connector connector = new Connector();
		protected void Page_Load(object sender, EventArgs e)
        {
			Display();
		}

		private void Display()
		{
			string sql = "SELECT * FROM Novels";
			DataSet data = connector.query(sql);

			NovelList.DataSource = data;
			NovelList.DataBind();
		}
	}
}