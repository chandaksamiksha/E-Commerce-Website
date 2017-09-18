<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ProductCart.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Shopping Website</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <form id="InvoiceForm" runat="server">
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
        </div>
        <asp:Button ID="ContinueShopping_Button" runat="server" OnClick="ContinueShopping_Click" Text="Continue Shopping" Width="151px" />
    </form>
</body>
</html>
