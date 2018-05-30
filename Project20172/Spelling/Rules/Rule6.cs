using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule6 : Rule
	{
		public override bool Check(Word word)
		{
			if (word.original.Length > 2)
			{
				bool check =
					isPhuAm(word.original[word.original.Length - 1]) &&
					isPhuAm(word.original[word.original.Length - 2]) &&
					isNguyenAm(word.original[word.original.Length - 3]);

				if (check && 
					!phuAmDoiCuoi.Contains("" + word.original[word.original.Length - 2] + word.original[word.original.Length - 1])
				) {
					return false;
				}
			}
			return true;
		}
	}
}
