using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule15 : Rule
	{
		private string[] eeng =
		{
			"êng", "ếng", "ềng", "ểng", "ễng", "ệng"
		};

		public override bool Check(Word word)
		{
			if (word.IsFirstPresent() && word.first.CompareTo("gi") != 0 && eeng.Contains(word.last))
			{
				return false;
			}

			return true;
		}
	}
}
