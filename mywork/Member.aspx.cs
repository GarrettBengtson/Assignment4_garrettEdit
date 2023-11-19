using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork
{
    public partial class Members : System.Web.UI.Page
    {

        KarateSchoolConnectionsDataContext dbcon;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bengt\\Desktop\\Modern_CSCI_Dev\\Assignment4\\Assignment4_garrettEdit\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolConnectionsDataContext(connectionString);
            string currentUserName = User.Identity.Name; 

            //Load the current user that logged in
            NetUser myUser = (from x in dbcon.NetUsers
                              where x.UserName == currentUserName
                              select x).First();

            //Display the user ID
            userIDLabel.Text = myUser.UserID.ToString();


            //Get the member info based on the userID
            Member myMember = (from x in dbcon.Members
                               where x.Member_UserID == myUser.UserID
                               select x).First();

            //Display the first and last name of the logged in user
            firstNameLabel.Text = myMember.MemberFirstName;
            lastNameLabel.Text = myMember.MemberLastName;


            //Get the Section info of the logged in user based off the userID
            //If the user has no section, the user will be alerted
            Section mySection = null;
            try
            {
                mySection = (from x in dbcon.Sections
                             where x.Member_ID == myUser.UserID
                             select x).First();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('The user is in no section')</script>");
            }


            //Updates the hidden Instructor Name label for the gridview
            Instructor myInstructor = null;
            try
            {
                myInstructor = (from x in dbcon.Instructors
                                where x.InstructorID == mySection.Instructor_ID
                                select x).First();

                instructorFNameLabel.Text = myInstructor.InstructorFirstName;
            }
            catch (Exception ex)
            {

            }

        }

    }
}