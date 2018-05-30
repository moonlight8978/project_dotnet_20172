using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule2 : Rule
	{
		public override bool Check(Word word)
		{
			if (word.original.Length > 2)
			{
				bool isDouble =
				phuAm.Contains(word.original[0].ToString()) &&
				phuAm.Contains(word.original[1].ToString());

				if (isDouble && !phuAmDoiDau.Contains("" + word.original[0] + word.original[1]))
				{
					return false;
				}
			} 
			return true;
		}
	}
}
