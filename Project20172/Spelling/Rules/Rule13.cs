using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule13 : Rule
	{
		private string[] ieee = {
			"e", "é", "è", "ẻ", "ẽ", "ẹ",
			"ê", "ế", "ề", "ể", "ễ", "ệ",
			"i", "í", "ì", "ỉ", "ĩ", "ị"
		};

		private string[] good =
		{
			"ngh", "gh", "k"
		};

		private string[] bad =
		{
			"c", "ng", "g"
		};

		public override bool Check(Word word)
		{
			if (word.IsFirstPresent() && word.IsLastPresent() && good.Contains(word.first) && !ieee.Contains("" + word.last[0]))
			{
				return false;
			}

			if (word.IsFirstPresent() && word.IsLastPresent() && bad.Contains(word.first) && ieee.Contains("" + word.last[0]))
			{
				return false;
			}

			return true;
		}
	}
}
