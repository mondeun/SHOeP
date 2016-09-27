<%@ Page Title="Women" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Women.aspx.cs" Inherits="SHOeP.ProductPages.Women" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/productpages.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <!-- Dropdown meny --> 
    <div>
        <ul>
            <li class="dropdown">
                <a href="#" class="dropbtn">Skotyp</a>
                <div class="dropdown-content">
                    <a href="#">Sandaler<br></a>
                    <a href="#">Stövletter<br></a>
                    <a href="#">Balerinas<br></a>
                    <a href="#">Träningskor<br></a>
                </div>
            </li>
            <li class="dropdown">
                <a href="#" class="dropbtn">Storlek</a>
                <div class="dropdown-content">
                    <a href="#">36<br></a>
                    <a href="#">37<br></a>
                    <a href="#">38<br></a>
                    <a href="#">39<br></a>
                    <a href="#">40<br></a>
                    <a href="#">41<br></a>
                </div>
            </li>
            <li class="dropdown">
                <a href="#" class="dropbtn">Färg</a>
                <div class="dropdown-content">
                    <a href="#">Röd<br></a>
                    <a href="#">Grön<br></a>
                    <a href="#">Blå<br></a>
                </div>
            </li>
            <li class="dropdown">
                <a href="#" class="dropbtn">Pris</a>
                <div class="dropdown-content">
                    <a href="#">0-500<br></a>
                    <a href="#">500-1000<br></a>
                    <a href="#">1000+<br></a>
                </div>
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
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.Brand%>">
                                        <img src="/image/<%# Item.Picture%>"
                                            width="100" height="100" style="border: solid" /></a>                                  </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?modelID=<%#:Item.ModelName%>">
                                        <span>
                                            <%#:Item.Brand%>, <%#:Item.Brand%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.Price)%>
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
