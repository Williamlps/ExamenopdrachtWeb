<%@ Page Title="" Language="C#" MasterPageFile="~/Public.master" AutoEventWireup="true" CodeBehind="Huren.aspx.cs" Inherits="ExamenopdrachtWeb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="HurenContainer">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <h2 id="HTitel">
                        <asp:Label ID="TitelHuren" runat="server"></asp:Label>
                    </h2>
                    <div class="mb-3">
                        <asp:Label ID="HurenFoutmelding" runat="server" CssClass="alert" Visible="false"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-12 col-md-8">
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Begindatum huren:"></asp:Label>
                                <asp:TextBox ID="dpBeginDatum" runat="server" TextMode="Date" AutoPostBack="true" CssClass="form-control" OnTextChanged="dpBeginDatum_TextChanged"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Einddatum huren:"></asp:Label>
                                <asp:TextBox ID="dpEindDatum" runat="server" TextMode="Date" AutoPostBack="true" CssClass="form-control" OnTextChanged="dpEindDatum_TextChanged"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Type materiaal:"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlTypeMateriaal" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlTypeMateriaal_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Merk:"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlMerk" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlMerk_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Materiaal:"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlMateriaal" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlMateriaal_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Maten:"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlMaat" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlMaat_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Nog beschikbaar:"></asp:Label>
                                <asp:TextBox runat="server" AutoPostBack="true" CssClass="form-control" ID="txtBeschikbaar" ReadOnly="true"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label runat="server" Text="Aantal huren:"></asp:Label>
                                <asp:TextBox runat="server" AutoPostBack="true" CssClass="form-control" ID="txtAantal"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-12 col-md-4 d-flex align-items-center justify-content-center">
                            <asp:Image ID="imgMateriaal" runat="server" CssClass="img-fluid" />
                        </div>
                    </div>

                    <div class="mb-3 d-flex justify-content-center gap-3">
                        <asp:Button runat="server" ID="btnToevoegen" CssClass="btnHuren" Text="Toevoegen aan winkelmand" OnClick="btnToevoegen_Click" />
                        <asp:Button runat="server" ID="btnWinkelmand" CssClass="btnHuren" Text="Toon winkelmand" OnClick="btnWinkelmand_Click" />
                        <asp:Button runat="server" ID="btnBevestigen" CssClass="btnHuren" Text="Huur bevestigen" />
                    </div>

                    <!-- Winkelmand Modal -->
                    <div class="modal fade" id="modalWinkelmand" tabindex="-1">
                        <div class="modal-dialog modal-xl">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title pb-3 fw-bold">Winkelmand</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                </div>
                                <div class="modal-body">
                                    <asp:Repeater ID="rptWinkelmand" runat="server">
                                        <ItemTemplate>
                                            <div class="row p-2 <%# Container.ItemIndex % 2 == 0 ? "bg-white" : "bg-secondary bg-opacity-25" %>">
                                                <div class="col-6"><%# Eval("MerkNaam") %> - <%# Eval("MateriaalModel") %> (<%# Eval("MaatNaam") %>)</div>
                                                <div class="col-2">Aantal: <%# Eval("Aantal") %></div>
                                                <div class="col-4">Periode: <%# Eval("BeginDatum", "{0:dd-MM-yyyy}") %> tot <%# Eval("EindDatum", "{0:dd-MM-yyyy}") %></div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSluitWinkelmand" runat="server" Text="Sluiten" CssClass="btn w-100 " style="background-color:#0042B8; color:white;" data-bs-dismiss="modal" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
