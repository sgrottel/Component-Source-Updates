# 🔃 Component Source Updates
Scanner for Component Source Updates

For this tool the term "Components" aims at files, e.g. source code files, which are not managed or installed via a packet management system, which could take care of versioning.
Typical examples are:

* Small software utilities without installers, (aka, portable, download and unzip)
* C++ libraries / header-only libraries which are integrated into a project by being copied into it

Those components still have an official source, like a Github project, hosting new releases.
This scanner utility scans your file system for _Component-Source Manifest_ files, specifying those sources for such components.
It will then scan the sources for updates, report the findings, and notifies the user.

This tool is close in spirit to Component Governance and Dependency scanner applications.


# Mark a Component and Specify its Source
🚧 TODO - Document how to write component manifests


# Scan for Component Source Updates
🚧 TODO - Document scan app usage


# How-To Build this Application
🚧 TODO - Document how to develop this tool


# License
This project is freely available under the terms of the [Apache License Version 2.0](./LICENSE)

> Copyright 2022 SGrottel
>
> Licensed under the Apache License, Version 2.0 (the "License");
> you may not use this file except in compliance with the License.
> You may obtain a copy of the License at
>
> http://www.apache.org/licenses/LICENSE-2.0
>
> Unless required by applicable law or agreed to in writing, software
> distributed under the License is distributed on an "AS IS" BASIS,
> WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
> See the License for the specific language governing permissions and
> limitations under the License.
