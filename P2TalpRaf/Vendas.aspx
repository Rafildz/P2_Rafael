﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendas.aspx.cs" Inherits="P2TalpRaf.Vendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label ID="Label" runat="server"></asp:Label>
    <br />
    <asp:TextBox ID="TextTipo" runat="server" placeholder="Digite o Tipo"></asp:TextBox>
    Tipo[Insert/Altualizar]<br />
    <asp:TextBox ID="TextDescricao" runat="server" placeholder="Digite a Descricao"></asp:TextBox>
    Descricao[Insert/Altualizar]<br />
    <asp:Button ID="ButtonInsert" runat="server" Text="Insert" OnClick="ButtonInsert_Click" />
    <asp:Button ID="ButtonAtualizar" runat="server" Text="Atualizar" OnClick="ButtonAtualizar_Click" />
    <br />

    <asp:TextBox ID="TextID" runat="server" placeholder="Digite o Id"></asp:TextBox>
    Id[Excluir/Altualizar]<br />
    <asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" OnClick="ButtonExcluir_Click" />
    <br /><br />
    <asp:GridView runat="server" ID="grdCustosDespesas" AutoGenerateColumns="false" Width="100%" CellPadding="5" CellSpacing ="8" GridLines="Vertical"
        AllowPaging="true">

        <AlternatingRowStyle BackColor="#f1f1f1" />
        <HeaderStyle BackColor="#d1d1d1" />

        <Columns>
            <asp:BoundField DataField="IdVendas" HeaderText="Id"/>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo"/>
            <asp:BoundField DataField="Descricao" HeaderText="Descricao"/>
        </Columns>
    </asp:GridView>

    <br />

    <br />
    </asp:Content>
