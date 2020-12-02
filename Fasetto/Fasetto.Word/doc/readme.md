# Include font resources
- A font can be used by (1) specify the URI and the font name directly in `FontFamily` attribute. 
- Define the font as a resource and then use it as `StaticResource`. When creating the resource, the URI and the font name are specified.
The URI refers to the **folder** that contains the font file.
We can use relative or absolute pack URI in the XAML.
![](img/fonts.png)

Also See this [doc](https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.fontfamily?view=net-5.0#specifying-fonts-in-alternate-directories) for the above methods.

Note that, to embed the font into the assembly, the build action should be *Resource*. In this case, the `pack://application:,,,` authority must be used (or its relative version). We can also set the build action to `None` or `Content` and asks VS to copy the resources to the output folder. Then, use `pack://siteoforigin:,,,` to access them.

# `TextBlock` style `BasedOn`
The peculiarity of `TextBlock` is that it inherits `FrameworkElement` directly (rather than `Control`). Thus, a base style for `Control` cannot be inherited via `BasedOn` in a `TextBlock` style.
>InvalidOperationException: Can only base on a Style with target type that is base type 'TextBlock'

One solution is given [here](https://stackoverflow.com/questions/25586037/invalidoperationexception-can-only-base-on-a-style-with-target-type-that-is-bas), which defines a base style for `FrameworkElement` and uses attached property for `Setter`.

A possibly simple way is just to handle `TextBlock` separately.

# Borderless window

## Importance changes in newer .Net versions
- Unlike the video tutorial, no need to install the NuGet package now. The `WindowChrome` class has been built-in after .Net 4.5. See (WindowChrome Class)[https://docs.microsoft.com/en-us/dotnet/api/system.windows.shell.windowchrome?view=net-5.0#definition] and the excellent explanation therein on how to customize the window.
- To bind a `Thickness`-like type to a *single* number, there is no need to define a converter nor to return a `Thickness` directly. There is `System.Windows.ThicknessConverter` after .NET 3.0. We can check its [source code](https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/ThicknessConverter.cs,4c4a0e5660ee993d) to confirm what kinds of types it supports.  For example,
```csharp
public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object source)
{
    if (source != null)
    {
        if (source is string)      { return FromString((string)source, cultureInfo); }
        else if (source is double) { return new Thickness((double)source); }
        else                       { return new Thickness(Convert.ToDouble(source, cultureInfo)); }
    }
    throw GetConvertFromException(source);
}
```
which means any type can be converted to `double` can be used. 
- It seems that the `WindowChrome.CornerRadius` is reduced to zero automatically once the window is maximized. Thus, no need to follow the window to handle the maximization event.