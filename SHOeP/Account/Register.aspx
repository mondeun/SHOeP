<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SHOeP.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3 class="h3">Skapa ditt nya SHOeP konto här</h3>
        <h4 class="h4">Vänlighen fyll i följande information</h4>
        
        <asp:TextBox ID="forenameBox" runat="server" CssClass="form-control" placeholder="Förnamn.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="forenameVal" ControlToValidate="forenameBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="lastnameBox" runat="server" CssClass="form-control" placeholder="Efternnamn.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="lastnameVal" ControlToValidate="lastnameBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="emailBox" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email.."></asp:TextBox> 
        <asp:RequiredFieldValidator runat="server" ID="emailVal" ControlToValidate="emailBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="phoneBox" runat="server" CssClass="form-control" placeholder="Telefonnummer.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="phoneVal" ControlToValidate="phoneBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="addressBox" runat="server" CssClass="form-control" placeholder="Adress.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="addressVal" ControlToValidate="addressBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="cityBox" runat="server" CssClass="form-control" placeholder="Stad.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="cityVal" ControlToValidate="cityBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="zipBox" runat="server" CssClass="form-control" placeholder="Postnummer.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="zipVal" ControlToValidate="zipBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="passBox" runat="server" CssClass="form-control" TextMode="Password" placeholder="Lösenord"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="passVal" ControlToValidate="passBox" ErrorMessage=" *"></asp:RequiredFieldValidator> <br />
        
        <asp:TextBox ID="confirmPassBox" runat="server" CssClass="form-control" TextMode="Password" placeholder="Bekräfta lösenord.."></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="confirmPassVal" ControlToValidate="confirmPassBox" ErrorMessage=" *"></asp:RequiredFieldValidator>
        
        <asp:Button ID="CreateButton" CssClass="btn btn-default" runat="server" Text="Skapa" OnClick="CreateButton_Click" />
    </div>
</asp:Content>

