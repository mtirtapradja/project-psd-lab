<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="project.Views.UpdateProfile.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%-- Untuk Current PROFILE DATA --%>
    <div>
        <asp:Label ID="lblCurrName" Text="" runat="server" />
        <asp:Label ID="lblCurrPassword" Text="" runat="server" />
    </div>

    <!-- Untuk NAME -->
                <div>
                    <asp:Label ID="lblName" Text="Name" runat="server" />
                    <asp:TextBox ID="txtName" runat="server" />
                </div>

    <!-- Untuk OLD PASSWORD -->
                <div>
                    <asp:Label ID="lblOldPassword" Text="Old Password" runat="server" />
                    <asp:TextBox ID="txtOldPassword" placeholder="Password" TextMode="Password" runat="server" />
                </div>

    <!-- Untuk NEW PASSWORD -->
                <div>
                    <asp:Label ID="lblNewPassword" Text="New Password" runat="server" />
                    <asp:TextBox ID="txtNewPassword" placeholder="Password" TextMode="Password" runat="server" />
                </div>

    <!-- Untuk PASSWORD CONFIRMATION -->
                <div>
                    <asp:Label ID="lblConfirmPass" Text="Confirmation Password" runat="server" />
                    <asp:TextBox ID="txtConfirmPass" placeholder="ConfirmPassword" TextMode="Password" runat="server" />
                </div>

    <%-- tombol untuk UPDATE --%>
                <div>
                    <asp:Label ID="lblError" Text="" runat="server" />
                    <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server" />
                </div>
</asp:Content>
