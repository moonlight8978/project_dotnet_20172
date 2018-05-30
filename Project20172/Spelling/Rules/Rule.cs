using Spelling.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelling
{
	class Rule
	{
		public string[] phuAm = {
			"b", "c", "d", "đ", "g", "h", "k", "l", "m",
			"n", "p", "q", "r", "s", "t", "v", "x", "ð"
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

		public virtual bool Check(Word word)
		{
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
