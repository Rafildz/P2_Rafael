<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="P2TalpRaf.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Formulario</h1>

    <asp:Label ID="lbl" runat="server"></asp:Label>
    <br />

    <asp:TextBox runat="server" ID="textId" placeholder="Digite seu id " ></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="ValidaId" runat="server" ErrorMessage="Digite o id" ControlToValidate="textId" 
        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> <br />

    <asp:TextBox runat="server" ID="textSenha" placeholder="Digite sua Senha " TextMode="Password"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="ValidaSenha" runat="server" ErrorMessage="Digite a Senha" ControlToValidate="textSenha" 
        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> <br />

    <asp:Button Text="Enviar" ID="btnEnviar" runat="server" OnClick="btnEnviar_Click"/>

</asp:Content>
