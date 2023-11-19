<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment4_garrettEdit.mywork.Members" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700; background-color:honeydew; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">
    <form id="form1" runat="server">
        <div>
            Welcome,
            <asp:Label ID="firstNameLabel" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lastNameLabel" runat="server" Text="Label"></asp:Label>
            to your Member page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" />
            &nbsp;&nbsp;
        </div>
        <p>
            User ID:
            <asp:Label ID="userIDLabel" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label ID="instructorFNameLabel" runat="server" Text="HiddenInstructorLabel" Visible="False"></asp:Label>
        </p>
        <p>
            <strong>Here is your section and instructor information:</strong></p>
        <p>
            <!--Padding changed to make the table more readable-->
            <asp:GridView ID="sectionGridview" runat="server" CellPadding="5" AutoGenerateColumns="False" DataSourceID="sectionData">
                <Columns>
                    <asp:BoundField DataField="SectionName" HeaderText="Section Name" SortExpression="SectionName" />
                    <asp:BoundField DataField="SectionStartDate" HeaderText="Section Start Date" SortExpression="SectionStartDate" />
                    <asp:BoundField DataField="SectionFee" HeaderText="Section Fee" SortExpression="SectionFee" />
                </Columns>
            </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:SqlDataSource ID="sectionData" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString4 %>" SelectCommand="SELECT [SectionName], [SectionStartDate], [SectionFee] FROM [Section] WHERE ([Member_ID] = @Member_ID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="userIDLabel" Name="Member_ID" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        <!--Padding changed to make the table more readable-->
        <asp:GridView ID="InstructorInfoGridView" runat="server" CellPadding="5" AutoGenerateColumns="False" DataSourceID="instructorData">
            <Columns>
                <asp:BoundField DataField="InstructorFirstName" HeaderText="Instructor First Name" SortExpression="InstructorFirstName" />
                <asp:BoundField DataField="InstructorLastName" HeaderText="Instructor Last Name" SortExpression="InstructorLastName" />
            </Columns>
        </asp:GridView>
            <asp:SqlDataSource ID="instructorData" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString4 %>" SelectCommand="SELECT [InstructorFirstName], [InstructorLastName] FROM [Instructor] WHERE ([InstructorFirstName] = @InstructorFirstName)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="instructorFNameLabel" Name="InstructorFirstName" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
    </form>
</body>
</html>
