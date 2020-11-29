# TreeView (without MVVM)
Follow [this tutorial](https://www.youtube.com/watch?v=6OwyNiLPDNw&list=PLrW43fNmjaQVYF4zgsD0oL9Iv6u23PI6M&index=2&t=147s).

**Class hierarchy**

Control
    -> ItemsControl
        -> HeaderedItemsControl
            -> TreeViewItem

Note that a `TreeViewItem` can contain more `TreeViewItem`s (or even other controls). Thus, it is an `ItemsControl` itself.
>TreeViewItem is a HeaderedItemsControl, which means its header and collection of objects can be of any type (such as string, image, or panel). 

*HeaderedItemsControl.HeaderTemplate*


On the other hand, Control -> ItemsControl -> TreeView.
>Gets or sets the template used to display the contents of the control's header.

The `HeaderedItemsControl.Header` can be any `object`.

The data display of a `TreeViewItem` is customized by its `HeaderTemplate`.


### Key points
- Style
- HeaderTemplate
- Binding relative source
- File IO checking operations


## How to adjust the expander visibility?
https://stackoverflow.com/questions/7905881/wpf-treeviewitem-toggle-button-visibility

>If you see the deafult controlTemplate of TreeViewItem, you will see that visibility of Toggle button is bound to ItemsControl.HasItems.

Thus, if we want to show the expander button even if there are no items added yet, we should either change the control template or add a *dummy* item (such as null), but clear it in the `Expanded` event.

**Note**: 
- to expand an item in the absence of the expander triangle, double click the item, which also raises the `Expanded` routed event.
- The `TreeViewItem.Expanded` routed event has a bubbling strategy, which means we have to indicate that it is handed; otherwise, a child's event will propagate to its parents. 

## Different appearance of a `TreeViewItem` for different data
Method 1: `DataTrigger` in the `HeaderTemplate`, especially in a full MVVM setting.

Method 2: converter that converts the original data to different target data. Check [ValueConverters.NET](https://github.com/thomasgalliker/ValueConverters.NET) for a library of common converters.

## How to access the original `TreeViewItem` in its data template?
We have to use `RelateSource` here.
```xml
<Image Width="32" Margin="5"
       Source="{Binding Tag, RelativeSource={RelativeSource AncestorType={x:Type TreeViewItem}}, 
         Mode=OneWay, Converter={StaticResource imageConverter}}"/>
```



