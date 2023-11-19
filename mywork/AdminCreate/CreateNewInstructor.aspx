<%@ Page Title="" Language="C#" MasterPageFile="~/mywork/Admin.Master" AutoEventWireup="true" CodeBehind="CreateNewInstructor.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Create.CreateNewInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Add a new Instructor by entering their information here:</p>
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
        Phone Number:&nbsp;
        <asp:TextBox ID="phoneNumTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="phoneNumTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="submitButton" runat="server" Height="67px" OnClick="submitButton_Click" Text="Submit" Width="98px" />
    </p>
</asp:Content>
