<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E804)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CloneHelper.cs](./CS/SimpleObject/CloneHelper.cs) (VB: [CloneHelper.vb](./VB/SimpleObject/CloneHelper.vb))
* [Form1.cs](./CS/SimpleObject/Form1.cs) (VB: [Form1.vb](./VB/SimpleObject/Form1.vb))
* [ObjectClass.cs](./CS/SimpleObject/ObjectClass.cs) (VB: [ObjectClass.vb](./VB/SimpleObject/ObjectClass.vb))
<!-- default file list end -->
# How to clone a persistent object


<p><strong>Scenario</strong></p>
<p>In this example, we create a <em>CloneHelper</em> class that will be used to clone the provided persistent object. </p>
<p><strong>Steps to implement</strong></p>
<p><strong>1. </strong>Implement the <em>CloneHelper</em> class as shown in the <em>CloneHelper.xx </em>file. This class uses <a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoMetadataXPClassInfotopic">persistent object metadata</a> to create a copy of the provided persistent object. <br>The Clone method has several overloads that allow you to determine whether object synchronization is required or not. If the synchronize parameter is set to true, reference properties are cloned only if the referenced object does not exist in the target Session. Otherwise, the existing object will be reused.<br><br><strong>2. </strong>Create a Form that will use the ListBox control to display the result of creating and cloning persistent objects. See the code of the Form class in the <em>Form1.xx</em> file.</p>
<p><br>As a result, the following output will be shown:</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-clone-a-persistent-object-e804/13.1.4+/media/8958d5c9-1898-11e4-80b8-00155d624807.png"><br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/A2594">How to get a list of a persistent object's properties</a><br><a href="https://www.devexpress.com/Support/Center/p/K18182">Should I use XPO to transfer data between databases?</a></p>

<br/>


