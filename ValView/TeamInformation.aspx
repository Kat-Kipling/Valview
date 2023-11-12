<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="TeamInformation.aspx.cs" Inherits="ValView.TeamInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="table-responsive">
            <asp:GridView CssClass="table table-bordered table-hover table-sm table-dark" ID="gvTeamInfo" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
