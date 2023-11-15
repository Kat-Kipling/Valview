<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="ViewTeams.aspx.cs" Inherits="ValView.ViewTeams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div class="card-wrapper">
            <asp:Repeater ID="reptTeams" OnItemCommand="reptTeams_ItemCommand" runat="server">
                <ItemTemplate>
                    <div class="card tournament-card">
                        <asp:Image runat="server" ID="imgTeamLogo" ImageUrl='<%# Eval("Picture URL") %>' class="card-img-top"></asp:Image>
                        <div class="card-body">
                            <asp:HiddenField runat="server" ID="teamId" Value='<%#Eval("Team ID") %>'/>
                            <h1 class="card-title"><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Team Name") %>'></asp:Label></h1>
                            <p class="card-text"><asp:Label runat="server" ID="lblRegion" Text='<%# Eval("Region Name") %>'></asp:Label></p>
                            <p class="card-text"><asp:Label runat="server" ID="lblCountry" Text='<%# Eval("Country") %>'></asp:Label></p>
                            <asp:Button ID="btnViewTeam" Text="View Team" CssClass="btn btn-primary btn-block btn-lg" OnClick="btnViewTeam_Click" runat="server" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>
</div>
</asp:Content>
