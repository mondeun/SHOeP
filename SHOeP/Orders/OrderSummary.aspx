<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSummary.aspx.cs" Inherits="SHOeP.Orders.OrderSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Beställningsöversikt</h2>
    <br />
    <h4>Beställdda varor:</h4>
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
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Total pris: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
            <asp:Label runat="server" Text=" kr "></asp:Label>
        </strong>
    </div>
    <br/>
    <div>
        <h4>Leveransadress:</h4>
        <asp:Label ID="Name" runat="server"></asp:Label><br />
        <asp:Label ID="Adress" runat="server" Text="Mellanvångsvägen 2C"></asp:Label><br />
        <asp:Label ID="CityZip" runat="server" Text="22358 Lund"></asp:Label><br />
    </div>
    <br />
    <div>
        <h4>Betalningssätt:</h4>
        <asp:Label ID="Label1" runat="server" Text="Faktura"></asp:Label><br />
    </div>
    <br />
    <div>
        <asp:Button ID="CancelButton" runat="server" OnClick="CancelClick" Text="Tillbaka"></asp:Button>
        <asp:Button ID="Confirmation" runat="server" OnClick="ConfirmationClick" Text="Bekräfta din beställning"></asp:Button>
    </div>
    <br />
</asp:Content>
