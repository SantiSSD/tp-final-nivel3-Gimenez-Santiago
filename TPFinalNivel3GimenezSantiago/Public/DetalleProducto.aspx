<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Public.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card mb-3">
        <div class="card-body">
            <div class="row">
                <div class="col-12 col-sm-6">

                    <div class="mb-3">
                        <label class="form-label">Codigo</label>
                        <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"  ReadOnly="true"/>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"  ReadOnly="true"/>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Marca</label>
                        <asp:DropDownList runat="server" ID="ddlMarca"  CssClass="form-select" >
                            
                        </asp:DropDownList> 
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Categoria</label>
                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-12 col-sm-6">
                    <div class="mb-3">
                        <label class="form-label">Descripcion</label>
                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" ReadOnly="true"/>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Precio</label>
                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" ReadOnly="true" />
                    </div>

                    <div style="height: 200px; margin-right:auto; margin-left:auto">
                        <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" ID="imgArticulo" runat="server" Height="200px" />
                    </div>
                </div>
                
            </div>

        </div>
    </div>
    <div class="row mb-3">
        <div class="col-12 text-center">
            <a href="Catalogo.aspx" class="btn btn-secondary">Regresar</a>
        </div>

    </div>
</asp:Content>
