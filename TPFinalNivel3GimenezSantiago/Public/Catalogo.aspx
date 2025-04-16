<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Public.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catalogo!!</h1>

    <div class="container mt-4">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repArticulos" runat="server">
                <ItemTemplate>
                    <div class="col mb-4">
                        <div class="card h-100 product-card">
                            <div class="img-container">
                                <img src='<%# GetImageUrl(Eval("ImagenUrl")) %>'
                                    class="card-img-top product-img"
                                    alt='<%# Eval("Nombre") %>'
                                    onerror="this.onerror=null;this.src='/images/placeholder.jpg';" />
                            </div>
                            <div class="card-body">
                                <h5 class="card-title text-truncate"><%# Eval("Nombre") %></h5>
                                <p class="card-text text-muted mb-2 description-truncate"><%# Eval("Descripcion") %></p>

                                <div class="d-flex justify-content-between mb-3">
                                    <span class="badge bg-primary"><%# Eval("Marca.Descripcion") %></span>
                                    <span class="badge bg-secondary"><%# Eval("Categoria.Descripcion") %></span>
                                </div>

                                <div class="d-flex align-items-center justify-content-between">
                                    <h4 class="text-primary mb-0">$<%# Eval("Precio", "{0:N2}") %></h4>
                                    <asp:Button ID="btnDetalle" runat="server" Text="Ver detalle" CssClass="btn btn-sm btn-outline-primary" CommandArgument='<%# Eval("Id") %>' OnClick="btnDetalle_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>


</asp:Content>
