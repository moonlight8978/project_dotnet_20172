using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule9 : Rule
	{
		public override bool Check(Word word)
		{
			var count = 0;
			foreach (char c in word.original)
			{
				if (isPhuAm(c))
				{
					count += 1;
				}
			}

			if (count > 5)
			{
				return false;
			}

			return true;
		}
	}
}
