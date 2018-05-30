using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule3 : Rule
	{
		public override bool Check(Word word)
		{
			if (word.original.Length > 3)
			{
				bool isTriple =
				phuAm.Contains(word.original[0].ToString()) &&
				phuAm.Contains(word.original[1].ToString()) &&
				phuAm.Contains(word.original[2].ToString());

				if (isTriple && !phuAmBa.Contains("" + word.original[0] + word.original[1] + word.original[2]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
