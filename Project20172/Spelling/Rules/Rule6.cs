using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule6 : SpellChecker
	{
		public override bool Check(string word)
		{
			if (word.Length > 2)
			{
				bool check =
					isPhuAm(word[word.Length - 1]) &&
					isPhuAm(word[word.Length - 2]) &&
					isNguyenAm(word[word.Length - 3]);

				if (check && 
					!phuAmDoiCuoi.Contains("" + word[word.Length - 2] + word[word.Length - 1])
				) {
					return false;
				}
			}
			return true;
		}
	}
}
