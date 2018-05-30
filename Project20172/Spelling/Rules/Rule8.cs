using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule8 : Rule
	{
		public override bool Check(Word word)
		{
			if (word.original.Length > 7)
			{
				return false;
			}

			return true;
		}
	}
}
