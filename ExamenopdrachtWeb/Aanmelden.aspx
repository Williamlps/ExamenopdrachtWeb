<%@ Page Title="" Language="C#" MasterPageFile="~/Public.master" AutoEventWireup="true" CodeBehind="Aanmelden.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="AanmeldenContainer">
        <h1>Aanmelden</h1>

        <asp:Label ID="Foutmelding" runat="server"></asp:Label>

        <div class="AmContent">
            <label for="txtGebruiker">Gebruikersnaam:</label>
            <asp:TextBox ID="txtGebruiker" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="AmContent">
            <label for="txtWachtwoord">Wachtwoord:</label>
            <asp:TextBox ID="txtWachtwoord" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="btnAanmelden" runat="server" Text="Aanmelden" OnClick="btnAanmelden_Click" CssClass="btnAanmelden" />
    </div>
</asp:Content>
