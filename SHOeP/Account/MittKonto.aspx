<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MittKonto.aspx.cs" Inherits="SHOeP.Account.MittKonto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style type="text/css">
        .auto-style6 {
            width: 257px;
        }

        .auto-style7 {
            width: 344px;
        }

        .auto-style8 {
            width: 259px;
        }

        .auto-style9 {
            width: 259px;
            height: 19px;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <!--Start Section Profil-->
            <section class="profil-us text-center">
                <div class="fields">
                    <div class="container">
                        <div class="row">
                            <i class="glyphicon glyphicon-edit fa-5x" aria-hidden="true"></i>
                            <!--ALI---ALI-->
                            <h1>Profil</h1>
                            <p class="lead">Din information</p>
                            <!--Start Contact Form-->
                            <div role="form">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-3">

                                    <table class="nav-justified">
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Medium" Text="förnamn"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblFN" runat="server"></asp:Label>
                                            </td>
                                            <td rowspan="8">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName0" runat="server" Font-Bold="True" Font-Size="Medium" Text="EfterName"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblEfterN" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName2" runat="server" Font-Bold="True" Font-Size="Medium" Text="E-post"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblPost" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName3" runat="server" Font-Bold="True" Font-Size="Medium" Text="telefonnummer"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName1" runat="server" Font-Bold="True" Font-Size="Medium" Text="Adress"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblAdress" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName4" runat="server" Font-Bold="True" Font-Size="Medium" Text="Post-kode"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName5" runat="server" Font-Bold="True" Font-Size="Medium" Text="Stad"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">
                                                <asp:Label ID="lblName6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Lösenord"></asp:Label>
                                            </td>
                                            <td class="auto-style8">
                                                <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">
                                                <asp:Button ID="btnAndra" class="btn btn-danger btn-lg" runat="server" Text="Förändring profil" CommandName="NextView" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!--End Contact Form-->
                    </div>
                </div>

            </section>
            <!--End Section Profil-->
        </asp:View>
        <asp:View ID="View2" runat="server">
            <!--Start Section Contact-->
            <section class="profil-us text-center">
                <div class="fields">
                    <div class="container">
                        <div class="row">
                            <i class="fa fa-headphones fa-5x" aria-hidden="true"></i>
                            <!--ALI---ALI-->
                            <h1>min Konto</h1>
                            <p class="lead"></p>
                            <!--Start Contact Form-->
                            <div role="form">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFirstname" class="form-control input-lg" runat="server" placeholder="Forname"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtLastname" class="form-control input-lg" runat="server" placeholder="Lastname"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMail" class="form-control input-lg" runat="server" placeholder="E-post"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMobiltelefon" class="form-control input-lg" runat="server" placeholder="Mobiltelefon"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtAddress" class="form-control input-lg" runat="server" placeholder="Adress"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtZip" class="form-control input-lg" runat="server" placeholder="Post-Kode"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCity" class="form-control input-lg" runat="server" placeholder="Stade"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" class="form-control input-lg" runat="server" placeholder="Password"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnShicka" class="btn btn-danger btn-lg" runat="server" Text="Skicka" OnClick="btnShicka_Click" />

                                </div>
                                <div class="col-md-3">
                                </div>

                            </div>
                            <!--End Contact Form-->
                        </div>
                    </div>
                </div>
            </section>
            <!--End Section Contact-->
        </asp:View>
    </asp:MultiView>

</asp:Content>
