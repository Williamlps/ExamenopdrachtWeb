<%@ Page Title="" Language="C#" MasterPageFile="~/Public.master" AutoEventWireup="true" CodeBehind="Huren.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="HurenContainer">
        <div class="container">
            <asp:Label ID="HurenFoutmelding" runat="server" CssClass="alert" Visible="false"></asp:Label>

            <h2>
                <asp:Label ID="TitelHuren" runat="server"></asp:Label>
            </h2>

            <div class="row">
                <div class="col-12 col-md-8">
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Begindatum huren:"></asp:Label>
                        <asp:TextBox ID="dpBeginDatum" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Einddatum huren:"></asp:Label>
                        <asp:TextBox ID="dpEindDatum" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Type materiaal:"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlTypeMateriaal" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Merk:"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlMerk" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Materiaal:"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlMateriaal" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Maten:"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlMaat" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Nog beschikbaar:"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtBeschikbaar" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Aantal huren:"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtAantal"></asp:TextBox>
                    </div>
                </div>

                <div class="col-12 col-md-4 d-flex align-items-center justify-content-center">
                    <asp:Image ID="imgMateriaal" runat="server" CssClass="img-fluid" />
                </div>
            </div>

            <div class="mb-3 d-flex justify-content-center gap-3">
                <asp:Button runat="server" ID="btnToevoegen" CssClass="btnHuren" Text="Toevoegen aan winkelmand" />
                <asp:Button runat="server" ID="btnWinkelmand" CssClass="btnHuren" Text="Toon winkelmand" />
                <asp:Button runat="server" ID="btnBevestigen" CssClass="btnHuren" Text="Huur bevestigen" />
            </div>
        </div>
    </div>
</asp:Content>
