<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="project.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3>Register Page</h3>
        <div>
            <asp:Label ID="lblName" Text="Name" runat="server" />
            <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="txtName" ID="reqName" runat="server" ErrorMessage="Name must be filled "></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ControlToValidate="txtName" ID="regName" runat="server" ErrorMessage="Alphabet only"></asp:RegularExpressionValidator>
        </div>
        <div>
            <asp:Label ID="lblUsername" Text="Username" runat="server" />
            <asp:TextBox ID="txtUsername" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="txtUsername" ID="reqUsername" runat="server" ErrorMessage="Username must be filled"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lblPassword" Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" placeholder="Password" TextMode="Password" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="reqPassword" runat="server" ErrorMessage="Password must be filled"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lblConfirmPass" Text="Confirmation Password" runat="server" />
            <asp:TextBox ID="txtConfirmPass" placeholder="Confirm Password" TextMode="Password" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="txtConfirmPass" ID="ReqConfirmPass" runat="server" ErrorMessage="Confirm Password must be filled"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:DropDownList ID="ddlRole" runat="server">
                <asp:ListItem Text="Buyer" />
                <asp:ListItem Text="Seller" />
            </asp:DropDownList> 
        </div>
        <div>
            <asp:Button ID="btnRegist" Text="Register" runat="server" />
        </div>
</asp:Content>
