using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project20172.Spelling
{
	public class Splitter
	{
		public string[] split(string paragraph)
		{
			string without_specials = Regex.Replace(paragraph, "[,<.>/?;:'\"!&*()=+_-]", " ");
			string fix_whitespaces = Regex.Replace(without_specials.Trim(), @"\s+", " ");
			string[] words = Regex.Split(fix_whitespaces, " ");

			return words;
		}
	}
}