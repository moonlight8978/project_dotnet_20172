using Project20172.Find;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project20172.Finding
{
	public class Paragraph
	{
		public string content { get; set; }
		public string number { get; set; }
		public string[] sentences;

		public Paragraph(string number, string content)
		{
			this.number = number;
			this.content = content;
		}

		public void SplitIntoSentences()
		{
			sentences = Regex.Split(content, "[.!?:]");
		}

		public FindingResult FindBestMatch(string keyword)
		{
			List<FindingResult> results = new List<FindingResult>();

			string[] keys = Regex.Split(keyword.ToLower(), "\\s+");
			foreach (string rawSentence in sentences)
			{
				string sentence = FixSentence(rawSentence);
				bool found = true;
				foreach (string key in keys)
				{
					if (Regex.Match(sentence, @"\b(" + key + @")\b").Length == 0)
					{
						found = false;
						break;
					}
				}

				if (found)
				{
					results.Add(new FindingResult(this.number, sentence, 0));
				}
			}

			return results[0];
		}

		public FindingResult FindFullMatch(string rawKeyword)
		{
			FindingResult result = null;
			string keyword = rawKeyword.ToLower();
			foreach (string rawSentence in sentences)
			{
				string sentence = FixSentence(rawSentence);
				if (Regex.Match(sentence, keyword).Length > 0)
				{
					string highlight = Regex.Replace(sentence, keyword, String.Format("<b>{0}</b>", keyword));
					result = new FindingResult(this.number, highlight, 0);
					break;
				}
			}
			return result;
		}

		public string FixSentence(string sentence)
		{
			return Regex.Replace(sentence, "[,.;_+=\"'-]", "").ToLower();
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
	}
}