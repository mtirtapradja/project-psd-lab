<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true"
  CodeBehind="LoginPage.aspx.cs" Inherits="project.View.LoginPage" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="style.css" />--%>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="outer-container">
      <div class="inner-container">
        <div class="modal">
          <h2>LOGIN PAGE</h2>
          <asp:Label ID="lblError" Text="" runat="server" />
          <div class="email-input">
            <asp:Label CssClass="email-input-label" runat="server">Username :
            </asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
          </div>

          <div class="password-input">
            <asp:Label CssClass="password-input-label" runat="server">Password :
            </asp:Label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="50"></asp:TextBox>
          </div>

          <div>
            <asp:CheckBox ID="cbRemember" Text="Remember me" runat="server" />
          </div>

          <div class="login-btn">
            <asp:Button CssClass="btn" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
          </div>
        </div>
      </div>
    </div>
  </asp:Content>