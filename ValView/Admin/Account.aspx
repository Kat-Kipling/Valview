﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ValView.Admin.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md ">
                <div class="profile-card mx-auto my-4">
                    <div class="card">
                        <asp:Image ID="imgUserProfilePic" CssClass="card-img-top rounded-circle profile-picture" AlternateText="User Profile Picture" ImageUrl="~/images/profile-pics/Default_Profile.png" runat="server"/>
                        <h1 class="card-title"><asp:Label runat="server" ID="lblUsername" Text="User" /></h1>
                        <div class="card-body">
                            <div class="col">
                                <h2>Name: </h2><asp:Label ID="lblName" runat="server" Text="Your Name"/>
                            </div>

                            <div class="col">
                                <h2>Pronouns: </h2><asp:Label ID="lblPronouns" runat="server" Text="They/Them"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md mx-auto my-4">

                <div class="col">
                    <asp:Button ID="btnPlayerManagement" runat="server" Text="Player Management" CssClass="btn btn-primary btn-block btn-lg" OnClick="btnPlayerManagement_Click"/>
                </div>

                <div class="col">
                    <asp:Button ID="btnTeamManagement" runat="server" Text="Team Management" CssClass="btn btn-primary btn-block btn-lg" OnClick="btnTeamManagement_Click"/>
                </div>

                <div class="col">
                    <asp:Button ID="btnTournamentManagement" runat="server" Text="Tournament Management" CssClass="btn btn-primary btn-block btn-lg" OnClick="btnTournamentManagement_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
