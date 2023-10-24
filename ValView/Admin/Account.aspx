<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ValView.Admin.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md">
                <div class="profile-card">
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
            <div class="col-md">
                a
            </div>
        </div>
    </div>
</asp:Content>
