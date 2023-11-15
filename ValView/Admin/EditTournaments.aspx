<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="EditTournaments.aspx.cs" Inherits="ValView.Admin.EditTournaments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 mx-auto my-4">
                <div class="login-card">
                    <div class="card">
                        <asp:Image ID="imgTournamentLogo" CssClass="card-img-top" AlternateText="Tournament Banner Picture" ImageUrl="~/images/tournaments/Default_Banner.jpg" runat="server"/>
                        <h1 class="card-title">Tournament Information</h1>
                        <div class="card-body login-card-body">
                                <div class="row">
                                    <div class="col">
                                        <label>Image: </label>
                                        <div class="form-group">
                                            <asp:FileUpload CssClass="form-control" ID="uplBannerPicture" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Tournament ID</label>
                                        <asp:TextBox CssClass="form-control" ID="txtTournamentID" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Tournament Name</label>
                                        <asp:TextBox CssClass="form-control" ID="txtTeamName" runat="server" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <label>Start Date</label>
                                        <asp:Calendar ID="cldStartDate" runat="server"></asp:Calendar>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <label>End Date</label>
                                        <asp:Calendar ID="cldEndDate" runat="server"></asp:Calendar>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <label>Description</label>
                                        <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" placeholder="Description"></asp:TextBox>
                                    </div>
                                </div>

                             <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-info btn-lg" ID="btnAdd" runat="server" Text="Add New Tournament" OnClick="btnAdd_Click"/>
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
                                            <asp:Button class="btn btn-danger btn-lg" ID="btnDelete" runat="server" Text="Delete Tournament" OnClick="btnDelete_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6 mx-auto my-4 table-responsive">
                <asp:GridView ID="gvTournaments" CssClass="table table-bordered table-hover table-sm table-dark" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvTournaments_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Tournament ID" HeaderText="ID"/>
                        <asp:BoundField DataField="Tournament Name" HeaderText="Name"/>
                        <asp:BoundField DataField="Start Date" HeaderText="Start Date"/>
                        <asp:BoundField DataField="End Date" HeaderText="End Date"/>
                        <asp:BoundField DataField="Description" HeaderText="Description"/>
                        <asp:ButtonField CommandName="Select" Text="Select" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
