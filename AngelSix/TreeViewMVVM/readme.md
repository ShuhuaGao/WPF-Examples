# TreeView to show the file system structure with MVVM
Follow this [tutorial](https://www.youtube.com/watch?v=U2ZvZwDZmJU&list=PLrW43fNmjaQVYF4zgsD0oL9Iv6u23PI6M&index=3). However, we only get inspiration from the overall idea but the implementation differs. In particular
+ No model class. In this example, all data are retrieved from the system at runtime.
+ No Command.
+ Code simplified. E.g., all file info related operations are implemented with the more convenient `DirectoryInfo` class.

## `HierarchicalDataTemplate`
This data template is especially useful to *recursive* `HeaderedItemsControl`, such as TreeViewItem or MenuItem.
Its main part is just like a normal `HeaderTemplate`. However, it has a property `ItemsSource` (an analogy to `ItemsControl.Items`) that species the source for the next-level controls. 

Different levels in the hierarchy may refer to different types of data. Each data type should have its own `HeaderedItemsControl`.

See the [official example](https://docs.microsoft.com/en-us/dotnet/api/system.windows.hierarchicaldatatemplate?view=net-5.0#examples).

## Set property of the auto-generated `TreeViewItem`
Since each tree view item is generated dynamically, we cannot set its property directly. In this case, assign a style to it in which the property is set in `Setter`.
```xml
<TreeView ItemsSource="{Binding Drives}">
    <TreeView.Resources>
        <Style TargetType="{x:Type TreeViewItem}">
            <!--the data context of TreeViewItem is DirectoryItemViewModel-->
            <!-- the expanded state can only be changed by user input (rather than by view model) by Mode=OneWayToSource-->
            <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=OneWayToSource}"/>
            <Setter Property="ToolTip" Value="{Binding FullPath}"/>
        </Style>
    </TreeView.Resources>
</TreeView>
```

## When the binding property is a collection
This is especially true for `ItemsSource` property. To allow binding with property changed notification, the collection-type property of the view model must implement the INotifyCollectionChanged interface. 

That is, the *source* itself may not even implement `INotifyPropertyChanged` (not necessary), but the collection property for binding must implement INotifyCollectionChanged. See [reference](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/binding-sources-overview?view=netframeworkdesktop-4.8#using-collection-objects-as-a-binding-source).

For instance, if we have a property `Children` of type `List`, then it is not qualified as a binding property since no notification can be sent, even if the view model itself notifies the change of the property `Children`.
>The ObservableCollection<T> class is a built-in implementation of a data collection that exposes the INotifyCollectionChanged interface. 

In short, if we want expose a collection-like property for binding, then it must be `ObservableCollection<T> ` or similar ones.
```csharp
public ICollection<DirectoryItemViewModel> Children { get; private set; } = new ObservableCollection<DirectoryItemViewModel>();
```
Refer to also this [stackoverflow](https://stackoverflow.com/questions/16297983/inotifycollectionchanged-is-not-updating-the-ui).


### If a property never changes, then no NPC
In this example, one a `DirectoryItemViewModel` is instantiated, most properties (except `Children`) are fixed. Thus, there is no need to implement INPC for notifications and one-way binding is enough. As for the `Children`, its update is handled already by the `ObservableCollection`.

