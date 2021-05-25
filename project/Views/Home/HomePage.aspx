<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="project.View.HomePage.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>HOME PAGE</h2>
    <asp:Label Text="Welcome, " runat="server" />
    <asp:Label ID="txtUserName" Text="" Font-Size="25px" Font-Names="Segoe UI" runat="server" />
    <br />
    <div>
        <asp:GridView ID="gvShows" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" SortExpression="Id"  />
                <asp:BoundField HeaderText="Title" DataField="Title" SortExpression="Title"  />
                <asp:BoundField HeaderText="Price" DataField="Price" SortExpression="Price" />
                <asp:BoundField HeaderText="Seller Name" DataField="Seller Name" SortExpression="Seller Name" />
                <asp:BoundField HeaderText="Description" DataField="Description" SortExpression="Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnShowDetail" Text="Show Detail" OnCommand="btnShowDetail_Command" CommandName="Redirect" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT S.Id AS [Id], S.Name AS [Title], S.Price, U.Name AS [Seller Name], S.Description
FROM [Users] AS [U] JOIN [Shows] AS [S] ON S.SellerId= U.Id"></asp:SqlDataSource>
    </div>
</asp:Content>
