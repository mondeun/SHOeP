<%@ Page Title="ProductDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ProductDetails.aspx.cs" Inherits="SHOeP.ProductPages.ProductDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/productdetails.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="FormView2" runat="server" ItemType="DAL.Models.Model" 
        SelectMethod="GetModel" RenderOuterTable="false">
        <ItemTemplate>
            <table>
                <tr>
                    <td runat="server" rowspan="3" width="80%">
                        <img src="/image/<%# Item.Picture%>" alt="<%#:Item.Brand %>" />
                    </td>
                    <td>
                        <h3><%#:Item.Brand %>, <%#:Item.ModelName %></h3>
                        <span><b>Material:</b>&nbsp;<%#:Item.Material %></span>
                        <br />
                        <b>Beskrivning:</b><br /><%#:Item.Description %>
                        <br />
                        <span><b>Pris:</b>&nbsp;<%#: String.Format("{0:c}", Item.Price) %></span>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Färg" CssClass=""></asp:Label>
                        <asp:RadioButtonList ID="RadioButtonColor" runat="server" AutoPostBack="True" CssClass="radiobuttoncolor"
                             OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" RepeatDirection="Horizontal"></asp:RadioButtonList>
                        <asp:Label ID="Label2" runat="server" Text="Storlek" CssClass=""></asp:Label>
                        <asp:RadioButtonList ID="RadioButtonSize" runat="server" AutoPostBack="True" CssClass="radiobuttonsize"
                             OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" RepeatDirection="Horizontal"></asp:RadioButtonList>
                        <br />
                        <br />
                        <asp:Button ID="AddToCart" runat="server" OnClick="AddToCartClick" Text="Add to cart" CssClass="addtocartbutton"></asp:Button>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>

    <asp:Label ID="OutOfStock" runat="server" Text="" CssClass="outofstocklabel"></asp:Label>
</asp:Content>

