<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="ProductCart.Inventory" %>
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
           <h1> Product List</h1>
            <br />
            <br />
            <asp:GridView ID="ProductGrid" runat="server"  OnRowCommand="ExtractData" CellPadding="4" ForeColor="#333333" BackColor="White" BorderColor="Black"  Width="1280px" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="P_ID" HeaderText="Product Id"/>
                     <asp:BoundField DataField="P_Name" HeaderText="Name"/>
                     <asp:BoundField DataField="P_Description" HeaderText="Description"/>
                     <asp:BoundField DataField="P_Price" HeaderText="Price"/>
                     <asp:BoundField DataField="P_Quantity" HeaderText="Quantity"/>
                    <asp:TemplateField HeaderText="Add">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" Text="Add To Cart" CommandName="AddToCart" CommandArgument='<%# Container.DataItemIndex %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Checkout" runat="server" Text="Checkout" OnClick="Checkout_Click" />
            <br />

        </div>
    </form>
</body>
</html>