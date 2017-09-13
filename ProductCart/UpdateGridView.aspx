<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateGridView.aspx.cs" Inherits="ProductCart.UpdateGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Shopping Website</title>
    <link rel="stylesheet" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
        
            <div> 
                <div id="wrapper">
            <asp:Image ID="Image1" runat="server" Height="226px" ImageUrl="/images/shoppingCart.jpg" Width="100%" />
        </div>
        <div id="navigation">
            <ul id="nav">
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="StartPage.aspx">Home</asp:HyperLink></li>
            <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Inventory.aspx">Customer</asp:HyperLink></li>
            <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Admin.aspx">Administration</asp:HyperLink></li>
            </ul>
        </div>
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
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />    
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
