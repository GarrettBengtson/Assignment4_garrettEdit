<%@ Page Title="" Language="C#" MasterPageFile="~/mywork/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewSection.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Create.AddNewSection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        Add a new section by entering the following information:</p>
    <p>
        Section Name:&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="sectionNameRadioList" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RadioButtonList ID="sectionNameRadioList" runat="server">
            <asp:ListItem Value="0">Karate Age-Uke</asp:ListItem>
            <asp:ListItem Value="1">Karate Chudan-Uke </asp:ListItem>
        </asp:RadioButtonList>
&nbsp;</p>
    <p>
        Start Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="startDateTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="startDateTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        ID of member attending:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="memberIDTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="memberIDTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        ID of instructor teaching:&nbsp;&nbsp;
        <asp:TextBox ID="instructorIDTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="instructorIDTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Section Fee:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="sectionFeeTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="sectionFeeTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="submitButton" runat="server" Height="70px" OnClick="submitButton_Click" Text="Submit" Width="110px" />
    </p>
</asp:Content>
