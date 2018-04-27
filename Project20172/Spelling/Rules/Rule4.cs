using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule4 : SpellChecker
	{
		public override bool Check(string word)
		{
			bool nguyenAmFound = false;
			foreach (char character in word)
			{
				if (!phuAm.Contains("" + character))
				{
					nguyenAmFound = true;
				}
			}	
			if (!nguyenAmFound)
			{
				return false;
			}
			return true;
		}
	}
}
