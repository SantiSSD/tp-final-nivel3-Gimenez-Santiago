<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Public.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catalogo!!</h1>
        <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtfiltro_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>
        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Codigo" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Categoria" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <%} %>
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
