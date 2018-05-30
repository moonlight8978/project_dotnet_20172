using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule7 : Rule
	{
		public override bool Check(Word word)
		{
			if (word.original.Length > 3)
			{
				if (
					isPhuAm(word.original[word.original.Length - 1]) &&
					isPhuAm(word.original[word.original.Length - 2]) &&
					isPhuAm(word.original[word.original.Length - 3])
				)
				{
					return false;
				}
			}
			return true;
		}
	}
}
