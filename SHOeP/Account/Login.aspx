<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SHOeP.Account.Login" %>
<asp:Content ID="LoginForm" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3 class="h3">Logga in</h3>
        <asp:TextBox ID="LoginUserTxtBox" CssClass="form-control" runat="server" placeholder="Användarnamn.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="LoginUserVal" ControlToValidate="LoginUserTxtBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br/>
        <asp:TextBox ID="LoginPassTxtBox" CssClass="form-control" runat="server" TextMode="Password" placeholder="Lösenord.."></asp:TextBox> 
        <asp:RequiredFieldValidator runat="server" ID="LoginPassVal" ControlToValidate="LoginPassTxtBox" ErrorMessage=" *"></asp:RequiredFieldValidator>  <br/>
        <asp:Button ID="LoginBtn" CssClass="btn btn-default" runat="server" Text="Logga in" Width="116px" OnClick="LoginUser" />  
        <a href="Forgot.aspx">Glömt lösenord</a> 
    </div>
</asp:Content>
