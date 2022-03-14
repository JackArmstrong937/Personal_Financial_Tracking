using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Practice_Coding.Models
{
	[Serializable]
	[XmlType("Categories")]
	public class Categories : List<Category> {}

	[Serializable]
	[XmlType("Category")]
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public bool Active { get; set; }
		public float Total { get; set; }
	}
}