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
		public List<String> data { get; set; }
		public Finder()
		{
			data = new List<String>();
			getData();

		}
		public void getData()
		{
			SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Bach\\workspace\\DotNet\\Project20172\\Project20172\\App_Data\\novel.mdf;Integrated Security=True");
			conn.Open();
			SqlCommand cmd = new SqlCommand("select * from Chapters where NovelID=1", conn);
			SqlDataAdapter adp = new SqlDataAdapter(cmd);
			DataSet data = new DataSet();
			adp.Fill(data);
			conn.Close();
			foreach (DataRow row in data.Tables[0].Rows)
			{
				this.data.Add(row["Content"].ToString());
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
		// return score of sentence (>= 0 if succeed, -1 if fail)
		public int Match(string sentence, string keyword)
		{
			string[] keys = keyword.Split(' ');
			foreach (string key in keys)
			{
				string regex = @"\b(" + key + @")\b";
				if (Regex.Match(sentence, regex).Length == 0)
				{
					return -1;
				}
			}

			List<int> positions = CalculateIndexes(sentence, keys);
			int score = CalculateScore(positions);
			return score;
		}

		public List<FindingResult> FindSentences(string paragraph, string keyword)
		{
			string[] sentences = paragraph.Split('.');
			List<FindingResult> findingResults = new List<FindingResult>();
			foreach (string sentence in sentences)
			{
				int score = Match(sentence, keyword);
				if (score > 0)
				{
					findingResults.Add(new FindingResult(sentence, score));
				}
			}

			findingResults.Sort((x, y) => {
				return x.score - y.score;
			});
			return findingResults;
		}
	}
}