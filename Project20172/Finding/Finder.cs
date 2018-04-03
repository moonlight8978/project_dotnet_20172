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

		public List<int> CalculateIndexes(string sentence, string[] keys)
		{
			sentence = Regex.Replace(sentence, "[,.-:_'\"()]+", "");
			string[] words = sentence.Split(' ');
			List<int> positions = new List<int>();
			foreach (string key in keys)
			{
				positions.Add(Array.FindIndex(words, word => word == key));
			}

			return positions;
		}

		// Use array of indexes to calculate score
		public int CalculateScore(List<int> positions)
		{
			int score = 0;
			positions.Sort();
			if (positions.Count == 1)
			{
				return 0;
			}
			for (int i = 0; i < positions.Count - 1; i += 1)
			{
				score += positions[i + 1] - positions[i];
			}
			return score;
		}
		// Check if sentence match provided keyword
		// return score of sentence (>= 0 if succeed, -1 if fail, if corrent 100% = 0)
		public int Match(string rawSentence, string keyword)
		{
			string sentence = rawSentence.ToLower();
			string regex = @"\b(" + keyword + @")\b";
			if (Regex.Match(sentence, regex).Length == 0)
			{
				return 0;
			}

			string[] keys = keyword.Split(' ');
			foreach (string key in keys)
			{
				regex = @"\b(" + key + @")\b";
				if (Regex.Match(sentence, regex).Length == 0)
				{
					return -1;
				}
			}

			List<int> positions = CalculateIndexes(sentence, keys);
			int score = CalculateScore(positions);
			return score;
		}

		public List<FindingResult> FindSentences(string keyword)
		{
			List<FindingResult> findingResults = new List<FindingResult>();

			foreach (Paragraph paragraph in data)
			{
				string[] sentences = paragraph.content.Split('.');
				foreach (string sentence in sentences)
				{
					int score = Match(sentence, keyword.ToLower());
					if (score > 0)
					{
						findingResults.Add(new FindingResult(paragraph.number, sentence, score));
					}
				}

				findingResults.Sort((x, y) => {
					return x.score - y.score;
				});
			}
			
			return findingResults;
		}
	}
}