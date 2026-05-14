<%@ Page Title="" Language="C#" MasterPageFile="~/Public.master" AutoEventWireup="true" CodeBehind="Aanmelden.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="container mt-3">
        <h1 class="mb-3">Aanmelden</h1>

        <asp:Label ID="Foutmelding" runat="server" CssClass="alert alert-warning" Visible="false"></asp:Label>


        <div class="mb-3">
            <label CssClass="form-label" for="txtGebruiker">Gebruikersnaam:</label>
            <asp:TextBox ID="txtGebruiker" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label CssClass="form-label" for="txtWachtwoord">Wachtwoord:</label>
            <asp:TextBox ID="txtWachtwoord" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="btnAanmelden" runat="server" Text="Aanmelden" OnClick="btnAanmelden_Click" CssClass="btnAanmelden w-100 mb-3" />
    </div>
</asp:Content>
