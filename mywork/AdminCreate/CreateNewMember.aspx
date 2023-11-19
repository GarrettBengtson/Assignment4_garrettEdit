<%@ Page Title="" Language="C#" MasterPageFile="~/mywork/Admin.Master" AutoEventWireup="true" CodeBehind="CreateNewMember.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Create.CreateNewMember" %>
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
        <span class="auto-style1"><strong>Add a new Member by entering their information here:</strong></span></p>
    <p>
        First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fNameTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fNameTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="lNameTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lNameTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Join Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="joinDateTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="joinDateTextBox" ErrorMessage="Required (MM/DD/YYYY)" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Phone Number:&nbsp; <asp:TextBox ID="phoneNumTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="phoneNumTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="submitButton" runat="server" Height="62px" OnClick="submitButton_Click" Text="Submit" Width="139px" />
    </p>
</asp:Content>
