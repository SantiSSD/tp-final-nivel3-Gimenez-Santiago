<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Account.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-4">
        <h1>Registro de Usuario</h1>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" placeholder="********" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
        </div>
        <div class="mb-3">
            <label class="form-label">Confirmar Contraseña</label>
            <asp:TextBox runat="server" placeholder="********" ID="txtConfirmarContraseña" CssClass="form-control" TextMode="Password" />
        </div>
        <asp:Button Text="Registrarse" runat="server" ID="btnRegistrar" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
