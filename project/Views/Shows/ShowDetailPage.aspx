<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ShowDetailPage.aspx.cs" Inherits="project.Views.Shows.ShowDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Show Detail</h2>
    <div>
        <asp:Label ID="lblName" Text="Name:" runat="server" /> 
        <asp:Label ID="lblNameContent" Text="" runat="server" />
        <br />

        <asp:Label ID="lblPrice" Text="Price:" runat="server" /> 
        <asp:Label ID="lblPriceContent" Text="" runat="server" />
        <br />

        <asp:Label ID="lblSeller" Text="Seller Name:" runat="server" /> 
        <asp:Label ID="lblSellerContent" Text="" runat="server" /> 
        <br />

        <asp:Label ID="lblDescription" Text="Description:" runat="server" /> 
        <asp:Label ID="lblDescriptionContent" Text="" runat="server" /> 
        <br />

        <asp:Label ID="lblAverageRating" Text="Average Rating:" runat="server" /> 
        <asp:Label ID="lblAverageRatingContent" Text="" runat="server" /> 
        <br />

        <asp:GridView ID="gvReview" runat="server"></asp:GridView>
        <br />
    </div>

    <div>
        <asp:Button ID="btnOrder" Text="Order" OnClick="btnOrder_Click" runat="server" /> 
        <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server" />
        <asp:Button ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" runat="server" />
    </div>

</asp:Content>
