<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="P2TalpRaf._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="jumbotron">
        <h1>Libra Lapis</h1>
        <p class="lead">Colorindo sua vida.</p>
        <p><a href="Login.aspx" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Estoque</h2>
            <p>
                Gerenciar seu estoque.
            </p>
            <p>
                <a class="btn btn-default" href="~/Estoque">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Vendas</h2>
            <p>
                Gerenciar suas vendas.
            </p>
            <p>
                <a class="btn btn-default" href="~/Vendas.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Custos e Despesas</h2>
            <p>
                Gerenciar seus custos e despesas.
            </p>
            <p>
                <a class="btn btn-default" href="~/CustosDespesas.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
