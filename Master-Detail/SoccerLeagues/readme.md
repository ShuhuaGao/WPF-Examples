Try to reproduce the official example [How to: Use the Master-Detail Pattern with Hierarchical Data](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-5.0).

## Prepare data
Define three classes `League`, `Division`, and `Team`. The former contains multiple instances of the latter.

### Add an array of `League`
Generally, a collection of data is exposed by a property of a cetain class. Here, we define a colletion directly in XAML as the resource using `x:array`.
```xml
<x:Array x:Key="leagues" Type="local:League">
    <local:League/>
    <local:League/>
</x:Array>
```
- `Type` is the type of the array element
- A default constructor should be available. Otherwise, define the collection in code.

## UI
```xml
<Grid DataContext="{StaticResource leagues}">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="auto"/>
        <ColumnDefinition Width="auto"/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <StackPanel Grid.Column="0" Margin="10">
        <Label>My Soccer Leagues</Label>
        <ListBox ItemsSource="{Binding}"
            IsSynchronizedWithCurrentItem="true"/>
    </StackPanel>

    <StackPanel Grid.Column="1" Margin="10">
        <Label Content="{Binding Path=/}"/>
        <ListBox ItemsSource="{Binding Path=Divisions}" DisplayMemberPath="Name"
            IsSynchronizedWithCurrentItem="true"/>
    </StackPanel>

    <StackPanel Grid.Column="2" Margin="10">
        <Label Content="{Binding Path=/Divisions/Name}"/>
        <ListBox DisplayMemberPath="Name" ItemsSource="{Binding Path=/Divisions/Teams}"/>
    </StackPanel>
</Grid>
```

## About binding
### Source
In all bindings, no source is specified. Thus, 
>bindings inherit the data context specified by the DataContext property, if one has been set

The source of all bindings thus points to the closest upper-level `DataContext` in the logical tree, that is, the `DataContext`of the `Grid`.
### Path
Check [official documentation](https://docs.microsoft.com/en-us/dotnet/api/system.windows.data.binding.path?redirectedfrom=MSDN&view=net-5.0#remarks).

- `{Binding}` is equivalent to `{Binding Path=.}`, that is, the data source itself (rather than its property)
- About `{Binding Path=/}`.
    >When the source is a collection view, the current item can be specified with a slash (/). For example, the clause Path=/ sets the binding to the current item in the view. When the source is a collection, this syntax specifies the current item of the default collection view.
- About `{Binding Path=/Division/Teams}`
    >Property names and slashes can be combined to traverse properties that are collections. For example, Path=/Offices/ManagerName specifies the current item of the source collection, which contains an Offices property that is also a collection. Its current item is an object that contains a ManagerName property.
    
    Note that, in a "slash-property" mixed path, the leading slash may be omitted. That is, `{Binding Path=/Division/Teams}` is equivalent to `{Binding Path=Division/Teams}`. However, if there is only a slash, i.e., `Path=/`, it cannot be ignored; otherwise, it becomes in fact `Path=.`. It is clearer to write down the leading slash explicitly.
### Master detail synchronization mechanism
The key observation is that `/` in a path refers to the *current* item. However, which one is the current one? This is exactly the purpose of `IsSynchronizedWithCurrentItem="true"`. It is a property of class `Selector` < `ItemsControl`, whose sub-classes include `ComboBox`, `ListBox`, `TabControl`, etc.
>Gets or sets a value that indicates whether a Selector should keep the SelectedItem synchronized with the current item in the Items property.

Thus, once we select an item in a `Selector`, the *current* item of its `ItemsSource` becomes the selected one. Other controls **that share the same data source**, typically a DataContext of their common parent, can use `/` in binding path to pick the *current* item. 

In this example, all bindings will finally resolve their `Source` to the `Grid`'s `DataContext`, i.e., an array of `League` given by the window resource. In other words, we can also put the data to an even higher-level UI, like the `Window`.

#### More about CollectionView

On further inspection, we may notice that `ItemsSource` only requires an `IEnumerable`, which has no property like current item. How is it done? The magic likes in two classes `CollectionViewSource` and `CollectionView` (which has property `CollectionView.CurrentItem`). 
    >You can think of a collection view as the layer on top of the binding source collection that allows you to navigate and display the collection based on sort, filter, and group queries, all without having to manipulate the underlying source collection itself. 

In short, our `IEnumerable` collection data is wrapped by `CollectionView` which is then consumed by XMAL. The current item is recorded by `CollectionView.CurrentItem` internally, which is observed by all controls that take the collection as their data source. In `Binding` markup extension, the *current* item of a collection is accessed by `/` in `Path`.

If no selection happens, then the *current* item defaults to the first one. 


Note that a custom `CollectionView` (via `CollectionViewSource`) can explicitly defined in XAML for advanced customization. Check [this example](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.itemscontrol.displaymemberpath?view=net-5.0#examples)

## About data presentation/visualization
Note that we did not provide any data template to render our data. Internally, the content of a `ContentControl` is displayed by its internal `ContentPresenter` (accessible in a control template). The logic (order) of display is illustrated [here](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.contentpresenter?view=net-5.0#remarks).

In short, if no special renderer is provided, like `DataTemplate1, `TypeConverter`, etc., then `ContentPresenter` makes its last choice:
>The ContentPresenter calls the ToString method on the Content and creates a TextBlock to contain the string returned by ToString. The TextBlock is displayed.

That is, any `object` is displayed by `ToString` using a `TextBlock`.

Note the first `ListBox`
```xml
<ListBox ItemsSource="{Binding}"
            IsSynchronizedWithCurrentItem="true"/>
```
We did not specify how to render each item (i.e., a `League`). Then, its `ToString` is used
```csharp
public override string ToString()
{
    return "league: " + name;
}
```

By contrast, for the last two `ListBox`, a `DisplayMemberPath` is specified.
```xml
<ListBox ItemsSource="{Binding Path=/Divisions}" DisplayMemberPath="Name"
               IsSynchronizedWithCurrentItem="true"/>
```
This is a convenient property provided by `ItemsControl`
>Gets or sets a path to a value on the source object to serve as the visual representation of the object.

It is useful if the data template we want is just a naive one to pick one property of an item for display.
>This property is a simple way to define a default template that describes how to display the data objects.








