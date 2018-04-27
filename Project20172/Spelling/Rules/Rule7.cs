using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule7 : SpellChecker
	{
		public override bool Check(string word)
		{
			if (word.Length > 3)
			{
				if (
					isPhuAm(word[word.Length - 1]) &&
					isPhuAm(word[word.Length - 2]) &&
					isPhuAm(word[word.Length - 3])
				)
				{
					return false;
				}
			}
			return true;
		}
	}
}
