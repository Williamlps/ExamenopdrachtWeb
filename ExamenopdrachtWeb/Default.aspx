<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <%--Met chatGPT gedaan--%>
    <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">

        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1"></button>
        </div>

        <div class="carousel-inner">

            <div class="carousel-item active" data-bs-interval="5000">
                <img class="d-block w-100" src="images/ski.jpg">
                <div class="carousel-caption">
                    <a href="Huren.aspx?sport=Alpine">Klik hier om je alpine skimateriaal te huren</a>
                </div>
            </div>

            <div class="carousel-item" data-bs-interval="5000">
                <img class="d-block w-100" src="images/xc.jpg">
                <div class="carousel-caption">
                    <a href="Huren.aspx?sport=Langlaufen">Klik hier om je langlaufmateriaal te huren</a>
                </div>
            </div>
        </div>

        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon"></span>
        </button>

        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon"></span>
        </button>

    </div>
</asp:Content>
