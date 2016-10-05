<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSummary.aspx.cs" Inherits="SHOeP.Orders.OrderSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/ordersummary.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Beställning</h2>
    <br />
    <h4>Beställda varor:</h4>
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
    <div class="jumbotron">
        <h4>Adress:</h4>
        <asp:Label ID="Name" runat="server"></asp:Label><br />
        <asp:Label ID="Adress" runat="server"></asp:Label><br />
        <asp:Label ID="CityZip" runat="server"></asp:Label><br />
    </div>
    <div class="jumbotron">
        <h4>Leveransadress om annat än adress:</h4>
        <asp:TextBox ID="levaddressBox" runat="server" CssClass="form-control" placeholder="Adress.."></asp:TextBox> <br />

        <asp:TextBox ID="levcityBox" runat="server" CssClass="form-control" placeholder="Stad.."></asp:TextBox> <br />
        
        <asp:TextBox ID="levzipBox" runat="server" CssClass="form-control" placeholder="Postnummer.."></asp:TextBox> <br />
    </div>
    <div class="jumbotron">
        <h4>Leverans</h4>
        <asp:RadioButtonList ID="DeliveryMode" runat="server" AutoPostBack="True" CssClass="radiobuttoncolor"
                             OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" RepeatDirection="Vertical"></asp:RadioButtonList>
    </div>
    <div class="jumbotron">
        <h4>Betalningssätt:</h4>
        <asp:Label ID="Label1" runat="server" Text="Faktura skickas på email."></asp:Label><br />
    </div>
    <br />
    <div>
        <asp:Button ID="CancelButton" runat="server" OnClick="CancelClick" CssClass="cancelbutton" Text="Tillbaka"></asp:Button>
        <asp:Button ID="Confirmation" runat="server" OnClick="ConfirmationClick" CssClass="confirmbutton" Text="Bekräfta din beställning"></asp:Button>
    </div>
    <br />
</asp:Content>
