<%@ Page Title="" Language="C#" MasterPageFile="~/mywork/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <strong>Karate School Login</strong></p>
<p>
    <asp:Login ID="karateLogin" runat="server" OnAuthenticate="karateLogin_Authenticate">
    </asp:Login>
</p>
    </asp:Content>
