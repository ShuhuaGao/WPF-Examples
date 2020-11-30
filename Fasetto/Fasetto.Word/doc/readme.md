# Include font resources
- A font can be used by (1) specify the URI and the font name directly in `FontFamily` attribute. See this [doc](https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.fontfamily?view=net-5.0#specifying-fonts-in-alternate-directories).
- Define the font as a resource and then use it as `StaticResource`. When creating the resource, the URI and the font name are specified.
The URI refers to the folder than contains the font file (WPF does not recommend absolute pack URI though; see [here](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/packaging-fonts-with-applications?view=netframeworkdesktop-4.8#limitations-on-font-usage)).
We can use relative pack URI. 
![](img/fonts.png)
