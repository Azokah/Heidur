using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Heidur.Entities.Processors
{
	public static class TemplatesProcessor
	{
		public static Dictionary<int, string> templates = new Dictionary<int, string>();
		public static DirectoryInfo path = new DirectoryInfo(@"..\..\..\..\Content\Templates\");

		public static void LoadTemplates()
		{
			foreach (var file in path.GetFiles("*.json"))
			{
				using (StreamReader r = new StreamReader(file.FullName))
				{
					string json = r.ReadToEnd();

					JObject o = JObject.Parse(json);

					templates.Add(Convert.ToInt32(o["id"]), o.ToString());
				}
			}
		}
	}
}
