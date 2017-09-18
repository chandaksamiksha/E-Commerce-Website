<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ProductCart.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Shopping Website</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <form id="StartPage" runat="server">
        <div>
            <div id="wrapper">
                <asp:Image ID="CartImage" runat="server" Height="226px" ImageUrl="/images/shoppingCart.jpg" Width="100%" />
            </div>
            <div id="navigation">
                <ul id="nav">
                    <li>
                        <asp:HyperLink ID="StartupLink" runat="server" NavigateUrl="StartPage.aspx">Home</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="InventoryLink" runat="server" NavigateUrl="Inventory.aspx">Customer</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="AdminLink" runat="server" NavigateUrl="Admin.aspx">Administration</asp:HyperLink></li>
                </ul>
            </div>
            <h1>Product List</h1>
            <br />
            <br />
            <asp:GridView ID="ProductGrid" runat="server" OnRowCommand="ExtractData" CellPadding="4" ForeColor="#333333" BackColor="White" BorderColor="Black" Width="1280px" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="P_ID" HeaderText="Product Id" />
                    <asp:BoundField DataField="P_Name" HeaderText="Name" />
                    <asp:BoundField DataField="P_Description" HeaderText="Description" />
                    <asp:BoundField DataField="P_Price" HeaderText="Price" />
                    <asp:BoundField DataField="P_Quantity" HeaderText="Quantity" />

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button ID="Edit_Button" runat="server" Text="Edit" CommandName="EditProduct" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="Delete_Button" runat="server" Text="Delete" CommandName="DeleteProduct" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="AddProduct_Button" runat="server" Text="Add A  New Product" Width="195px" OnClick="Add_Click" />

            <asp:Label ID="Delete_Label" runat="server" ForeColor="Red"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
