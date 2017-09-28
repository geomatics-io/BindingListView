# BindingListView

## Information

This is a fork of Andrew Daveys [BindingListView](http://blw.sourceforge.net). It was upgraded to .NET 4.x and changes and fixes have been applied. 

The library is available from the public geomatics.io [myget](http://www.myget.org) feed:

https://www.myget.org/feed/geomatics/package/nuget/Equin.ApplicationFramework.BindingListView

## Introduction

The BindingListView .NET library provides a type-safe, sortable, filterable, data-bindable view of one or more lists of objects. It is the business objects equivalent of using a DataView on a DataTable in ADO.NET. If you have a list of objects to display on a Windows Forms UI (e.g. in a DataGridView) and want to allow your user to sort and filter, then this is the library to use!

For a demo of what the library can do, [watch](http://blw.sourceforge.net/demo.html) the screen cast.

For those who like to dive straight into the code, the source is available from the SubVersion repository or ZIPed as a release. The source contains a few example projects demonstrating what the library can do.
If you just want to use the library download the compiled DLL.
Check out the [SourceForge project page](http://www.sf.net/projects/blw) for forums, help, etc.

The library makes use of generics and so only works with the .NET 2.0 runtime. It should work with any .NET language: C#, VB.NET, etc.

## Quick-start Guide

Add a reference to the `Equin.ApplicationFramework.BindingListView.dll` assembly. (You can download the binary or compile from source.) The classes you'll want exist in the `Equin.ApplicationFramework` namespace.

Here is a very simple example of creating a view of a list of objects (in C#):

```C#
List<Customer> customers = GetCustomers();
BindingListView<Customer> view = new BindingListView<Customer>(customers);
dataGridView1.DataSource = view;
```
The bolded line creates a new view and passes the customers list as the "source" list. The view is then data bound to a DataGridView control. In the grid you can now sort by clicking on the headers. This was not possible if we had bound directly to the list object instead.

You can programatically sort the view using the ApplySort method. There are a number of overloads, the simplist of which takes a string in the form of an SQL "order by" clause. For example, `view.ApplySort("Balance DESC, Surname")` would first sort by the Balance property (putting the highest first) and then sort by Surname (is normal ascending order). You can specify zero or more properties to sort by. With each property you can enter "DESC" to sort in descending order.

The restrict the items displayed by the view you can set a filter. A simple filter is a function that takes an object and returns true or false depending on if the object should appear in the view. More advanced filters can be created by creating a class that implements the IItemFilter<T> interface.
This example shows creating a filter using an anonymous method in C#.
```C#
view.ApplyFilter(delegate(Customer customer) { return customer.Balance > 1000; });
```
In VB.NET you will have to explicitly create the function.
```C#
view.ApplyFilter(AddressOf BalanceFilter)
...
Function BalanceFilter(ByVal customer as Customer) as Boolean
  Return customer.Balance > 1000
End Function
```
A filter will not actually remove items from the source list, they are just not visible when bound to a grid for example.

## An Important Detail

The BindingListView works by creating a wrapper object around each item in a source list. This is just like how a DataView contains DataRowViews, which wrap DataRow objects, in ADO.NET. The wrapper object in a BindingListView is of type `ObjectView<T>`. The only time you usually need to interact with an object view is when retrieving items from the view in code.
```C#
ObjectView<Customer> customerView = view[0]; // Get first item in view
Customer customer = customerView.Object;
```
The example above uses the Object property of the ObjectView to return the original object.
This important detail impacts the most often when you are using a BindingSource component on a Form, as outlined in this following example.
```C#
// Upon a customer being selected (in a grid or listbox for example)
// we want to do something with that object.
private void customersBindingSource_PositionChanged(object sender, EventArgs e)
{
  // This cast will fail at runtime.
  Customer customer = (Customer)customersBindingSource.Current
  // The correct code is this
  Customer customer = ((ObjectView<Customer>)customersBindingSource.Current).Object
}
```
BindingSource.Current is typed as just Object, so the invalid cast to Customer cannot be caught at compile time. This causes a runtime cast exception instead.

Copyright © [Andrew Davey](http://blogs.warwick.ac.uk/andrewdavey) 2006
