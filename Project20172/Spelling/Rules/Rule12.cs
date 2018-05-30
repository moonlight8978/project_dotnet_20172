using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule12 : Rule
	{
		public string[] firsts = {
			"nh", "ng", "ph", "th", "tr", "ch", "gh", "kh",
			"ngh",
			"b", "c", "d", "đ", "ð", "g", "h", "k", "l", "m",
			"n", "p", "q", "r", "s", "t", "v", "x",
			"gi", "gí", "gì", "gỉ", "gĩ", "gị",
			"qu"

		};
		public override bool Check(Word word)
		{
			if (word.IsFirstPresent() && !firsts.Contains(word.first))
			{
				return false;
			}

			return true;
		}
	}
}
