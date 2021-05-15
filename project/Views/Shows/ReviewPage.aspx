<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ReviewPage.aspx.cs" Inherits="project.Views.Shows.ReviewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%--untuk Nama Show--%>
    <div>
        <asp:Label ID="lblShowName" Text="" runat="server" />
    </div>

    <%--untuk Nama Seller dari Show--%>
    <div>
        <asp:Label ID="lblShowSellerName" Text="" runat="server" />
    </div>

    <%--untuk Deskripsi Show--%>
    <div>
        <asp:Label ID="lblShowDescription" Text="" runat="server" />
    </div>

    <%--untuk Nilai Rating dari Show--%>
    <div>
        <asp:Label ID="lblRating" Text="Rating" runat="server" />
        <asp:TextBox ID="txtRating" TextMode="Number" runat="server" />
    </div>

    <%--untuk Deskripsi Review Show--%>
    <div>
        <asp:Label ID="lblDescription" Text="Description" runat="server" />
        <asp:TextBox ID="txtDescription" runat="server" />
    </div>

    <%-- tombol untuk Rate, Update, Delete --%>
    <div>
        <asp:Button ID="btnRate" Text="Rate" OnClick="btnRate_Click" runat="server" />
        <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server" />
        <asp:Button ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" runat="server" />
    </div>
</asp:Content>
