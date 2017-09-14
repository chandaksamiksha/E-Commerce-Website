<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ProductCart.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Online Shopping Website</title>
    <link rel="stylesheet" href="Style.css"/>
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
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Continue Shopping" Width="151px" />
    </form>
</body>
</html>
