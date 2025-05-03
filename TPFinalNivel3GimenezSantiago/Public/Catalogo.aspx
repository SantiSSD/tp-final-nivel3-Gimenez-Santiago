<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Public.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="row justify-content-center mb-4">
        <div class="col-md-8">
            <div class="card shadow-sm">
                <div class="card-body">
                    <h5 class="card-title text-center mb-4">Filtrar Productos</h5>
                    <div class="row g-3">
                        <div class="col-md-8">
                            <div class="input-group">
                                <span class="input-group-text bg-primary text-white">
                                    <i class="bi bi-search"></i>
                                </span>
                                <asp:TextBox runat="server" ID="txtfiltro" CssClass="form-control" 
                                    placeholder="Buscar productos..." AutoPostBack="true" 
                                    OnTextChanged="txtfiltro_TextChanged" />
                            </div>
                        </div>
                        <div class="col-md-4 d-flex align-items-center">
                            <div class="form-check form-switch">
                                <asp:CheckBox runat="server" ID="chkAvanzado" AutoPostBack="true"
                                    OnCheckedChanged="chkAvanzado_CheckedChanged" />
                                <label class="form-check-label" for="<%= chkAvanzado.ClientID %>">
                                    Filtro Avanzado
                                </label>
                            </div>
                        </div>
                    </div>

                    <% if (chkAvanzado.Checked) { %>
                    <div class="mt-4 pt-3 border-top">
                        <div class="row g-3">
                            <div class="col-md-4">
                                <label class="form-label">Campo</label>
                                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCampo"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                    <asp:ListItem Text="Nombre" Value="Nombre" />
                                    <asp:ListItem Text="Marca" Value="Marca" />
                                    <asp:ListItem Text="Categoria" Value="Categoria" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Criterio</label>
                                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select">
                                    <asp:ListItem Text="Contiene" Value="Contiene" />
                                    <asp:ListItem Text="Comienza con" Value="Comienza" />
                                    <asp:ListItem Text="Termina con" Value="Termina" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Valor</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" 
                                        ID="btnBuscar" OnClick="btnBuscar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</div>
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
                                    onerror="this.onerror=null;this.src='https://images.wondershare.com/repairit/aticle/2021/07/resolve-images-not-showing-problem-1.jpg';" />
                            </div>
                            <div class="card-body">
                                <h5 class="card-title text-truncate"><%# Eval("Nombre") %></h5>
                                <p class="card-text text-muted mb-2 description-truncate"><%# Eval("Descripcion") %></p>

                                <div class="d-flex justify-content-between mb-3">
                                    <span class="badge bg-primary"><%# Eval("Marca.Descripcion") %></span>
                                    <span class="badge bg-secondary"><%# Eval("Categoria.Descripcion") %></span>
                                </div>

                                <div class="d-flex align-items-center justify-content-between">
                                 <h4 class="text-primary mb-0">$<%# string.Format(new System.Globalization.CultureInfo("es-AR"), "{0:N2}", Eval("Precio")) %></h4>
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
