﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SHOeP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>--%>

    <div class="row">
        <div class="col-md-4">
            <a runat="server" href="~/ProductPages/Women.aspx"><img class="img-thumbnail img-center img-rounded" src="image/dam.PNG" /></a>
        </div>
        <div class="col-md-4">
            <a runat="server" href="~/ProductPages/Men.aspx"><img class="img-thumbnail img-center img-rounded " src="image/men.PNG" /></a>
        </div>
        <div class="col-md-4">
            <a runat="server" href="~/ProductPages/Childrens.aspx"><img class="img-thumbnail img-center img-rounded " src="image/barn.PNG" /></a>
        </div>
    </div>

</asp:Content>
