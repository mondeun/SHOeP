<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SHOeP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Start Section Contact-->
    <section class="contact-us text-center">
        <div class="fields">
            <div class="container">
                <div class="row">
                    <i class="fa fa-headphones fa-5x" aria-hidden="true"></i>
                    <!--ALI---ALI-->
                   <h1>Berätta vad du tycker om oss</h1>
                    <p class="lead">Kontakta oss gärna</p>
                    <!--Start Contact Form-->
                    <div role="form">
                        <div class="col-md-6">
                            <div class="form-group">
                                <%-- <input type="text" class="form-control input-lg" placeholder="Firstname" required />--%>
                                <asp:TextBox ID="txtFirstname" class="form-control input-lg" runat="server" placeholder="Förnamn.."></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <%-- <input type="text" class="form-control input-lg" placeholder="Lastname" required/>--%>
                                <asp:TextBox ID="txtLastname" class="form-control input-lg" runat="server" placeholder="Efternamn.."></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <%--<input type="text" class="form-control input-lg" placeholder="Email" required/>--%>
                                <asp:TextBox ID="txtMail" class="form-control input-lg" runat="server" placeholder="Email.."></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <%--<input type="text" class="form-control input-lg" placeholder="Mobiltelefon" required/>--%>
                                <asp:TextBox ID="txtMobiltelefon" class="form-control input-lg" runat="server" placeholder="Telefonnummer.."></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <textarea id="txtDittmeddelande" class="form-control input-lg" runat="server" placeholder="Ditt meddelande"></textarea>
                            </div>
                            <button type="submit" class="btn btn-danger btn-lg  ">Kontakta</button>
                        </div>

                    </div>
                    <!--End Contact Form-->
                </div>
            </div>
        </div>
    </section>
    <!--End Section Contact-->
    <!--Start Section Testimonials-->
    <section class="Testimonials text-center">
        <!--Start Container-->
        <div class="container">
            <h1>Vad våra kunder säger</h1>
            <!--Start Testimonials Carousel-->
            <div id="carousel_testimonials" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="item active">
                        <p class="lead">Vad våra kunder säger.</p>
                        <span>SHOeP</span>
                    </div>
                    <div class="item">
                        <p class="lead">Vad våra kunder säger.</p>
                        <span>SHOeP</span>
                    </div>
                    <div class="item">
                        <p class="lead">Vad våra kunder säger.</p>
                        <span>SHOeP</span>
                    </div>
                    <div class="item">
                        <p class="lead">Tell Us What You Fell.</p>
                        <span>SHOeP</span>
                    </div>
                </div>
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel_testimonials" data-slide-to="0" class="active">
                        <img src="../images_avatar/large_3206.png" alt="ben" />
                    </li>
                    <li data-target="#carousel_testimonials" data-slide-to="1">
                        <img src="../images_avatar/Opi51.png" alt="toto" />
                    </li>
                    <li data-target="#carousel_testimonials" data-slide-to="2">
                        <img src="../images_avatar/large_3194.png" alt="bobo" />
                    </li>
                    <li data-target="#carousel_testimonials" data-slide-to="3">
                        <img src="../images_avatar/large_3171.png" alt="soso" />
                    </li>
                </ol>
            </div>
            <!--End Testimonials Carousel-->
        </div>
        <!--End Container-->
    </section>
    <!--End Section Testimonials-->
</asp:Content>
