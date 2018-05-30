using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule5 : Rule
	{
		public override bool Check(Word word)
		{
			if (word.original.Length > 1)
			{
				bool check =
					isPhuAm(word.original[word.original.Length - 1]) &&
					isNguyenAm(word.original[word.original.Length - 2]);

				if (check && !phuAmCuoi.Contains("" + word.original[word.original.Length - 1]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
