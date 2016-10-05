<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="SHOeP.Account.Forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3 class="h3" align="center">Glömt lösenord</h3>
        <asp:TextBox ID="ForgotEmailTxtBox" CssClass="form-control" runat="server" TextMode="Email" placeholder="Email.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="EmailVal" ControlToValidate="ForgotEmailTxtBox" ErrorMessage="*"></asp:RequiredFieldValidator> <br/>
        <asp:Button ID="SendBtn" CssClass="btn btn-default" runat="server" Text="Skicka" Width="116px" OnClick="SendNewPassword" />  
    </div>
</asp:Content>
