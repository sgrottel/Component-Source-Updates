using ComponentSourceUpdate.ManifestEditor.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComponentSourceUpdate.ManifestEditor.IO
{

	/// <summary>
	/// Implements reading and writing for the canonical ManifestJson file format
	/// </summary>
	public static class ManifestJson
	{

		/// <summary>
		/// Loads component source data from a file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static Component[] Load(string path)
		{
			JsonDocument doc;
			using (Stream file = File.OpenRead(path))
			{
				doc = JsonDocument.Parse(file);
			}

			JsonElement root = doc.RootElement;
			if (root.ValueKind != JsonValueKind.Object)
			{
				throw new Exception("Root element expected to be an object");
			}

			JsonElement? type = null;
			JsonElement? version = null;
			JsonElement? components = null;
			foreach (var p in root.EnumerateObject())
			{
				switch (p.Name.ToLowerInvariant())
				{
					case "_type":
						type = p.Value;
						break;
					case "_version":
						version = p.Value;
						break;
					case "components":
						components = p.Value;
						break;
					default:
						throw new Exception(string.Format("Unexpected top-level property {0}", p.Name));
				}
			}

			if (type == null) throw new Exception("Required property '_type' is missing");
			if (type.Value.ValueKind != JsonValueKind.String) throw new Exception("Property '_type' must be of type string");
			string? typeStr = type.Value.GetString();
			if (typeStr == null) throw new Exception("Property '_type' must specify the format type identifier value");
			if (typeStr.Trim() != "ComponentSourceManifest") throw new Exception("Property '_type' must be 'ComponentSourceManifest'");

			if (components == null) throw new Exception("Required property 'components' is missing");
			if (components.Value.ValueKind != JsonValueKind.Array) throw new Exception("Property 'components' must be of type array");

			int versionValue = 1;
			if (version != null)
			{
				if (version.Value.ValueKind != JsonValueKind.Number) throw new Exception("Property '_version' must be of type number");
				versionValue = version.Value.GetInt32();
			}
			if (versionValue != 1) throw new Exception(string.Format("Specified format version '{0}' is not supported", versionValue));

			Component[] com = new Component[components.Value.GetArrayLength()];
			for (int i = 0; i < com.Length; ++i)
			{
				com[i] = ParseComponent(components.Value[i]);
			}

			return com;
		}

		private static Component ParseComponent(JsonElement json)
		{
			JsonElement? name = null;
			JsonElement? path = null;
			JsonElement? source = null;
			foreach (var p in json.EnumerateObject())
			{
				switch (p.Name.ToLowerInvariant())
				{
					case "name":
						name = p.Value;
						break;
					case "path":
						path = p.Value;
						break;
					case "source":
						source = p.Value;
						break;
					default:
						throw new Exception(string.Format("Unexpected component property {0}", p.Name));
				}
			}

			if (name == null) throw new Exception("Required component property 'name' is missing");
			if (name.Value.ValueKind != JsonValueKind.String) throw new Exception("Component property 'name' must be of type string");
			string? nameStr = name.Value.GetString();
			if (string.IsNullOrWhiteSpace(nameStr)) throw new Exception("Component property 'name' must not be null or empty");

			string? pathStr = ".";
			if (path != null)
			{
				if (name.Value.ValueKind != JsonValueKind.String) throw new Exception("Component property 'path' must be of type string");
				pathStr = path.Value.GetString();
				if (string.IsNullOrWhiteSpace(pathStr)) throw new Exception("Component property 'path' must not be null or empty");
			}

			if (source == null) throw new Exception("Required component property 'source' is missing");
			if (source.Value.ValueKind != JsonValueKind.Array) throw new Exception("Component property 'source' must be of type array");

			Component c = new Component() { Name = nameStr, Path = pathStr, Source = new object[source.Value.GetArrayLength()] };
			for (int i = 0; i < c.Source.Length; ++i)
			{
				c.Source[i] = ParseComponentSource(source.Value[i]);
			}

			return c;
		}

		private static object ParseComponentSource(JsonElement json)
		{
			throw new NotImplementedException();
		}
	}

}
