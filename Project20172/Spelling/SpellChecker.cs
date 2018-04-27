using Spelling.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling
{
	class SpellChecker
	{
		public string[] phuAm = {
			"b", "c", "d", "đ", "g", "h", "k", "l", "m",
			"n", "p", "q", "r", "s", "t", "v", "x"
		};

		public string[] phuAmDoiDau =
		{
			"nh", "ng", "ph", "th", "tr", "ch", "gh", "kh"
		};

		public string[] phuAmBa = {
			"ngh"
		};

		public string[] phuAmCuoi = {
			"c", "m", "n", "p", "t"
		};

		public string[] phuAmDoiCuoi =
		{
			"ng", "nh", "ch"
		};

		public string[] nguyenAm = {
			"a", "á", "à", "ả", "ã", "ạ",
			"ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
			"â", "ấ", "ầ", "ẩ", "ẫ", "ậ",
			"e", "é", "è", "ẻ", "ẽ", "ẹ",
			"ê", "ế", "ề", "ể", "ễ", "ệ",
			"i", "í", "ì", "ỉ", "ĩ", "ị",
			"o", "ó", "ò", "ỏ", "õ", "ọ",
			"ô", "ố", "ồ", "ổ", "ỗ", "ộ",
			"ơ", "ớ", "ờ", "ở", "ỡ", "ợ",
			"u", "ú", "ù", "ủ", "ũ", "ụ",
			"ư", "ứ", "ừ", "ử", "ữ", "ự",
			"y", "ý", "ỳ", "ỷ", "ỹ", "ỵ"
		};

		public virtual bool Check(string word)
		{
			List<SpellChecker> rules = new List<SpellChecker>();
			rules.Add(new Rule1());
			rules.Add(new Rule2());
			rules.Add(new Rule3());
			rules.Add(new Rule4());
			rules.Add(new Rule5());
			rules.Add(new Rule6());
			rules.Add(new Rule7());
			rules.Add(new Rule8());
			rules.Add(new Rule9());
			for (int i = 0; i < rules.Count; i += 1)
			{
				if (word.Length == 0 || !rules[i].Check(word.ToLower()))
				{
					Console.WriteLine(i + 1);
					return false;
				}
			}
				
			return true;
		}

		public bool isPhuAm(char character)
		{
			return phuAm.Contains("" + character);
		}

		public bool isNguyenAm(char character)
		{
			return !phuAm.Contains("" + character);
		}
	}
}
