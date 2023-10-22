<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="ViewTournaments.aspx.cs" Inherits="ValView.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12 col-xs-12 mb-3">
        <asp:Repeater ID="reptTournaments" runat="server">
            <ItemTemplate>
                <div class="card mb-3">
                    <asp:Image runat="server" ID="imgTournamentLogo" ImageUrl='<%# Eval("Logo URL") %>' Height="200" class="card-img-top"></asp:Image>
                    <div class="card-body">
                        <h1 class="card-title"><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Tournament Name") %>'></asp:Label></h1>
                        <p class="card-text"><asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description") %>'></asp:Label></p>
                        <p class="card-text"><asp:Label runat="server" ID="lblStartDate" Text='<%# Eval("Start Date") %>'></asp:Label></p>
                        <p class="card-text"><asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("End Date") %>'></asp:Label></p>
                        <asp:Button ID="btnViewMatches" Text="View Matches" OnClick="btnViewMatches_Click" runat="server" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
