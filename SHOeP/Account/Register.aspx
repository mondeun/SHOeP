<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SHOeP.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Skapa ditt nya SHOeP konto här</h1>
    <h2>Vänlighen fyll i följande information</h2>
    <div id="informationfyllnad">

        

        <asp:TextBox ID="forenameBox" runat="server" placeholder="Förnamn.."></asp:TextBox>
        <br />
        <asp:TextBox ID="lastnameBox" runat="server" placeholder="Efternnamn.."></asp:TextBox>
        <br />
        <asp:TextBox ID="emailBox" runat="server" placeholder="Email.."></asp:TextBox>
        <br />
        <asp:TextBox ID="passwordBox" runat="server" placeholder="Lösenord.."></asp:TextBox>
        <br />
        <asp:TextBox ID="repeatpassBox" runat="server" placeholder="Upprepa lösenord..">           
        </asp:TextBox>
       
        <br />
        <asp:Button ID="CreateButton" runat="server" Text="Skapa" />

    </div>
</asp:Content>

