# TreeView to show the file system structure with MVVM
Follow this [tutorial](https://www.youtube.com/watch?v=U2ZvZwDZmJU&list=PLrW43fNmjaQVYF4zgsD0oL9Iv6u23PI6M&index=3). However, we only get inspiration from the overall idea but the implementation differs. In particular
+ No model class. In this example, all data are retrieved from the system at runtime.
+ No Command.
+ Code simplified. E.g., all file info related operations are implemented with the more convenient `DirectoryInfo` class.

## Key points
- Data template
- Style
- Trigger and `MultiDataTrigger`

## Notes about `TreeViewItem.IsExpanded`
1. It is a dependency property.
2. Even if an item has no expander shown (whose children collection is empty at that time), double click the item can still caused the change its property `IsExpanded` and raise the event `Expanded` or `collapsed`. That is why the file type is excluded in `SpawnChildren`.

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

## `MultiTrigger` to change the image of folder
We want that, once a folder node is expanded, its image because a opened folder image. Otherwise, the image is still the closed folder image.

Thus, one important trigger is the `TreeViewItem.IsExpanded` property. 
>There are several different types of triggers: Trigger, MultiTrigger, EventTrigger, DataTrigger, and MultiDataTrigger.

`Trigger` and `MultiTrigger` are used in `Style` and `ControlTemplate` (since they condition on property values of a control), while `DataTrigger` and `MultiDataTrigger` are used in a data template (since the two has binding support). 

The `TreeViewItem.IsExpanded` should naturally be used in `Trigger`. However, the `Image` in our data template cannot be accessed outside the template. Another issue is that the above image change should only be applied to a folder node, which depends on the `Type` property of the underlying viewmodel. That is, a `DataTrigger` is used.

Now the problem is how to combine a `DataTrigger` and a `Trigger`. One way is to place them together into a `MultiDataTrigger`. (We cannot use `MultiTrigger` here, because the `Condition.Binding` property is only applicable to `MultiDataTrigger` objects.)

### Access the control property in a data template
Suppose a data template has been prepared for a given control. How can we get the property of the control in this data template? Note that the data context of this data template is a data source (usually a viewmodel) rather than the control. 

The trick is to use relative binding that locates the control as an ancestor of this data template. However, doing this may make the data template coupled with this particular control.

Let's play with relative binding. In the original `HierarchicalDataTemplate`, add
```xml
<HierarchicalDataTemplate.Triggers>
    <DataTrigger Binding="{Binding IsExpanded, 
        RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}}}" Value="True">
        <Setter TargetName="image" Property="Source" Value="pack://siteoforigin:,,,/images/folder-open.png"/>
    </DataTrigger>
</HierarchicalDataTemplate.Triggers>
```
Now we have got the `IsExpanded` property of the target `TreeViewItem`. One interesting point of a `Trigger` is that its effect is transient. That is, **once the trigger condition is not satisfied, it will return to the old state before triggering.**

## Combine two data triggers
The remaining issue is that the above trigger applies to all kinds of nodes (including drives and folders). We need to add another condition.
```xml
<HierarchicalDataTemplate.Triggers>
    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding IsExpanded, 
                RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}}}" Value="True"/>
            <!--enum value can be specified as string directly-->
            <Condition Binding="{Binding Type}" Value="Folder"/>
        </MultiDataTrigger.Conditions>
        <Setter TargetName="image" Property="Source" Value="pack://siteoforigin:,,,/images/folder-open.png"/>
    </MultiDataTrigger>
</HierarchicalDataTemplate.Triggers>
```

### Final note
We can also choose to change `DirectoryItemViewModel.ImageUri` property value in code directly in the setter of `IsExpanded`, which seems simpler. Of course, in that case, we have to notify the change of `ImageUri`. In the XAML above, the main purpose is to practice `MultiDataTrigger`.
 

