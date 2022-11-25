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
					"hash": "0123456789abcdef",
					"version": "0.1",
					"selection": "github releases"
				}
			]
		}
	]
}
```


## `_type` (required)
Must specify `"ComponentSourceManifest"` (string) as value.


## `_version` (recommended)
The value is an integer defining the version of the file format.

If missing, the value `1` (int) is assumed.


## `components` (required)
This is the array of objects describing the state and sources of the components listed in this manifest.

You can either have one manifest per component, or one manifest per project, or even only one manifest per machine.
If, during a scan, multiple manifest component entries are found, that link to the same target path, the file closest to that path, i.e. minimum number of directory levels as distance, gets priority.


## Component `name` (required)
A uniquely identifier name of the component.

A human-readable form is recommended.

The component should always be named consistently.


## Component `path` (optional)
The file system path where the component resides.

If missing, the value `"."` (string) is assumed, pointing to the local path where the json file is stored.


## Component `source` (required)
This is the array of source description objects of the component.
The order of the objects in the array defines the priority from high/top of list to low/bottom of the list.
At least one entry is required.

Each source description object must specify the `type` field.


## Source Type `Git`
Use this source description to target a git repository as source of the component.

```json
{
	"type": "git",
	"url": "https://github.com/sgrottel/Component-Source-Updates.git",
	"hash": "0123456789abcdef",
	"version": "0.1",
	"selection": "github releases"
}
```

### `type` (required)
Value must be `"git"` (string).

Lower case recommended.

### `url` (required)
The Url to the git repository.

### `hash` (required)
Specifies the full commit hash of the current state of the component.

Do not use a short commit hash variant.

### `version` (optional)
If the current state of the component relates to a released version, this field can be used to specify the respective version number.

### `selection` (optional)
This field allows to select a subset of the git repository.
Newer commits in the repository but outside of the selection will not be considered component updates.

Supported Values:

* `"github releases"` (string) -- The git repository is assumed to be hosted at [github.com](https://github.com), and is assumed to use github's releases feature.
Only releases referencing a commit are selected.

