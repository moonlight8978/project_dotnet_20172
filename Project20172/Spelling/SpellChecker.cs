using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class SpellChecker
	{
		public List<Rule> rules;
		public SpellChecker()
		{
			rules = new List<Rule>();
			rules.Add(new Rule1());
			rules.Add(new Rule2());
			rules.Add(new Rule3());
			rules.Add(new Rule4());
			rules.Add(new Rule5());
			rules.Add(new Rule6());
			rules.Add(new Rule7());
			rules.Add(new Rule8());
			rules.Add(new Rule9());
			rules.Add(new Rule10());
			rules.Add(new Rule11());
			rules.Add(new Rule12());
			rules.Add(new Rule13());
			rules.Add(new Rule14());
			rules.Add(new Rule15());
			rules.Add(new Rule16());
		}

		public bool Check(string word)
		{
			Word w = new Word(word.ToLower());
			for (int i = 0; i < rules.Count; i += 1)
			{
				if (word.Length == 0 || !rules[i].Check(w))
				{
					Console.WriteLine(i + 1);
					return false;
				}
			}

			return true;
		}
	}
}
