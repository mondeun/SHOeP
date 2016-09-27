<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SHOeP.Account.Login" %>
<asp:Content ID="LoginForm" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LoginUserLbl" runat="server">Username</asp:Label>
    <asp:TextBox ID="LoginUserTxtBox" runat="server"></asp:TextBox> <br/>
    <asp:Label ID="LoginPassLbl" runat="server">Password</asp:Label>
    <asp:TextBox ID="LoginPassTxtBox" runat="server" TextMode="Password"></asp:TextBox> <br/>
    <asp:Button ID="LoginBtn" runat="server" Text="Login" Width="116px" OnClick="LoginUser" />   
</asp:Content>
