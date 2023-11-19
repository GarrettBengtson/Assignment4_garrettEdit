<%@ Page Title="" Language="C#" MasterPageFile="~/mywork/Admin.Master" AutoEventWireup="true" CodeBehind="CreateNewInstructor.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.CreateNewInstructor" %>
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
        Add a new instructor by filling out the instructor&#39;s following information:</p>
    <p class="auto-style1">
        First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="lNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        Phone Number:
        <asp:TextBox ID="phoneNumTextBox" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        <asp:Button ID="createButton" runat="server" Height="69px" Text="Create Instructor" Width="124px" />
    </p>
</asp:Content>
