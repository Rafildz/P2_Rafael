<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="P2TalpRaf.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Contato</h2>
   <p>
        Envia E-mail</p>
    <p>
        Nome:</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        E-mail:</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>
        Assunto:</p>
    <p>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click"/>
    </p>
</asp:Content>
