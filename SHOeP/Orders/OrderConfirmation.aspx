<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="SHOeP.Orders.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/confirmation.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Tack för din beställning!</h2>
    <h4>En email skickas på din angivna emailadress inklusiv  din order och faktura.</h4>
    <b />
    <b />
     <asp:Button ID="Home" runat="server" OnClick="HomeClick" CssClass="confirmbutton" Text ="Till ny beställning"></asp:Button>
</asp:Content>
