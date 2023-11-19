using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork
{
    public partial class Instructor1 : System.Web.UI.Page
    {
        KarateSchoolConnectionsDataContext dbcon;
        //KarateSchoolConnectionString4 connection
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
            instructorIDLabel.Text = myUser.UserID.ToString();


            //Get the instructor info based on the userID
            Instructor myInstructor = (from x in dbcon.Instructors
                                       where x.InstructorID == myUser.UserID
                                       select x).First();

            //Display the first and last name of the instructor
            fNameLabel.Text = myInstructor.InstructorFirstName.ToString();
            lNameLabel.Text = myInstructor.InstructorLastName.ToString();


            //Get the Section info of the logged in user based off the userID
            //If the user has no section, the user will be alerted
            Section mySection = null;
            try
            {
                mySection = (from x in dbcon.Sections
                             where x.Instructor_ID == myUser.UserID
                             select x).First();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('The instructor teaches no sections')</script>");
            }
        }
    }
}