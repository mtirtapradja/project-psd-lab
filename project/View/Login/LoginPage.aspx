<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master"
AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs"
Inherits="project.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" href="style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="outer-container">
    <div class="inner-container">
      <div class="modal">
        <h4>Login Page</h4>
        <div class="email-input">
          <asp:Label CssClass="email-input-label" runat="server"
            >Email :
          </asp:Label>
          <asp:TextBox runat="server"></asp:TextBox>
        </div>
        <div class="password-input">
          <asp:Label CssClass="password-input-label" runat="server"
            >Password :
          </asp:Label>
          <asp:TextBox
            TextMode="Password"
            runat="server"
            MaxLength="50"
          ></asp:TextBox>
        </div>

        <div class="login-btn">
          <asp:Button CssClass="btn" ID="login" runat="server" Text="Login" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>
