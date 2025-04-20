<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Admin.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Recursos/Css/FormularioEstilo.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

                <!-- Botones -->
                <div class="acciones-formulario">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-aceptar" OnClick="btnAceptar_Click" runat="server" />
                    <a href="GestionArticulos.aspx" class="btn btn-cancelar">Cancelar</a>
                </div>
            </div>
        </div>

        <!-- Columna derecha (precio y descripción) -->
        <div class="form-columna derecha">
            <!-- Precio -->
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" TextMode="Number" step="0.01"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecio" ErrorMessage="El precio es requerido" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" ControlToValidate="txtPrecio" Type="Double" MinimumValue="0,01" MaximumValue="999999,99" CssClass="text-danger" ErrorMessage="El precio debe ser entre 0,01 y 999,999,99"></asp:RangeValidator>
            </div>

            <!-- Descripción -->
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtImagenUrl" class="form-label">Imagen del producto (URL)</label>
                <asp:TextBox ID="txtImagenUrl" CssClass="form-control" runat="server" AutoPostBack="true"
                    OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
            </div>
            <asp:Image ImageUrl="https://images.wondershare.com/repairit/aticle/2021/07/resolve-images-not-showing-problem-1.jpg" ID="imgProducto" runat="server" Visible="true" Width="400px" long="200px" />



        </div>
    </div>
</asp:Content>
