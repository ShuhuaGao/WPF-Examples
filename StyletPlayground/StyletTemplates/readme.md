# Project template for the MVVM framework `Stylet` with "Views" and "ViewModels" folders
[Stylet](https://github.com/canton7/Stylet) has provided a default template called *Stylet.Templates*. However, that template creates a single `Pages` folder that contains both the views and the viewmodels.

In this template, two separate folders "ViewModels" and "Views" are created instead for the viewmodels and views, respectively.

This template package has been published to [NuGet](https://www.nuget.org/packages/Stylet.Templates.VM/).

## Usage

1. Install this template by typing the following command in a terminal
```
dotnet new --install Stylet.Templates.VM
```
2. Create a new project with the installed `stylet.vm` template, e.g., 
```
dotnet new stylet.vm -n MyProj
```
where you specify your project name after `-n`.