<%@ Page Title="" Language="C#" MasterPageFile="~/mywork/Admin.Master" AutoEventWireup="true" CodeBehind="CreateNewMember.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.CreateNewMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Add a new member by filling out the member&#39;s following information:</p>
    <p class="auto-style1">
        First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="lNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        Join Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="joinDateTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        Phone Number:
        <asp:TextBox ID="phoneNumTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        <asp:Button ID="createButton" runat="server" Height="59px" Text="Create Member" Width="107px" />
    </p>
</asp:Content>
