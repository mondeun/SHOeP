<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FailedOrder.aspx.cs" Inherits="SHOeP.Orders.FailedOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/confirmation.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Tyvärr gick beställningen inte igenom.</h2>
    <h4>Var snäll och försök igen.</h4>
    <b />
    <b />
    <asp:Button ID="Home" runat="server" OnClick="HomeClick" CssClass="confirmbutton" Text ="Till ny beställning"></asp:Button>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
