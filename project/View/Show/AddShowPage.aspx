<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="AddShowPage.aspx.cs" Inherits="project.View.Show.AddShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            <h2>Add Show</h2>
    <div>
        <asp:Label ID="lblName" Text="Name" runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>
    <div>
        <asp:Label ID="lblURL" Text="URL" runat="server" />
        <asp:TextBox ID="txtURL" runat="server" />
    </div>
    <div>
        <asp:Label ID="lblDesc" Text="Description" runat="server" />
        <asp:TextBox ID="txtDes" runat="server" />
    </div>
    <div>
        <asp:Label ID="lblPrice" Text="Price" runat="server" />
        <asp:TextBox ID="txtPrice" TextMode="Number" runat="server" />
        <asp:RequiredFieldValidator 
            ID="RFDPrice" 
            ControlToValidate="txtPrice" 
            runat="server" 
            ErrorMessage="Price Must be Filled">
        </asp:RequiredFieldValidator>
        <asp:CustomValidator 
            ID="CVPrice" 
            ControlToValidate="txtPrice" 
            runat="server" 
            ErrorMessage="Price Must be Number" 
            OnServerValidate="CVPrice_ServerValidate">
        </asp:CustomValidator>
    </div>
    <div>
        <asp:Button ID="btnAdd" Text="Add" runat="server" OnClick="btnAdd_Click"/>
    </div>
</asp:Content>
