<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Pages_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Style.css" />
    <style type="text/css">
        .auto-style1 {
            height: 678px;
            width: 1037px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">                
  <asp:Label Text="Your Cart" runat="server" Font-Size="44px"></asp:Label>  
        <br />
        <br />
    <asp:GridView ID="ProductGrid" runat="server" AlternatingRowStyle-BackColor="White"
  AutoGenerateColumns="false" BorderStyle="Outset" CellPadding="50" CaptionAlign="Left">
<columns>
<asp:TemplateField HeaderText="Product Number"></asp:TemplateField>
<asp:TemplateField HeaderText="Product Name"></asp:TemplateField>
<asp:TemplateField HeaderText="Product Description"></asp:TemplateField>
<asp:TemplateField HeaderText="Quantity"></asp:TemplateField>
<asp:TemplateField HeaderText="Price"></asp:TemplateField>
<asp:TemplateField HeaderText="Options">
<ItemTemplate>
<asp:Button Text="Modify" runat="server" BackColor="#B2B2B2" BorderStyle="Outset" BorderWidth="2px" Font-Bold="True" ForeColor="Black" Font-Size="20px" />
</ItemTemplate>
</asp:TemplateField>
</columns>                
</asp:GridView>
     <asp:button style="margin-top: 100px; margin-left: 450px; margin-bottom: 100px; margin-right: 450px;" text="Checkout" id="cartButton" runat="server" enabled="False" backcolor="#999999" bordercolor="Black" borderstyle="Double" borderwidth="4px" font-bold="True" font-size="24px" />
 </div>          
</asp:Content>




