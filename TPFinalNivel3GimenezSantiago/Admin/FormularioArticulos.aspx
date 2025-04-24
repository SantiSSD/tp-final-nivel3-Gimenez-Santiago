<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Admin.FormularioArticulos" Culture="es-AR" UICulture="es-AR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Recursos/Css/FormularioEstilo.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />

    <div class="contenedor-formulario">
        <div class="formulario-articulo">
            <!-- ID -->
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>

            <!-- Código -->
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodigo" ErrorMessage="El código es requerido" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Nombre -->
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>


            <!-- Categoría -->
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Seleccione una categoría" CssClass="text-danger" InitialValue=""></asp:RequiredFieldValidator>
            </div>

            <!-- Marca -->
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMarca" ErrorMessage="Seleccione una marca" CssClass="text-danger" InitialValue=""></asp:RequiredFieldValidator>
                <div>
                </div>
                <!-- Botones -->
                <div class="acciones-formulario">
                    <div class="grupo-botones-principales">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-aceptar" OnClick="btnAceptar_Click" runat="server" />
                        <a href="GestionArticulos.aspx" class="btn btn-cancelar">Cancelar</a>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <% if (ConfirmarEliminacion)
                                {%>
                            <div class="confirmacion-eliminar">
                                <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmarEleminacion" runat="server" />
                                <asp:Button Text="Eliminar" ID="btnConfirmarEliminar" OnClick="btnConfirmarEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                            </div>
                            <% }%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!-- Columna derecha (precio y descripción) -->
        <div class="form-columna derecha">

            <!-- Precio -->
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server">
                </asp:TextBox>
            </div>

            <!-- Descripción -->
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Imagen del producto (URL)</label>
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ImageUrl="https://images.wondershare.com/repairit/aticle/2021/07/resolve-images-not-showing-problem-1.jpg" ID="imgProducto" runat="server" Visible="true" Width="400px" long="200px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
