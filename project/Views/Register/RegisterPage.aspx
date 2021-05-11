<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true"
CodeBehind="RegisterPage.aspx.cs" Inherits="project.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="outer-container">
        <div class="inner-containter">
            <div class="modal">
                <h2>REGISTER PAGE</h2>

                <!-- Untuk NAME -->
                <div>
                    <asp:Label ID="lblName" Text="Name" runat="server" />
                    <asp:TextBox ID="txtName" runat="server" />
                </div>

                <!-- Untuk USERNAME -->
                <div>
                    <asp:Label ID="lblUsername" Text="Username" runat="server" />
                    <asp:TextBox ID="txtUsername" runat="server" />
                </div>

                <!-- Untuk PASSWORD -->
                <div>
                    <asp:Label ID="lblPassword" Text="Password" runat="server" />
                    <asp:TextBox ID="txtPassword" placeholder="Password" TextMode="Password" runat="server" />
                </div>

                <!-- Untuk PASSWORD CONFIRMATION -->
                <div>
                    <asp:Label ID="lblConfirmPass" Text="Confirmation Password" runat="server" />
                    <asp:TextBox ID="txtConfirmPass" placeholder="ConfirmPassword" TextMode="Password" runat="server" />
                </div>

                <!-- Untuk milih ROLE -->
                <div>
                    <asp:DropDownList ID="ddlRole" runat="server">
                        <asp:ListItem Text="Buyer" />
                        <asp:ListItem Text="Seller" />
                    </asp:DropDownList>
                </div>

                <div>
                    <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
                    <br />
                    <asp:Button ID="btnRegister" OnClick="btnRegister_Click" Text="Register" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>