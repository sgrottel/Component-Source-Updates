# 🔃 ComponentSource.json Manifest
This is the canonical file format of the Component Source Updates tool.

These are json files named `ComponentSource.json`.
Upper or lower cases for the file names are possible and do not matter.

This is an example content:
```json
{
	"_type": "ComponentSourceManifest",
	"_version": 1,
	"components": [
		{
			"name": "Component-Source-Updates",
			"path": ".",
			"source": [
				{
					"type": "git",
					"url": "https://github.com/sgrottel/Component-Source-Updates.git",
					"hash": "0123456789abcdef0123456789abcdef01234567",
					"version": "0.1",
					"selection": "github releases"
				}
			]
		}
	]
}
```

Consult the description properties in the [Schema](./ComponentSource.Schema.json) for details.

## Enable Schema in Visual Studio Code
You can either explicitly specify the schema url in your ComponentSource manifest json file (not recommended), or you can configure Visual Studio Code to associate all `ComponentSource.json` manifest files with the schema (recommended).

Edit `settings.json` for the user and add or edit:
```json
"json.schema": [
	{
		"fileMatch": [
			"/ComponentSource.json"
		],
		"url": "https://go.grottel.net/ComponentSource/schema.json"
	}
]
```


## Details on the Schema properties

### Property `/components`
This is the array of objects describing the state and sources of the components listed in this manifest.

You can either have one manifest per component, or one manifest per project, or even only one manifest per machine.
If, during a scan, multiple manifest component entries are found, that link to the same target path, the file closest to that path, i.e. minimum number of directory levels as distance, gets priority.

### Property `/components/source`
This is the array of source description objects of the component.
The order of the objects in the array defines the priority from high/top of list to low/bottom of the list.
At least one entry is required.

### Property `/components/source[type=git]/selection`
This field allows to select a subset of the git repository.
Newer commits in the repository but outside of the selection will not be considered component updates.

Supported Values:

* `"none"` (string) -- The whole git repository will be included in the search for updates (no subset).
* `"github releases"` (string) -- The git repository is assumed to be hosted at [github.com](https://github.com), and is assumed to use github's releases feature.
  Only commits references by releases are selected.
  Specified `version` values relate to release titles.
* `"tags"` (string) -- Only tagged git commits will be included in the search for updates.
  Specified `version` values relate to tag names.
