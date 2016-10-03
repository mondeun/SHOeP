﻿<%@ Page Title="ShoppingCart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ShoppingCart.aspx.cs" Inherits="SHOeP.Order.ShoppingCart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/productpages.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="DAL.Models.CartItem" SelectMethod="GetShoppingCartItems"
        CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ShoeId" HeaderText="ID" />
            <asp:BoundField DataField="ProductName" HeaderText="Märke, Modeltyp" />
            <asp:BoundField DataField="Color" HeaderText="Färg" />
            <asp:BoundField DataField="Size" HeaderText="Storlek" />
            <asp:TemplateField HeaderText="Antal">
                <ItemTemplate>
                    <asp:Label ID="PurchaseQuantity" Width="40" runat="server" Text="<%#:Item.Quantity%>"></asp:Label>
                    <asp:Button ID="QuantityPlus" runat="server" OnClick="QuantityPlusClick" Text="+"></asp:Button>
                    <asp:Button ID="QuantityMinus" runat="server" OnClick="QuantityMinusClick" Text="-"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pris">
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.UnitPrice)))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ta bort item">
                <ItemTemplate>
                    <asp:Button ID="RemoveButton" runat="server" OnClick="RemoveClick" Text="Ta bort"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Total pris: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
            <asp:Label runat="server" Text=" kr "></asp:Label>
        </strong>
    </div>

    <div>
        <asp:Button ID="Order" runat="server" OnClick="ToOrderClick" Text="Beställ"></asp:Button>
    </div>
    <br />
</asp:Content>
