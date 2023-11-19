using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork.Create
{
    public partial class CreateNewMember : System.Web.UI.Page
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
        //In order to create a new member, there has to be a NetUser created as
        //well. This will also occur during the click event.
        protected void submitButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolConnectionsDataContext(connectionString);
            try
            {
                //Parses string into DateTime object. If any inputs are invalid,
                //the user can try again.
                string dateInput = joinDateTextBox.Text;
                var parsedDate = DateTime.Parse(dateInput);

                //Create new NetUser, user and password are templates. We will add the
                //UserID to the end of the string "user" to make the username and password.
                //The number based on the userID can't be appended until after the submission
                //of the new NetUser to the table.
                NetUser myNetUser = new NetUser();
                myNetUser.UserName = "user";
                myNetUser.UserPassword = "user";
                myNetUser.UserType = "Member";

                //Save the new NetUser to the table
                dbcon.NetUsers.InsertOnSubmit(myNetUser);
                dbcon.SubmitChanges();

                //Edit the user and password to match the format "user[userID]"
                myNetUser.UserName = myNetUser.UserName + myNetUser.UserID;
                myNetUser.UserPassword = myNetUser.UserPassword + myNetUser.UserID;
                dbcon.SubmitChanges();

                //Create new Member, with their ID being the same
                //as the NetUser ID from above
                Member myMember = new Member();
                myMember.Member_UserID = myNetUser.UserID;
                myMember.MemberFirstName = fNameTextBox.Text;
                myMember.MemberLastName = lNameTextBox.Text;
                myMember.MemberDateJoined = parsedDate;
                myMember.MemberPhoneNumber = phoneNumTextBox.Text;
                myMember.MemberEmail = emailTextBox.Text;

                //Save the new member to the table
                dbcon.Members.InsertOnSubmit(myMember);
                dbcon.SubmitChanges();

                //Send the user back to the admin page once creation of member has finished.
                Response.Redirect("~/mywork/Administrator.aspx");
            }
            
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid input, try again')</script>");
            }
        }
    }
}