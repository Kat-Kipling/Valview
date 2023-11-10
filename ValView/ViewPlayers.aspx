<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="ViewPlayers.aspx.cs" Inherits="ValView.ViewPlayers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-wrapper">
        <asp:Repeater ID="reptPlayers" OnItemCommand="reptPlayers_ItemCommand" runat="server">
            <ItemTemplate>
                <div class="card tournament-card">
                    <div class="card-body">
                        <asp:HiddenField runat="server" ID="playerID" Value='<%#Eval("ID") %>'/>
                        <h1 class="card-title"><asp:Label runat="server" ID="lblName" Text='<%# Eval("Username") %>'></asp:Label></h1>
                        <p class="card-text"><asp:Label runat="server" ID="lblTeam" Text='<%# Eval("Team Name") %>'></asp:Label></p>
                        <asp:Button ID="btnViewPlayer" Text="View More Info" CssClass="btn btn-primary btn-block btn-lg" OnClick="btnViewPlayer_Click" runat="server" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
</div>
</asp:Content>
