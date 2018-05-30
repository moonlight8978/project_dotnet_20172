using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling.Rules
{
	class Word
	{
		public string first;
		public string last;
		public string original;

		public string[] phuAm = {
			"b", "c", "d", "đ", "g", "h", "k", "l", "m",
			"n", "p", "q", "r", "s", "t", "v", "x", "ð"
		};

		private string[] ii = {
			"i", "í", "ì", "ỉ", "ĩ", "ị"
		};

		private string[] uu =
		{
			"u", "ú", "ù", "ủ", "ũ", "ụ"
		};

		public Word(string word)
		{
			original = word;
			split();
		}

		private void split()
		{
			var n = 0;
			for (int i = 0; i < original.Length; i += 1)
			{
				if (
					phuAm.Contains("" + original[i]) ||
					(i-1 >= 0 && original[i-1] == 'g' && ii.Contains("" + original[i])) ||
					(i-1 >= 0 && original[i-1] == 'q' && uu.Contains("" + original[i]))
				) {
					n += 1;
				} else
				{
					break;
				}
			}
			first = original.Substring(0, n);
			last = original.Substring(n, original.Length - n);
		}

		public bool IsFirstPresent()
		{
			return first != "";
		}

		public bool IsLastPresent()
		{
			return last != "";
		}
	}
}
