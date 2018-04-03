using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project20172.Finding
{
	public class Paragraph
	{
		public string content { get; set; }
		public string number { get; set; }

		public Paragraph(string number, string content)
		{
			this.number = number;
			this.content = content;
		}
	}
}