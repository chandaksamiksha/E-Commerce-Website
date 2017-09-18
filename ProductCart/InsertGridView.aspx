<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertGridView.aspx.cs" Inherits="ProductCart.InsertGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Shopping Website</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <form id="InsertForm" runat="server">

        <div>
            <div id="wrapper">
                <asp:Image ID="CartImage" runat="server" Height="226px" ImageUrl="/images/shoppingCart.jpg" Width="100%" />
            </div>
            <div id="navigation">
                <ul id="nav">
                    <li>
                        <asp:HyperLink ID="StartPageLink" runat="server" NavigateUrl="StartPage.aspx">Home</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="InventoryLink" runat="server" NavigateUrl="Inventory.aspx">Customer</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="AdminLink" runat="server" NavigateUrl="Admin.aspx">Administration</asp:HyperLink></li>
                </ul>
            </div>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
   <table>
       <tr>
           <td>Product_Name</td>
           <td>
               <asp:TextBox ID="txtProductName" runat="server" />
           </td>
       </tr>
       <tr>
           <td>Description</td>
           <td>
               <asp:TextBox ID="txtDescription" runat="server" />
           </td>
       </tr>
       <tr>
           <td>Quantity</td>
           <td>
               <asp:TextBox ID="txtQuantity" runat="server" />
           </td>
       </tr>
       <tr>
           <td>Supplier_Id</td>
           <td>
               <asp:TextBox ID="txtSupplier" runat="server" />
           </td>
       </tr>
       <tr>
           <td>Price</td>
           <td>
               <asp:TextBox ID="txtPrice" runat="server" />
           </td>
       </tr>
       <tr>
           <td>
               <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
           </td>
           <td>
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
           </td>
       </tr>

   </table>
        </div>
    </form>
</body>
</html>
