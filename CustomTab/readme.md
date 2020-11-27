This project aims to play with 
- Custom tab control. Each item header has an additional close button, which is visible if the tab item is selected or the mouse is over it.
- A collection of screens managed by `Conductor.Collection.OneActive`.

## Custom Tab Control with templates

Main references [[1]](https://stackoverflow.com/a/28299651/14020277) and [[2]](https://stackoverflow.com/questions/14821067/wpf-tabitem-onmouseover-shall-trigger-the-visibility-of-a-button-inside-the-tabi) and [[3]](https://caliburnmicro.com/documentation/composition).

### Class inheritance
- ContentControl --> HeaderedContentControl --> TabItem
- ItemsControl --> Selector  --> TabControl

Thus, a `TabControl` contains multiple `TabItem`s. As an `ItemsControl`, `TabControl` has properties `ItemsSource`, `Items` (cannot be used together), and `ItemsControl.ItemTemplate`. The `ItemTemplate` works cooperatively with `ItemsSource`. 

On the other hand, as a `HeaderedContentControl`, there holds 
> HeaderedContentControl inherits the Content property from ContentControl and defines the Header property that is of type Object. Header provides a heading for the control. Like the Content property of a ContentControl, the Header can be any type.

and, accordingly, the two parts of a `HeaderedContentControl` can be specified with two data templates `HeaderTemplate` and `ContentTemplate`.

Overall, the `TabControl` with bound `ItemsSource` can provide identical templates for each `TabItem` generated from data. The correspondence relationship is 

- `ItemsControl.ItemTemplate` (inherited)  --> `HeaderTemplate`
- `TabControl.ContentTemplate` --> `ContentTemplate`
  > `ContentTemplate` Gets or sets the DataTemplate to apply to any TabItem that does not have a ContentTemplate or ContentTemplateSelector property defined.

### Summary

- If the `ItemsSource` of a `TabControl` is used, then apply the `ItemTemplate` and the `ContentTemplate` to visualize the `Header` and the `Content` of each `TabItem`.
- If we add the `TabItem` directly (i.e., into the `Items` property), then just treat each `TabItem` independently by customizing essentially a `HeaderContentControl`. In this case, each `TabItem` can be totally different, i.e., with various templates. See [this stackoverflow](https://stackoverflow.com/a/25265513/14020277)

#### Causion
If we add the `TabItem` directly (to `Items`) and also specify the data template (e.g., `ItemTemplate`) for the `TabControl`, what will happen? Easy, the `TabControl`'s templates will be ignored.
We see error message 
```
System.Windows.Data Error: 26 : ItemTemplate and ItemTemplateSelector are ignored for items already of the ItemsControl's container type TabItem
```
Therefore, the data templates of `TabControl` only works with `ItemsSource` (rather than direct `Items`).

>If you do not want to use an object that implements IEnumerable to populate the ItemsControl, you can add items by using the Items property. The items in an ItemsControl can have different types. For example, a ListBox can contain one item that is a string and another item that is an Image.

Finally, recall that a data template **Describes the visual structure of a data object.** Thus, when working with data template, we must have some backing data (usually a Property of a viewmodel, or, sometimes, a static resource).

## Projects
1. [StyledTabUI](./StyledTabUI). In this project, the `TabItem`s are added directly, and the main purpose is to play with data templates for a `TabItem`.
    - Definition of `DataTemplate`
    - `DataTemplate.DataType`
    - `DataTrigger` in `DataTemplate.Triggers` that determine property values according to data source values.
    - `ControlTemplate`
    - `Style`
2. 

