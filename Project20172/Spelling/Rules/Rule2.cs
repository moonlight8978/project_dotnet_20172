using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule2 : SpellChecker
	{
		public override bool Check(string word)
		{
			if (word.Length > 2)
			{
				bool isDouble =
				phuAm.Contains(word[0].ToString()) &&
				phuAm.Contains(word[1].ToString());

				if (isDouble && !phuAmDoiDau.Contains("" + word[0] + word[1]))
				{
					return false;
				}
			} 
			return true;
		}
	}
}
