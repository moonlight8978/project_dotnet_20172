using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule1 : Rule
	{
		public override bool Check(Word word)
		{
			string[] eng = { "w", "z", "j", "f" };
			foreach (char character in word.original)
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
