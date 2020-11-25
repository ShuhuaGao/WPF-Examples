This project aims to play with 
- Custom tab control. Each item header has an additional close button, which is visible if the tab item is selected or the mouse is over it.
- A collection of screens managed by `Conductor.Collection.OneActive`.

## Custom Tab Control

Main references [[1]](https://stackoverflow.com/a/28299651/14020277) and [[2]](https://stackoverflow.com/questions/14821067/wpf-tabitem-onmouseover-shall-trigger-the-visibility-of-a-button-inside-the-tabi) and [[3]](https://caliburnmicro.com/documentation/composition).

The key is to provide a `DataTemplate` for `TabControl.ItemTemplate` to customize its appearance. 

- Note that `TabControl.ItemTemplate` only applies to `TabItem`s that are produced by `ItemsSource`. Each generated `ItemTab` shares the same template.
- If we add `<TabItem>` directly in XAML, then the `DataTemplate` will not work. We see error message 
    ```
    System.Windows.Data Error: 26 : ItemTemplate and ItemTemplateSelector are ignored for items already of the ItemsControl's container type TabItem
    ```
  
  In the above case where we add `TabItem` manually, we can change its appearance by setting the `HeaderedContentControl.HeaderTemplate` and `HeaderedContentControl.ContentTemplate`, since `TabItem` is a `HeaderedContentControl`. A potential advantage of this method is that the template can be set on an individual basis, i.e., each `TabItem` can have its own template.
    See [this stackoverflow](https://stackoverflow.com/a/25265513/14020277) and [`HeaderedContentControl.HeaderTemplate`](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.headeredcontentcontrol.headertemplate?view=net-5.0#System_Windows_Controls_HeaderedContentControl_HeaderTemplate).