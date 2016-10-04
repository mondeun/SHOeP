<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SHOeP.ProductPages.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/product.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main">
        <div id="modelmenu">
            <asp:ListView ID="modelList" ItemType="DAL.Models.Model" runat="server" SelectMethod="GetModels" GroupItemCount="4" >
                <EmptyDataTemplate>
                    <table runat="server" align="center">
                        <tr>
                            <td>Ingen vara kunde hämtas.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <table runat="server" align="center">
                            <tr>
                                <td runat="server" align="center">
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.ModelId%>">
                                        <img class="shoeimg" src="/image/<%# Item.Picture%>" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td runat="server" align="center">
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.ModelId%>">
                                        <span>
                                            <%#:Item.Brand%>, <%#:Item.ModelName%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Pris: </b><%#:$"{Item.Price:c}" %>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
