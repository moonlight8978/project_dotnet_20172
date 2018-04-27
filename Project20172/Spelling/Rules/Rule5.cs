using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule5 : SpellChecker
	{
		public override bool Check(string word)
		{
			if (word.Length > 1)
			{
				bool check =
					isPhuAm(word[word.Length - 1]) &&
					isNguyenAm(word[word.Length - 2]);

				if (check && !phuAmCuoi.Contains("" + word[word.Length - 1]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
