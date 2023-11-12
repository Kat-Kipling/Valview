<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="EditTeams.aspx.cs" Inherits="ValView.Admin.EditTeams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5 mx-auto my-4">
                <div class="login-card">
                    <div class="card">
                        <img class="card-img-top rounded-circle profile-picture" alt="Blank avatar icon" src="../images/profile-pics/Default_Profile.png" />
                        <h1 class="card-title">Team Information</h1>
                        <div class="card-body login-card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Team ID</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPlayerID" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Team Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPlayerName" runat="server" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Team Member 1</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpTeam" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Team" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
