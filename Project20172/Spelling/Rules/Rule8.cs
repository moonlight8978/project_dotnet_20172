using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule8 : SpellChecker
	{
		public override bool Check(string word)
		{
			if (word.Length > 7)
			{
				return false;
			}

			return true;
		}
	}
}
