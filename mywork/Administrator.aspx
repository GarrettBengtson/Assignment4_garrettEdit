<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700; background-color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">
    <form id="form1" runat="server">
        <div>
            Welcome to your Administrator page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" />
        </div>
        <p>
            &nbsp;</p>
        <p>
            <strong>Member Info:</strong></p>
        <p>
            <!--Padding changed to make the table more readable-->
            <asp:GridView ID="MemberInfoGridView" CellPadding="5" runat="server">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <strong>Instructor Info:</strong></p>
        <p>
            <!--Padding changed to make the table more readable-->
            <asp:GridView ID="InstructorInfoGridView" CellPadding="5" runat="server">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <strong>Create New Member: </strong>
            <asp:Button ID="createNewMemberButton" runat="server" Text="Create" OnClick="createNewMemberButton_Click" />
        </p>
        <p>
            <strong>Create New Instructor:
            <asp:Button ID="createNewInstructorButton" runat="server" Text="Create" OnClick="createNewInstructorButton_Click" />
            </strong>
        </p>
        <p>
            <strong>Delete Member (enter member ID):
            <asp:TextBox ID="deleteMemberIDTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="deleteMemberButton" runat="server" Text="Delete" OnClick="deleteMemberButton_Click"/>
            </strong>
        </p>
        <p>
            <strong>Delete Instructor (enter instructor ID):
            <asp:TextBox ID="deleteInstructorIDTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="deleteInstructorButton" runat="server" Text="Delete" OnClick="deleteInstructorButton_Click" />
            </strong>
        </p>
        <p>
            <strong>Add New Section:
            <asp:Button ID="newSectionButton" runat="server" Text="Add" OnClick="newSectionButton_Click" />
            </strong>
        </p>
    </form>
</body>
</html>
