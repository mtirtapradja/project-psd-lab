<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master"
AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs"
Inherits="project.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%--<link rel="stylesheet" href="style.css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

  <div class="outer-container">
    <div class="inner-containter">
      <div class="modal">
        <h4>Register Page</h4>
        <div>
          <asp:Label ID="lblName" Text="Name" runat="server" />
          <asp:TextBox ID="txtName" runat="server" />
          <asp:RequiredFieldValidator
            ControlToValidate="txtName"
            ID="reqName"
            runat="server"
            ErrorMessage="Name must be filled "
          ></asp:RequiredFieldValidator>
          <asp:CustomValidator 
              ControlToValidate="txtName" 
              ID="customValidatorName" 
              runat="server" 
              ErrorMessage="Length Between 1 and 30" 
              OnServerValidate="customValidatorName_ServerValidate"
           ></asp:CustomValidator>
        </div>

        <div>
          <asp:Label ID="lblUsername" Text="Username" runat="server" />
          <asp:TextBox ID="txtUsername" runat="server" />
          <asp:RequiredFieldValidator
            ControlToValidate="txtUsername"
            ID="reqUsername"
            runat="server"
            ErrorMessage="Username must be filled "
          ></asp:RequiredFieldValidator>
          <asp:CustomValidator 
              ControlToValidate="txtUsername" 
              ID="customValidatorUsername" 
              runat="server" 
              ErrorMessage="Length Between 6 and 20" 
              OnServerValidate="customValidatorUsername_ServerValidate"
           ></asp:CustomValidator>
        </div>

        <div>
          <asp:Label ID="lblPassword" Text="Password" runat="server" />
          <asp:TextBox
            ID="txtPassword"
            placeholder="Password"
            TextMode="Password"
            runat="server"
          />
          <asp:RequiredFieldValidator
            ControlToValidate="txtPassword"
            ID="reqPassword"
            runat="server"
            ErrorMessage="Password must be filled "
          ></asp:RequiredFieldValidator>
          <asp:CustomValidator 
              ControlToValidate="txtPassword" 
              ID="customValidatorPassword" 
              runat="server" 
              ErrorMessage="Length Atleast 6" 
              OnServerValidate="customValidatorPassword_ServerValidate"
           ></asp:CustomValidator>
        </div>

        <div>
          <asp:Label
            ID="lblConfirmPass"
            Text="Confirmation Password"
            runat="server"
          />
          <asp:TextBox
            ID="txtConfirmPass"
            placeholder="Confirm Password"
            TextMode="Password"
            runat="server"
          />
          <asp:RequiredFieldValidator
            ControlToValidate="txtConfirmPass"
            ID="ReqConfirmPass"
            runat="server"
            ErrorMessage="Confirm Password must be filled "
          ></asp:RequiredFieldValidator>
          <asp:CustomValidator 
              ControlToValidate="txtConfirmPass" 
              ID="customValidatorConfirmPass" 
              runat="server" 
              ErrorMessage="Must be same with Password" 
              OnServerValidate="customValidatorConfirmPass_ServerValidate"
           ></asp:CustomValidator>
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
      </div>
    </div>
  </div>
</asp:Content>
