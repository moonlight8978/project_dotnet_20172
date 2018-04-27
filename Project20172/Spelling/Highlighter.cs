using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project20172.Spelling
{
	public class Highlighter
	{
		public string highlight(string paragraph, string word)
		{
			string highlighted;
			Regex reg = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
			Match match = reg.Match(paragraph);
			highlighted = reg.Replace(paragraph, String.Format("<b>{0}</b>", match.Value));
			return highlighted;
		}
	}
}