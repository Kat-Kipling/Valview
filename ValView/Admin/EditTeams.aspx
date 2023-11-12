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
                                        <asp:TextBox CssClass="form-control" ID="txtTeamID" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label>Team Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtTeamName" runat="server" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Team Region</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpRegion" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Region" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label>Team Country</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtTeamCountry" runat="server" placeholder="Country"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Team Member 1</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpTeam1" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Team Member" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <label>Team Member 2</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpTeam2" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Team Member" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <label>Team Member 3</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpTeam3" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Team Member" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Team Member 4</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpTeam4" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Team Member" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label>Team Member 5</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="drpTeam5" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Select Team Member" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-7 mx-auto my-4 table-responsive">
                <asp:GridView ID="gvTeams" CssClass="table table-bordered table-hover table-sm table-dark" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvTeams_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Team ID" HeaderText="ID"/>
                        <asp:BoundField DataField="Team Name" HeaderText="Team Name"/>
                        <asp:BoundField DataField="Country" HeaderText="Country"/>
                        <asp:BoundField DataField="Region Name" HeaderText="Region"/>
                        <asp:ButtonField CommandName="Select" Text="Select" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
