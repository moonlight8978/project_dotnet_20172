using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule1 : SpellChecker
	{
		public override bool Check(string word)
		{
			string[] eng = { "w", "z", "j", "f" };
			foreach (char character in word)
			{
				if (eng.Contains(character.ToString()))
				{
					return false;
				}
			}
			return true;
		}
	}
}
