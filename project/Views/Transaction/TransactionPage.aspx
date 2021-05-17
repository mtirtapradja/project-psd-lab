<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="project.Views.Transaction.TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:GridView runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="Transaction_Id" HeaderText="Transaction_Id" SortExpression="Transaction_Id" />
            <asp:BoundField DataField="Payment_Date" HeaderText="Payment_Date" SortExpression="Payment_Date" />
            <asp:BoundField DataField="Show_Name" HeaderText="Show_Name" SortExpression="Show_Name" />
            <asp:BoundField DataField="Show_Time" HeaderText="Show_Time" SortExpression="Show_Time" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Total_Price" HeaderText="Total_Price" SortExpression="Total_Price" />
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnTransactionDetail" Text="Detail" OnCommand="btnTransactionDetail_Command" CommandName="Redirect" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllTransaction" TypeName="project.Repository.TransactionRepository"></asp:ObjectDataSource>
</asp:Content>
