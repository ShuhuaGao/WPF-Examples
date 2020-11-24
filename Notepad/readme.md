The WPF Notepad project on [YouTube](https://www.youtube.com/playlist?list=PLKShHgmYjjFz_oV5bfFn9Sqo7loki0nWL)

The Stylet MVVM framework is adopted
- No need for `RelayCommand`. Instead, use the Action mechanism provided by Stylet.


In the last part ([part 8]()), we follow the viewmodel-first principle. That is, use the `WindowManager` of Stylet to show a `FormatViewModel` in *dialog* mode. The corresponding view `FormatView` (i.e., the dialog) is automatically located by Stylet, created, and its `DataContext` is set to the `FormatViewModel` instance.

Design of the `FormatView`  in *FormatView.xaml* is interesting and differs a lot from that one in the video.

0. We define the viewmodel, and then show it by `WindowManager` in Stylet.
```csharp
public void ShowFormatDialog()
{
    // public FormatViewModel Editor { get; set; } in above
    windowManager.ShowDialog(Editor);
}
```

1. Usage of the markup extension `x:static` to access *static* properties
```xml
            <ListBox ItemsSource="{x:Static media:Fonts.SystemFontFamilies}" 
                     SelectedItem="{Binding Format.Family}" SelectedIndex="0">
                <!--Format is a property of FormatViewModel, whose type is FormatModel-->
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <!--Text Binding to FontFamily itself: ToString or Converter-->
                        <TextBlock Text="{Binding}" FontFamily="{Binding}"/>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
```
- In the above, `{Binding}` refers to an item (i.e., a `FontFamily`) itself. Why does the `Text` property bind to a `FontFamily`? In fact, the Text property can bind to any object. If no special converter is provided, then the string representation of an object via `ToString` is used.
- `media` is a `xmlns`:
    ```csharp
    xmlns:media="clr-namespace:System.Windows.Media;assembly=PresentationCore"
    ```

2. How to define an array in xaml?
```xml
    <Window.Resources>
        <x:Array x:Key="FontSizeOptions" Type="sys:Int32">
            <sys:Int32>12</sys:Int32>
            <sys:Int32>18</sys:Int32>
            <sys:Int32>20</sys:Int32>
            <sys:Int32>28</sys:Int32>
            <sys:Int32>43</sys:Int32>
        </x:Array>
        <x:Array x:Key="FontStyleOptions" Type="win:FontStyle">
            <win:FontStyle>Normal</win:FontStyle>
            <win:FontStyle>Italic</win:FontStyle>
            <win:FontStyle>Oblique</win:FontStyle>
        </x:Array>
    </Window.Resources>
```

    Then we can feed the above array into the `ItemsSource` property of an `ItemsControl`

```xml
<ComboBox Margin="10" ItemsSource="{StaticResource FontStyleOptions}"
                        SelectedItem="{Binding Format.Style}">
```

3. About `ItemsSource` and `Items` properties of `ItemsControl`
> Note that you use either the Items or the ItemsSource property to specify the collection that should be used to generate the content of your ItemsControl. When the ItemsSource property is set, the Items collection is made read-only and fixed-size.

NOTE: there is difference in binding between `ItemsSource` and `Items` 
- If the items are specified (implicitly) by `ItemsSource` of type `IEnumerable`, then the `SelectedItem` binding corresponds to the exact data type `T`, i.e., the type of each object in `ItemsSource`.
- If the items are filled with `Items`, which is the content property `[System.Windows.Markup.ContentProperty("Items")]`, of type `ItemCollection`, then according to the collection syntax in xaml, we can list each item directly as follows
    ```xml
    <ComboBox SelectedIndex="1" Margin="5,5,10,5"
                      SelectedValue="{Binding Format.Weight}" SelectedValuePath="Content">
        <!--ItemsControl: set Items (ItemCollection) directly here-->
        <!--SelectedItem binding will not work: data convert-back error-->
        <ComboBoxItem Content="{x:Static win:FontWeights.Light}"/>
        <ComboBoxItem Content="{x:Static win:FontWeights.Normal}"/>
        <ComboBoxItem Content="{x:Static win:FontWeights.Bold}"/>
        <ComboBoxItem>
            <!--derive ContentControl-->
            <win:FontWeight>UltraBold</win:FontWeight>
        </ComboBoxItem>
    </ComboBox>
    ```
    Note that `ComboBoxItem` itself is a `ContentControl`. However, in this case, the `SelectedItem` refers to a `ComboBoxItem`, which cannot be converted to its binding source, a `FontWeight`. To avoid defining extra converters, a workaround is to bind the `SelectedValue` property, whose value is defined by the `SelectedValuePath`, that is, `ComboBoxItem.Content`.
