<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="RedeemTokenPage.aspx.cs" Inherits="project.Views.RedeemToken.RedeemTokenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>REDEEM TOKEN</h2>
    <asp:Label Text="Token" runat="server" />
    <asp:TextBox ID="txtToken" runat="server" />
    <asp:Button ID="btnRedeemToken" Text="Redeem" OnClick="btnRedeemToken_Click" runat="server" />
    <div>
        <asp:Label ID="lblShowName" Text="Show Name: " runat="server" /> <asp:Label ID="txtShowName" Text="" runat="server" /> <br />
        <asp:Label ID="lblSellerName" Text="Seller Name: " runat="server" /> <asp:Label ID="txtSellerName" Text ="" runat="server" /> <br />
        <asp:Label ID="lblDescription" Text="Description: " runat="server" /> <asp:Label ID="txtDescription" Text="" runat="server" /> <br />
        <asp:Label ID="lblRating" Text="Rating: " runat="server" /> <asp:TextBox ID="TxtRating" TextMode="Number" runat="server"></asp:TextBox> <br />
        <asp:Label ID="lblReviewDescription" Text="Review Description: " runat="server" /> <asp:TextBox ID="txtReviewDescription" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnRate" Text="Rate" OnClick="btnRate_Click" runat="server" />
        <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server" />
        <asp:Button ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" runat ="server" />
    </div>
</asp:Content>
