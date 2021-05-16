<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="project.View.HomePage.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>HOME PAGE</h2>
    <div>
        <asp:GridView ID="gvShows" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id"  />
                <asp:BoundField HeaderText="SellerId" DataField="SellerId" SortExpression="SellerId" />
                <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name" />
                <asp:BoundField HeaderText="Price" DataField="Price" SortExpression="Price" />
                <asp:BoundField HeaderText="Description" DataField="Description" SortExpression="Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnShowDetail" Text="Show Detail" OnCommand="btnShowDetail_Command" CommandName="Redirect" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Shows]"></asp:SqlDataSource>
    </div>
</asp:Content>
