<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="PlayerInformation.aspx.cs" Inherits="ValView.PlayerInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 col-sm-12 mx-auto my-4">
            <div class="login-card">
                <div class="card">
                    <asp:Image ID="imgPlayerPicture" CssClass="card-img-top rounded-circle profile-picture" AlternateText="Player Profile Picture" ImageUrl="~/images/players/Default_Profile.png" runat="server"/>
                    <h1 class="card-title">Player Information</h1>
                    <div class="card-body login-card-body">
                        <div class="row">
                            <div class="col">
                                <div class="col">
                                    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
                                </div>

                                <div class="col">
                                    <asp:Label ID="lblTeam" runat="server" Text="Team: "></asp:Label>
                                </div>
                                
                                <div class="col">
                                <asp:Label ID="lblCountry" runat="server" Text="Country: "></asp:Label>
                                </div>

                                <div class="col">
                                <asp:Label ID="lblRank" runat="server" Text="Rank: "></asp:Label>
                                </div>

                                <div class="col">
                                    <asp:Label ID="lblDivision" runat="server" Text="Division: "></asp:Label>
                                </div>

                                <div class="col">
                                    <asp:Label ID="lblMainRole" runat="server" Text="Main Role: "></asp:Label>
                                </div>
                                
                                <div class="col">
                                    <asp:Label ID="lblSecRole" runat="server" Text="Secondary Role: "></asp:Label>
                                </div>

                                <div class="col">
                                    <asp:Label ID="lblMainAgent" runat="server" Text="Main Agent: "></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
