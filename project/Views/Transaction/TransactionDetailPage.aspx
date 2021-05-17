<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="project.Views.Transaction.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:GridView runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="Show_Id" HeaderText="Show_Id" SortExpression="Show_Id" />
            <asp:BoundField DataField="Show_Name" HeaderText="Show_Name" SortExpression="Show_Name" />
            <asp:BoundField DataField="Average_Rating" HeaderText="Average_Rating" SortExpression="Average_Rating" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Token" HeaderText="Token" SortExpression="Token" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTransactionDetailById" TypeName="project.Repository.TransactionRepository">
        <SelectParameters>
            <asp:QueryStringParameter Name="trHeaderId" QueryStringField="TransactionId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
