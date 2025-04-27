<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Usuario</label>
            <asp:TextBox runat="server" ID="txtUsuario" placeholder="nombre de usuario" CssClass="form-control"/>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" placeholder="********" ID="txtContraseña" CssClass="form-control" TextMode="Password" />
        </div>
        <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click"  CssClass="btn btn-primary" />


    </div>


</asp:Content>
