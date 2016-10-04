<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="SHOeP.ProductPages.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/product.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="main">
        <div class="filtermenu">
            <ul>
                <li class="dropdown">
                    <asp:Label ID="Label1" runat="server" Text="Skotyp" CssClass="dropbtn"></asp:Label>
                    <asp:ListBox ID="ListBoxType" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                        <asp:ListItem>Alla</asp:ListItem>
                        <asp:ListItem>Running</asp:ListItem>
                        <asp:ListItem>Sport</asp:ListItem>
                        <asp:ListItem>Boots</asp:ListItem>
                        <asp:ListItem>Sneakers</asp:ListItem>
                        <asp:ListItem>Sandaler</asp:ListItem>
                    </asp:ListBox>
                </li>
                <li class="dropdown">
                    <asp:Label ID="Label2" runat="server" Text="Storlek" CssClass="dropbtn"></asp:Label>
                    <asp:ListBox ID="ListBoxSize" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                        <asp:ListItem>Alla</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                    </asp:ListBox>
                </li>
                <li class="dropdown">
                    <asp:Label ID="Label3" runat="server" Text="Färg" CssClass="dropbtn"></asp:Label>
                    <asp:ListBox ID="ListBoxColor" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                        <asp:ListItem>Alla</asp:ListItem>
                        <asp:ListItem>Brun</asp:ListItem>
                        <asp:ListItem>Grön</asp:ListItem>
                        <asp:ListItem>Svart</asp:ListItem>
                        <asp:ListItem>Vit</asp:ListItem>
                        <asp:ListItem>Rosa</asp:ListItem>
                        <asp:ListItem>Gul</asp:ListItem>
                    </asp:ListBox>
                </li>
                <li class="dropdown">
                    <asp:Label ID="Label4" runat="server" Text="Pris" CssClass="dropbtn"></asp:Label>
                    <asp:ListBox ID="ListBoxPrice" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="Clicked" AppendDataBoundItems="true" CssClass="dropdown-content">
                        <asp:ListItem>Alla</asp:ListItem>
                        <asp:ListItem>0-500</asp:ListItem>
                        <asp:ListItem>500-1000</asp:ListItem>
                        <asp:ListItem>1000-10000</asp:ListItem>
                    </asp:ListBox>
                </li>
            </ul>
        </div>

        <br />
        <br />
        <br />
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
                    <td  runat="server" align="center">
                        <table>
                            <tr>
                                <td runat="server" align="center">
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.ModelId%>">
                                        <img class="shoeimg" src="/image/<%# Item.Picture%>" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
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
</asp:Content>
