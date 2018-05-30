using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project20172.Find
{
	public class FindingResult
	{
		public FindingResult(string chapter, string sentence, int score)
		{
			this.sentence = sentence;
			this.score = score;
			this.chapter = chapter;
		}
		public string sentence { get; set; }
		public int score { get; set; }
		public string chapter { get; set; }
		public override String ToString()
		{
			return HttpUtility.HtmlDecode(String.Format("(Hồi {0}) {1}", chapter, sentence));
		}
	}
}