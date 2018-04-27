using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule3 : SpellChecker
	{
		public override bool Check(string word)
		{
			if (word.Length > 3)
			{
				bool isTriple =
				phuAm.Contains(word[0].ToString()) &&
				phuAm.Contains(word[1].ToString()) &&
				phuAm.Contains(word[2].ToString());

				if (isTriple && !phuAmBa.Contains("" + word[0] + word[1] + word[2]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
