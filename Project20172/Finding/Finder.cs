using Project20172.Finding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project20172.Find
{
	public class Finder
	{
		public List<Paragraph> data { get; set; }
		public string NovelID;
		public Finder(string NovelID)
		{
			this.NovelID = NovelID;
			data = new List<Paragraph>();
			getData();
			
		}
		public void getData()
		{
			SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");
			conn.Open();
			SqlCommand cmd = new SqlCommand("select * from Chapters where NovelID=" + NovelID, conn);
			SqlDataAdapter adp = new SqlDataAdapter(cmd);
			DataSet data = new DataSet();
			adp.Fill(data);
			conn.Close();
			foreach (DataRow row in data.Tables[0].Rows)
			{
				Paragraph paragraph = new Paragraph(
					row["Number"].ToString(),
					row["Content"].ToString()
				);
				this.data.Add(paragraph);
			}
		}

		public List<FindingResult> FindSentences(string keyword)
		{
			List<FindingResult> fullMatches = new List<FindingResult>();
			List<FindingResult> bestMatches = new List<FindingResult>();

			foreach (Paragraph paragraph in data)
			{
				paragraph.SplitIntoSentences();
				FindingResult fullMatch = paragraph.FindFullMatch(keyword);
				if (fullMatch != null)
				{
					fullMatches.Add(fullMatch);
				}
			}
			if (fullMatches.Count > 0)
			{
				return fullMatches;
			}

			foreach (Paragraph paragraph in data)
			{
				paragraph.SplitIntoSentences();
				FindingResult bestMatch = paragraph.FindBestMatch(keyword);
				if (bestMatch != null)
				{
					bestMatches.Add(bestMatch);
				}
			}
			if (bestMatches.Count > 0)
			{
				bestMatches.Sort((x, y) => x.score - y.score);
			}

			return bestMatches;
		}
	}
}