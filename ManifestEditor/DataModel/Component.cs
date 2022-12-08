using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentSourceUpdate.ManifestEditor.DataModel
{

	/// <summary>
	/// A source component
	/// </summary>
	public class Component
	{
		public string? Name { get; set; }

		public string? Path { get; set; }

		public object[] Source { get; set; } = Array.Empty<object>();

	}

}
