<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3GimenezSantiago.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5 text-center">
        <h1 class="display-4">Bienvenido a Tienda Santi 😎</h1>
        <p class="lead slide-in">Explorá nuestros productos y descubrí lo que tenemos para vos.</p>
        <asp:HyperLink NavigateUrl="~/Public/Catalogo.aspx" CssClass="btn btn-primary btn-lg mt-3 btn-hover zoom-in"  runat="server">Ver Catálogo</asp:HyperLink>



    </div>
</asp:Content>
