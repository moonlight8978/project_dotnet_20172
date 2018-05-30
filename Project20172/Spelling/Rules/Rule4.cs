﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Rule4 : Rule
	{
		public override bool Check(Word word)
		{
			bool nguyenAmFound = false;
			foreach (char character in word.original)
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
