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
        <asp:TextBox ID="phoneBox" runat="server" placeholder="Telefonnummer.."></asp:TextBox>
        <br />
        <asp:TextBox ID="adressBox" runat="server" placeholder="Adress..">           
        </asp:TextBox>
       
        <br />
        <asp:TextBox ID="cityBox" runat="server" placeholder="Stad.."></asp:TextBox>
        <br />
        <asp:TextBox ID="zipBox" runat="server" placeholder="Postnummer.."></asp:TextBox>
       
        <br />
        <asp:TextBox ID="passBox" runat="server" placeholder="Lösenord"></asp:TextBox><br />
        <asp:Button ID="CreateButton" runat="server" Text="Skapa" OnClick="CreateButton_Click" />

    </div>
</asp:Content>

