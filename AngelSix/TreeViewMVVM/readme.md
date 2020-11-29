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