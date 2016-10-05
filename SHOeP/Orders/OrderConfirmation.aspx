<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="SHOeP.Orders.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/confirmation.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Tack för din beställning!</h2>
    <h5>En email skickas på din angivna emailadress inklusiv  din order och faktura.</h5>
    <b />
    <b />
    <!-- Order confirmation -->
        <!-- OrderHeader -->
        <h3>Bekräftelse</h3>
        <b />
        <asp:Label ID="OrderHeader" runat="server" CssClass=""></asp:Label>
<p></p>
    <asp:Label runat="server" Text="Beställningsnummer: "></asp:Label>
    <asp:Label ID="OrderNumber" runat="server" EnableViewState="false"></asp:Label>
    
    <div class="jumbotron">
        <!-- Varukorg -->
        <br />
        <h4>Beställda varor</h4>
        <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="DAL.Models.CartItem" SelectMethod="GetShoppingCartItems"
            CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="ShoeId" HeaderText="ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Brand, Modeltyp" />
                <asp:BoundField DataField="Color" HeaderText="Färg" />
                <asp:BoundField DataField="Size" HeaderText="Storlek" />
                <asp:TemplateField HeaderText="Antal">
                    <ItemTemplate>
                        <asp:Label ID="PurchaseQuantity" Width="40" runat="server" Text="<%#:Item.Quantity%>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pris">
                    <ItemTemplate>
                        <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.UnitPrice)))%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <!-- Total -->
        <div class="divtotal">
            <p></p>
                <asp:Label ID="LabelTotalText" runat="server" Text="Pris: "></asp:Label>
                <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
                <p></p>
                <asp:Label ID="DeliveryChargeLabel" runat="server" CssClass="deliveryprice" Text="Frakt: "></asp:Label>
                <asp:Label ID="DeliveryCharge" runat="server" CssClass="deliveryprice" EnableViewState="false"></asp:Label>
            <p></p>
            <strong>
                <asp:Label ID="TotalLabel" runat="server" CssClass="totalprice" Text="Totalpris: "></asp:Label>
                <asp:Label ID="TotalPayment" runat="server" CssClass="totalprice" EnableViewState="false"></asp:Label>
                <asp:Label runat="server" CssClass="totalprice" Text=" kr "></asp:Label>
            </strong>
        </div>
        <br />
        <br />
        <!-- Leveransadress -->
        <div class="divtotal">
            <h4>Leveransadress:</h4>
            <asp:Label ID="Name" runat="server" CssClass="data"></asp:Label><br />
            <asp:Label ID="Adress" runat="server" CssClass="data"></asp:Label><br />
            <asp:Label ID="CityZip" runat="server" CssClass="data"></asp:Label><br />
        </div>
        <!-- Leveranssätt -->
        <div class="divtotal">
            <h4>Leveranssätt</h4>
            <asp:Label ID="DeliveryMode" runat="server" CssClass="data"></asp:Label><br />
        </div>
        <!-- Betalningsätt -->
        <div class="divtotal">
            <h4>Betalningssätt</h4>
            <asp:Label ID="Payment" runat="server" Text="Faktura" CssClass="data"></asp:Label><br />
        </div>
    </div>
    <b />
    <b />
    <asp:Button ID="Home" runat="server" OnClick="HomeClick" CssClass="confirmbutton" Text="Till ny beställning"></asp:Button>
</asp:Content>
