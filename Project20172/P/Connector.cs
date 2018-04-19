using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project20172.P
{
	public class Connector
	{
		SqlConnection conn;
		public Connector()
		{
			this.conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");
		}

		public DataSet query(string sql)
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataAdapter adp = new SqlDataAdapter(cmd);
			DataSet data = new DataSet();
			adp.Fill(data);
			conn.Close();
			return data;
		}

		public void excute(string sql)
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
}