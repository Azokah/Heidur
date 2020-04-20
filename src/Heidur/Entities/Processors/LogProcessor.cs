using System.Collections.Generic;

namespace Heidur.Entities.Processors
{
	public static class LogProcessor
	{
		public static List<string> log = new List<string>();

		public static void AppendToLog(string text)
		{
			log.Insert(0, text);
		}
	}
}
