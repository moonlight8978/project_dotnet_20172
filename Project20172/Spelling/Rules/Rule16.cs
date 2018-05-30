using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule16 : Rule
	{
		private string[] yy =
		{
			"y", "ý", "ỳ", "ỷ", "ỹ", "ỵ"
		};

		public override bool Check(Word word)
		{
			if (word.IsFirstPresent() && word.first.CompareTo("qu") != 0 && word.IsLastPresent() && yy.Contains(word.last[0] + ""))
			{
				return false;
			}
			return true;
		}
	}
}
