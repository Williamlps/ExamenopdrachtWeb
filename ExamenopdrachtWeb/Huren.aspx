<%@ Page Title="" Language="C#" MasterPageFile="~/Public.master" AutoEventWireup="true" CodeBehind="Huren.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="container HurenContainer">
        
        <h2><a></a>huren</h2>

        <asp:Label runat="server" Text="Begindatum huren:"></asp:Label>
        <input type="date" class="form-control" />

        <asp:Label runat="server" Text="Einddatum huren:"></asp:Label>
        <input type="date" class="form-control" />

        <asp:Label runat="server" Text="Type materiaal:"></asp:Label>
        <asp:DropDownList runat="server" Cssclass="form-control"></asp:DropDownList>

        <asp:Label runat="server" Text="Merk:"></asp:Label>
        <asp:DropDownList runat="server" Cssclass="form-control"></asp:DropDownList>

        <asp:Label runat="server" Text="Materiaal:"></asp:Label>
        <asp:DropDownList runat="server" Cssclass="form-control"></asp:DropDownList>

        <asp:Label runat="server" Text="Maten:"></asp:Label>
        <asp:DropDownList runat="server" Cssclass="form-control"></asp:DropDownList>

        <asp:Label runat="server" Text="Nog beschickbaar:"></asp:Label>
        <asp:TextBox runat="server" Cssclass="form-control"></asp:TextBox>

        <asp:Label runat="server" Text="Aantal huren:"></asp:Label>
        <asp:TextBox runat="server" Cssclass="form-control"></asp:TextBox>

        <div>
            <asp:Button runat="server" id="btnToevoegen" CssClass="btnHuren" Text="Toevoegen aan winkelwagen" />
            <asp:Button runat="server" id="btnWinkelmand" CssClass="btnHuren" Text="Toon winkelmand" />
            <asp:Button runat="server" id="btnBevestigen" CssClass="btnHuren" Text="Huur bevestigen" />
        </div>

    </div>
</asp:Content>
