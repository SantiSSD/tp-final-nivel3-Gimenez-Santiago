<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Admin.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Recursos/Css/FormularioEstilo.css" rel="stylesheet" />
    <script>
        function formatearPrecio(input) {
            // Obtener posición actual del cursor
            let startPos = input.selectionStart;
            let endPos = input.selectionEnd;

            // Obtener valor y limpiar formato actual
            let value = input.value.replace(/\./g, '').replace(',', '.');

            // Permitir borrado completo
            if (value === '') {
                input.value = '';
                return;
            }

            // Validar que sea número
            if (isNaN(value)) {
                value = value.substring(0, value.length - 1);
                if (isNaN(value)) {
                    input.value = '';
                    return;
                }
            }

            // Convertir a número y formatear
            let number = parseFloat(value);
            if (isNaN(number)) {
                input.value = '';
                return;
            }

            // Formatear como número argentino
            let partes = number.toFixed(2).split('.');
            let entero = partes[0].replace(/\B(?=(\d{3})+(?!\d))/g, '.');
            let decimal = partes[1];

            // Actualizar valor
            input.value = entero + ',' + decimal;

            // Restaurar posición del cursor
            let newLength = input.value.length;
            let delta = newLength - input.value.length;
            input.setSelectionRange(startPos + delta, endPos + delta);
        }
    </script>

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
                <asp:TextBox ID="txtPrecio" CssClass="form-control precio-argentino" runat="server" placeholder="0,00" onkeyup="formatearPrecio(this)" onblur="formatearPrecio(this)"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPrecio"
                    ValidationExpression="^\d{1,3}(\.\d{3})*,\d{2}$"
                    ErrorMessage="Formato: 999.999,99"
                    CssClass="text-danger" Display="Dynamic">
                </asp:RegularExpressionValidator>
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
