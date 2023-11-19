using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateSchoolConnectionsDataContext dbcon;
        //KarateSchoolConnectionString4 connection
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bengt\\Desktop\\Modern_CSCI_Dev\\Assignment4\\Assignment4_garrettEdit\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolConnectionsDataContext(connectionString);
            string currentUserName = User.Identity.Name;

            //Populate the Member Info GridView
            fillMemberInfoGridView();

            //Populate the Instructor Info GridView
            fillInstructorInfoGridView();

        }

        //Uses a LINQ query to get every member's first name, last name,
        //phone number, and date joined
        private void fillMemberInfoGridView()
        {
            var results = from member in dbcon.Members
                          select new
                          {
                              member.MemberFirstName,
                              member.MemberLastName,
                              member.MemberPhoneNumber,
                              member.MemberDateJoined
                          };
            
            MemberInfoGridView.DataSource = results;
            MemberInfoGridView.DataBind();

            //Format the column headers to have nice format
            MemberInfoGridView.HeaderRow.Cells[0].Text = "First Name";
            MemberInfoGridView.HeaderRow.Cells[1].Text = "Last Name";
            MemberInfoGridView.HeaderRow.Cells[2].Text = "Phone Number";
            MemberInfoGridView.HeaderRow.Cells[3].Text = "Date Joined";
        }

        //Uses a LINQ query to get every instructor's first and last name
        private void fillInstructorInfoGridView()
        {
            var results = from instructor in dbcon.Instructors
                          select new
                          {
                              instructor.InstructorFirstName,
                              instructor.InstructorLastName
                          };
            InstructorInfoGridView.DataSource = results;
            InstructorInfoGridView.DataBind();

            //Format the column headers to have a nice format
            InstructorInfoGridView.HeaderRow.Cells[0].Text = "First Name";
            InstructorInfoGridView.HeaderRow.Cells[1].Text = "Last Name";
        }

        //Refreshes the entries in the Members Grid View
        private void refreshMembers()
        {
            fillMemberInfoGridView();
        }

        //Refreshes the entries in the Instructors Grid View
        private void refreshInstructors()
        {
            fillInstructorInfoGridView();
        }

        //Deletes the member at the inputted ID.
        //When a member is deleted, the Member, NetUser, and Section tables
        //all need to be updated to remove the Member's info.
        protected void deleteMemberButton_Click(object sender, EventArgs e)
        {
            try
            {
                dbcon = new KarateSchoolConnectionsDataContext(connectionString);
                int selectedID = Convert.ToInt32(deleteMemberIDTextBox.Text);

                //Select the member, NetUser, and section they are in
                Member selectedMember = (from item in dbcon.Members
                                         where item.Member_UserID == selectedID
                                         select item).First();
                NetUser selectedUser = (from item in dbcon.NetUsers
                                        where item.UserID == selectedID
                                        select item).First();

                //A member doesn't necessarily have any sections. In the case
                //that they don't, there is no need to delete any sections from the
                //section table. This check determines if the member has any sessions
                //based off of their ID. If they do, the section will be deleted from the table.
                bool doesMemberHaveSessions = dbcon.Sections.AsEnumerable().Any(row => selectedID == row.Member_ID);
                if (doesMemberHaveSessions == true)
                {
                    Section selectedSection = (from item in dbcon.Sections
                                               where item.Member_ID == selectedID
                                               select item).First();

                    dbcon.Sections.DeleteOnSubmit(selectedSection);
                }

                //Delete the member from the selected tables
                dbcon.Members.DeleteOnSubmit(selectedMember);
                dbcon.NetUsers.DeleteOnSubmit(selectedUser);

                dbcon.SubmitChanges();

                //Tell the admin the delete was successful
                Response.Write("<script>alert('delete successful')</script>");

                //Refresh the gridview 
                refreshMembers();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Invalid input, try again')</script>");
            }
        }

        //Deletes the instructor at the inputted ID.
        //When a instructor is deleted, the Instructor, NetUser, and Section tables
        //all need to be updated to remove the Instructor's info.
        protected void deleteInstructorButton_Click(object sender, EventArgs e)
        {
            try
            {
                dbcon = new KarateSchoolConnectionsDataContext(connectionString);
                int selectedID = Convert.ToInt32(deleteInstructorIDTextBox.Text);

                //Select the instructor, NetUser, and section they are in
                Instructor selectedInstructor = (from item in dbcon.Instructors
                                                 where item.InstructorID == selectedID
                                                 select item).First();
                NetUser selectedUser = (from item in dbcon.NetUsers
                                        where item.UserID == selectedID
                                        select item).First();

                //An instructor doesn't necessarily have any sections. In the case
                //that they don't, there is no need to delete any sections from the
                //section table. This check determines if the instructor has any sessions
                //based off of their ID. If they do, the section will be deleted from the table.
                bool doesInstructorHaveSessions = dbcon.Sections.AsEnumerable().Any(row => selectedID == row.Instructor_ID);
                if(doesInstructorHaveSessions == true)
                {
                    Section selectedSection = (from item in dbcon.Sections
                                               where item.Instructor_ID == selectedID
                                               select item).First();

                    dbcon.Sections.DeleteOnSubmit(selectedSection);
                }
                

                //Delete the member from the selected tables
                dbcon.Instructors.DeleteOnSubmit(selectedInstructor);
                dbcon.NetUsers.DeleteOnSubmit(selectedUser);


                dbcon.SubmitChanges();

                //Tell the admin the delete was successful
                Response.Write("<script>alert('delete successful')</script>");

                //Refresh the gridview 
                refreshInstructors();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid input, try again')</script>");
            }
        }

        //Sends user to the CreateNewMember page.
        protected void createNewMemberButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/mywork/AdminCreate/CreateNewMember.aspx");
        }

        //Sends user to the CreateNewInstructor page.
        protected void createNewInstructorButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/mywork/AdminCreate/CreateNewInstructor.aspx");
        }

        //Sends user to the AddNewSection page.
        protected void newSectionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/mywork/AdminCreate/AddNewSection.aspx");
        }
    }
}