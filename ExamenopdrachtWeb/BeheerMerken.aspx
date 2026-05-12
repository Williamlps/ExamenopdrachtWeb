<%@ Page Title="" Language="C#" MasterPageFile="~/Private.master" AutoEventWireup="true" CodeBehind="BeheerMerken.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <h1>Beheer Merken</h1>

        <div>
            <label for="ddlMerken">Selecteer een merk:</label>
            <asp:DropDownList ID="ddlMerken" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
</asp:Content>
