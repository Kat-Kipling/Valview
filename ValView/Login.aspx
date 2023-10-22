<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ValView.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-md-6 col-sm-12 mx-auto my-4">
            <div class="login-card">
                <div class="card">
                    <img class="card-img-top rounded-circle profile-picture" alt="Blank avatar icon" src="images/profile-pics/Default_Profile.png" />
                    <h1 class="card-title">Login</h1>
                    <div class="card-body login-card-body">
                        <div class="row">
                            <div class="col">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                                </div>

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group d-grid gap-2 mt-3">
                                    <asp:Button ID="btnSignIn" runat="server" Text="Log in" CssClass="btn btn-primary btn-block btn-lg"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
