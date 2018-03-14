using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project20172.Find
{
	public class FindingResult
	{
		public FindingResult(string sentence, int score)
		{
			this.sentence = sentence;
			this.score = score;
		}
		public string sentence { get; set; }
		public int score { get; set; }
		public override String ToString()
		{
			return sentence;
		}
	}
}