<%@ Page Title="" Language="C#" MasterPageFile="~/ValoView.Master" AutoEventWireup="true" CodeBehind="ViewMatches.aspx.cs" Inherits="ValView.ViewMatches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-responsive">
        <asp:GridView CssClass="table table-bordered table-hover table-sm table-dark" ID="gvSeries" runat="server"></asp:GridView>
    </div>
</asp:Content>
