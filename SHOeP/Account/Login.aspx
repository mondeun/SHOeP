<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SHOeP.Account.Login" %>
<asp:Content ID="LoginForm" ContentPlaceHolderID="MainContent" runat="server">
    <label>Username</label>
    <input id="LoginPass" type="text" /> <br/>
    <label>Password</label>
    <input id="LoginPass" type="password" /> <br/>
    <input id="LoginBtn" type="submit" value="Login" formmethod="post" />
</asp:Content>
