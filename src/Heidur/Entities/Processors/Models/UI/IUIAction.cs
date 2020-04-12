using System;

namespace Heidur.Entities.Processors.Models.UI
{
	public interface IUIAction
	{
		Action Action { get; set; }
		void Execute();
	}
}
