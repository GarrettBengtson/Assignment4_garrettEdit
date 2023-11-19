using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork.Create
{
    public partial class CreateNewInstructor : System.Web.UI.Page
    {
        KarateSchoolConnectionsDataContext dbcon;
        //KarateSchoolConnectionString4 connection
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bengt\\Desktop\\Modern_CSCI_Dev\\Assignment4\\Assignment4_garrettEdit\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //The submit Button click event won't occur unless the user has
        //given an input for every text box. This is due to the required field
        //validators.
        //In order to create a new instructor, there has to be a NetUser created as
        //well. This will also occur during the click event.
        protected void submitButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolConnectionsDataContext(connectionString);
            try
            {
                //Create new NetUser. The username and password will be in
                //the format "user[userID]", but the userID cannot be read until
                //after the entry is submitted to the table. So, use a placeholder
                //for username and password for now.
                NetUser myNetUser = new NetUser();
                myNetUser.UserName = "user";
                myNetUser.UserPassword = "user";
                myNetUser.UserType = "Instructor";

                //Save the new NetUser to the table
                dbcon.NetUsers.InsertOnSubmit(myNetUser);
                dbcon.SubmitChanges();

                //Edit the username and password to be in the correct format.
                myNetUser.UserName = myNetUser.UserName + myNetUser.UserID;
                myNetUser.UserPassword = myNetUser.UserPassword + myNetUser.UserID;

                //Create new Instructor, with their ID being the same
                //as the NetUser ID from above
                Instructor myInstructor = new Instructor();
                myInstructor.InstructorID = myNetUser.UserID;
                myInstructor.InstructorFirstName = fNameTextBox.Text;
                myInstructor.InstructorLastName = lNameTextBox.Text;
                myInstructor.InstructorPhoneNumber = phoneNumTextBox.Text;

                //Save the new instructor to the table
                dbcon.Instructors.InsertOnSubmit(myInstructor);
                dbcon.SubmitChanges();

                //Send the user back to the admin page once creation of instructor has finished.
                Response.Redirect("~/mywork/Administrator.aspx");
            }
            
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid input, try again')</script>");
            }
            
        }
    }
}