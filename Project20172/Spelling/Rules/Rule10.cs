using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule10 : Rule
	{
		public override bool Check(Word word)
		{
			var count = 0;
			foreach (char c in word.original)
			{
				if (isNguyenAm(c))
				{
					count += 1;
				}
			}

			if (count > 3)
			{
				return false;
			}

			return true;
		}
	}
}
