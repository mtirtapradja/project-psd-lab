<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="RedeemTokenPage.aspx.cs" Inherits="project.Views.RedeemToken.RedeemTokenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>REDEEM TOKEN</h2>
    <asp:Label Text="Token" runat="server" />
    <asp:TextBox ID="txtToken" runat="server" />
    <asp:Button ID="btnRedeemToken" Text="Redeem" OnClick="btnRedeemToken_Click" runat="server" />
    <br />
    <asp:Label ID="lblError" Text="" runat="server" />
</asp:Content>
