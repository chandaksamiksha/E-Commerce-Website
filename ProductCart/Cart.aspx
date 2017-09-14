<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ProductCart.Cart" %>

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
            <h1>Your Cart Contains</h1>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both" Width="950px" BorderStyle="Groove">
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
        <asp:Label ID="Label1" runat="server" Text="Total Amount"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="PayableAmt" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Place Order" Width="114px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Continue Shopping " Width="128px" />
    </form>
</body>
</html>