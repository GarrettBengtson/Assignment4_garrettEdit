<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Instructor1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700; background-color:aliceblue; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">
    <form id="form1" runat="server">
        <div>
            Welcome,
            <asp:Label ID="fNameLabel" runat="server" Text="fName"></asp:Label>
            <asp:Label ID="lNameLabel" runat="server" Text="lName"></asp:Label>
            to your Instructor page.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <p>
            Instructor ID:
            <asp:Label ID="instructorIDLabel" runat="server" Text="instructorID"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <strong>Your members and Sections:</strong></p>
        <p>
            <!--Padding changed to make the table more readable-->
            <asp:GridView ID="GridView1" runat="server" CellPadding="5" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="MemberFirstName" HeaderText="First Name" SortExpression="MemberFirstName" />
                    <asp:BoundField DataField="MemberLastName" HeaderText="Last Name" SortExpression="MemberLastName" />
                    <asp:BoundField DataField="SectionName" HeaderText="Section Name" SortExpression="SectionName" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString4 %>" SelectCommand="SELECT Member.MemberFirstName, Member.MemberLastName, Section.SectionName FROM Instructor INNER JOIN Section ON Instructor.InstructorID = Section.Instructor_ID INNER JOIN Member ON Section.Member_ID = Member.Member_UserID WHERE (Instructor.InstructorID = @InstructorID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="instructorIDLabel" Name="InstructorID" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
    </form>
</body>
</html>
