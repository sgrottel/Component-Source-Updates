using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentSourceUpdate.ManifestEditor.DataModel
{

	/// <summary>
	/// Component source description on Git
	/// </summary>
	public class SourceGit
	{

		/// <summary>
		/// The main url of the git repository
		/// </summary>
		public Uri? Url { get; set; }

		/// <summary>
		/// The specific, full hash of the commit of the current state of the component
		/// </summary>
		public string? Hash { get; set; }

		/// <summary>
		/// The version of the current state of the component
		/// </summary>
		public Version? Version { get; set; }

		/// <summary>
		/// An optional subselection of the available data on git to identify updates
		/// </summary>
		public enum SubSelection
		{
			/// <summary>
			/// All of git will be used
			/// </summary>
			None,

			/// <summary>
			/// Only Releases on github for the specific target repository will be used
			/// </summary>
			GithubReleases,

			/// <summary>
			/// Only commits with tags on github for the specific target repository will be used
			/// </summary>
			GithubTags,
		};

		/// <summary>
		/// Restricts to check for updates to a selection of parts of the data available thru git
		/// </summary>
		public SubSelection Selection { get; set; } = SubSelection.None;

	}

}
