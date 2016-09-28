<%@ Page Title="Women" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Women.aspx.cs" Inherits="SHOeP.ProductPages.Women" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/productpages.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <ul>
            <li class="dropdown">
                <asp:Label ID="Label1" runat="server" Text="Skotyp" CssClass="dropbtn"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                    <asp:ListItem>Alla</asp:ListItem>
                    <asp:ListItem>Sandaler</asp:ListItem>
                    <asp:ListItem>Stövletter</asp:ListItem>
                    <asp:ListItem>Boots</asp:ListItem>
                    <asp:ListItem>Sneakers</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li class="dropdown">
                <asp:Label ID="Label2" runat="server" Text="Storlek" CssClass="dropbtn"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                    <asp:ListItem>Alla</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li class="dropdown">
                <asp:Label ID="Label3" runat="server" Text="Färg" CssClass="dropbtn"></asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                    <asp:ListItem>Alla</asp:ListItem>
                    <asp:ListItem>Green</asp:ListItem>
                    <asp:ListItem>Black</asp:ListItem>
                    <asp:ListItem>Red</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li class="dropdown">
                <asp:Label ID="Label4" runat="server" Text="Pris" CssClass="dropbtn"></asp:Label>
                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                    <asp:ListItem>Alla</asp:ListItem>
                    <asp:ListItem>0-500</asp:ListItem>
                    <asp:ListItem>500-1000</asp:ListItem>
                    <asp:ListItem>1000-10000</asp:ListItem>
                </asp:DropDownList>
            </li>
        </ul>

        <!-- new Products -->

        <br />
        <br />
        <br />
        <div id="ModelMenu" style="text-align: center">
            <asp:ListView ID="modelList"
                ItemType="DAL.Models.Model"
                runat="server"
                SelectMethod="GetModels"
                GroupItemCount="4">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned.</td>
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
                    <td runat="server" align="center">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.ModelId%>">
                                        <img src="/image/<%# Item.Picture%>"
                                            width="100" height="100" style="border: solid" /></a>                                  </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.ModelId%>">
                                        <span>
                                            <%#:Item.Brand%>, <%#:Item.ModelName%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Pris: </b><%#:String.Format("{0:c}", Item.Price)%>
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

    <script type="text/javascript">
        function reloadPage(id) {
            document.location.href = location.href + '?id=' + id.value;
        }
    </script>
</asp:Content>
