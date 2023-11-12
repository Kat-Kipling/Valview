<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="EditPlayer.aspx.cs" Inherits="ValView.Admin.EditPlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5 mx-auto my-4">
                <div class="login-card">
                    <div class="card">
                        <img class="card-img-top rounded-circle profile-picture" alt="Blank avatar icon" src="../images/profile-pics/Default_Profile.png" />
                        <h1 class="card-title">Player Information</h1>
                        <div class="card-body login-card-body">
                            <div class="row">
                                <div class="row">
                                    <div class="col">

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Player ID</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtPlayerID" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Player Name</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtPlayerName" runat="server" placeholder="Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Country</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtPlayerCountry" runat="server" placeholder="Country"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Team</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="drpTeam" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select Team" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Free Agent" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Rank</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="drpRank" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select Rank" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Division</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="drpDiv" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select Division" Value=""></asp:ListItem>
                                                <asp:ListItem Text="N/A" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Main Role</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="drpMainRole" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Secondary Role</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="drpSecRole" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                                                <asp:ListItem Text="N/A" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <label>Main Agent</label>
                                        <div class="form-group">
                                            <asp:DropDownList class="form-control" ID="drpAgent" runat="server" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select Agent" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblOutput" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-info btn-lg" ID="btnAdd" runat="server" Text="Add New Player" OnClick="btnAdd_Click"/>
                                        </div>
                                    </div>

                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-warning btn-lg" ID="btnClear" runat="server" Text="Clear Form" OnClick="btnClear_Click"/>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-primary btn-lg" ID="btnUpdate" runat="server" Text="Update Details" OnClick="btnUpdate_Click"/>
                                        </div>
                                    </div>

                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-danger btn-lg" ID="btnDelete" runat="server" Text="Delete Player" OnClick="btnDelete_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        <div class="col-lg-7  mx-auto my-4 table-responsive">
            <asp:GridView ID="gvPlayers" CssClass="table table-bordered table-hover table-sm table-dark" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvPlayers_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"/>
                    <asp:BoundField DataField="Username" HeaderText="Name"/>
                    <asp:BoundField DataField="Team" HeaderText="Team"/>
                    <asp:BoundField DataField="Country" HeaderText="Country"/>
                    <asp:BoundField DataField="Rank" HeaderText="Rank"/>
                    <asp:BoundField DataField="Division" HeaderText="Division"/>
                    <asp:BoundField DataField="MainRole" HeaderText="Main Role"/>
                    <asp:BoundField DataField="SecondaryRole" HeaderText="Secondary Role"/>
                    <asp:BoundField DataField="MainAgent" HeaderText="Main Agent"/>
                    <asp:ButtonField CommandName="Select" Text="Select" />
                </Columns>
            </asp:GridView>
        </div>
        </div>
    </div>
</asp:Content>
