<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true"
    CodeBehind="LoginPage.aspx.cs" Inherits="project.View.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>LOGIN PAGE</h2>

    <div>
        <asp:Label runat="server">Username :
        </asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" />
    </div>

    <div>
        <asp:Label runat="server">Password :
        </asp:Label>
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="50" />
    </div>

    <div>
        <asp:CheckBox ID="cbRemember" Text="Remember me" runat="server" />
    </div>

    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
