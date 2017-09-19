<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ProductCart.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Shopping Website</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <form id="CartForm" runat="server">
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
            <h1>Your Cart Contains</h1>
            <br />
            <br />
            <asp:Table ID="tableCart" runat="server" GridLines="Both" Width="950px" BorderStyle="Groove" Visible="true">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Product Description">
                    </asp:TableHeaderCell>
                    <asp:TableCell Text="Quantity">

                    </asp:TableCell>
                    <asp:TableCell Text="Price">

                    </asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <br />
        <br />
        <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPayableAmt" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnPlaceOrder" runat="server" OnClick="PlaceOrderClick" Text="Place Order" Width="114px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnContinueShopping" runat="server" OnClick="ContinueShoppingClick" Text="Continue Shopping " Width="128px" />
    </form>
</body>
</html>
