<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="OrderShowPage.aspx.cs" Inherits="project.Views.Shows.OrderShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <%-- Untuk SHOW NAME --%>
    <div>
        <asp:Label ID="lblShowName" Text="Show Name: " runat="server" />
        <asp:Label ID="lblShowNameValue" Text="" runat="server" />
    </div>
    
    <%-- Untuk SHOW PRICE --%>
    <div>
        <asp:Label ID="lblPrice" Text="Price: " runat="server" />
        <asp:Label ID="lblPriceValue" Text="" runat="server" />
    </div>

    <%-- Untuk SELLER NAME --%>
    <div>

        <asp:Label ID="lblSellerName" Text="Seller Name: " runat="server" />
        <asp:Label ID="lblSellerNameValue" Text="" runat="server" />
    </div>

    <%-- Untuk DESCRIPTION --%>
    <div>
        <asp:Label ID="lblDescription" Text="Description: " runat="server" />
        <asp:Label ID="lblDescriptionValue" Text="" runat="server" />
    </div>

    <%-- Untuk AVERAGE RATING --%>
    <div>
        <asp:Label ID="lblRating" Text="Rating: " runat="server" />
        <asp:Label ID="lblRatingValue" Text="" runat="server" />
    </div>

    <%-- Untuk DATE PICKER --%>
    <div>
        <asp:Label Text="Date " runat="server" />
        <asp:TextBox ID="txtOrderDate" TextMode="Date" AutoPostBack="true" OnTextChanged="txtOrderDate_Load" runat="server" />
        <%--<asp:Button ID="btnRefreshOrder" Text="Refresh table" OnClick="btnRefreshOrder_Click" runat="server" />--%>
    </div>
    
    <%-- Untuk QUANTITY ORDER --%>
    <div>
        <asp:Label Text="Quantity " runat="server" />
        <asp:TextBox ID="txtQuantity" TextMode="Number" runat="server" />
    </div>

     <%-- Untik GridView ORDER --%>
    <div>
        <asp:ScriptManager ID="smUpdatePanel" runat="server" />
        <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvOrder" AutoGenerateColumns="False" runat="server" OnRowCommand="gvOrder_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                        <asp:BoundField HeaderText="Time" DataField="Time"/>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnOrderShow" Text="Order" CommandName="Order" CommandArgument="<%# Container.DataItemIndex %>"  runat="server" />
                                <asp:Label ID="lblUnavailable" Text="" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btnRefreshOrder" />--%>
                <asp:PostBackTrigger ControlID="txtOrderDate" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div>
        <asp:Label ID="lblError" Text="" runat="server" />
    </div>
</asp:Content>
