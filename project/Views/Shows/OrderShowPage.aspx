<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="OrderShowPage.aspx.cs" Inherits="project.Views.Shows.OrderShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%-- Untuk SHOW NAME --%>
    <div>
        <asp:Label ID="lblShowName" Text="" runat="server" />
    </div>
    
    <%-- Untuk SHOW PRICE --%>
    <div>
        <asp:Label ID="lblPrice" Text="Price: " runat="server" />
        <asp:Label ID="lblPriceValue" Text="" runat="server" />
    </div>

    <%-- Untuk SELLER NAME --%>
    <div>
        <asp:Label ID="lblSellerName" Text="" runat="server" />
    </div>

    <%-- Untuk DESCRIPTION --%>
    <div>
        <asp:Label ID="lblDescription" Text="" runat="server" />
    </div>

    <%-- Untuk AVERAGE RATING --%>
    <div>
        <asp:Label ID="lblRating" Text="Rating: " runat="server" />
        <asp:Label ID="lblRatingValue" Text="" runat="server" />
    </div>

    <%-- Untuk QUANTITY ORDER --%>
    <div>
        <asp:Label Text="Quantity" runat="server" />
        <asp:TextBox ID="txtQuantity" runat="server" />
    </div>

    <%-- Untik GridView ORDER --%>
    <div>
        <asp:GridView ID="gvOrder" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Time"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnOrderShow" Text="Order" OnClick="btnOrderShow_Click" runat="server" />
                        <asp:Button ID="btnUnavailable" Text="Unavailable" OnClick="btnUnavailable_Click" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
