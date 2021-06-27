# A demo to learn AvalonDock (accompanied by Stylet)

## Tutorials
Mainly follow the tutorials listed at https://github.com/Dirkster99/AvalonDock, but try to simplify it with the dedicated MVVM framework *Stylet*.

## Required NuGet Packages
- Dirkster.AvalonDock
- Stylet
- Template [Stylet.Templates.VM](https://www.nuget.org/packages/Stylet.Templates.VM/) to generate a Stylet project quickly by 
    ```
    dotnet new stylet.vm -n EdiAvalon
    ```

## Some explanations
### How to render a data object (viewmodel) in Avalon dock?
- A simple way: define an automatically applied `DataTemplate` for the given viewmodel type. See [this commit](https://github.com/ShuhuaGao/WPF-Examples/tree/668e3099bcd7b5959ffd1dd1491a6f7a657b72e5/Control3rdParty/EdiAvalon).
    ```xml
    <Window.Resources>
        <DataTemplate DataType="{x:Type vm:FileViewModel}">
            <TextBlock Background="Turquoise" Text="{Binding TextContent}" />
        </DataTemplate>
    </Window.Resources>
    ...
    <ad:DockingManager x:Name="dockManager">
        <ad:LayoutRoot>
            <ad:LayoutPanel>
                <ad:LayoutDocumentPane>
                    <!-- `Content` refers to the `FileViewModel` instance below -->
                    <ad:LayoutDocument Title="{Binding RelativeSource={RelativeSource Self}, Path=Content.Title}" CanFloat="False">
                        <!-- rendered by the DataTemplate in Window.Resources -->
                        <vm:FileViewModel />
                    </ad:LayoutDocument>
                </ad:LayoutDocumentPane>
            </ad:LayoutPanel>
        </ad:LayoutRoot>
    ```


### Get the currently active content (usually a viewmodel)
- `DockingManager.ActiveContent: object` and its event 
    ```csharp
    public object ActiveContent {get; set;}
    public event EventHandler ActiveContentChanged
    ```
    Note that the `ActiveContent` actually refers to the underlying viewmodel in a pane.
- It is common that the active content (i.e., a visual pane) is chosen by the user and changed frequently. Besides, multiple objects may need to know the `ActiveContent`, e.g., other `LayoutContent`s. Nonetheless, we can only set up one source for `ActiveContent` binding.
- To allow the information propagation to multiple objects, we may use a global *broker* or use the event mechanism (i.e., listening on `ActiveContentChanged`) in an event aggregator.