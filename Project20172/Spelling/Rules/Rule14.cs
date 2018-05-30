using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule14 : Rule
	{
		private string[] gi =
		{
			"gi", "gí", "gì", "gỉ", "gĩ", "gị"
		};

		public override bool Check(Word word)
		{
			if (!word.IsLastPresent() && word.IsFirstPresent() && !gi.Contains(word.first))
			{
				return false;
			}

			return true;
		}
	}
}
