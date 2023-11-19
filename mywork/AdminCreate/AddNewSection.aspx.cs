using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork.Create
{
    public partial class AddNewSection : System.Web.UI.Page
    {
        KarateSchoolConnectionsDataContext dbcon;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bengt\\Desktop\\Modern_CSCI_Dev\\Assignment4\\Assignment4_garrettEdit\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Creates a new section based on the given inputs.
        //All fields are required.
        protected void submitButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolConnectionsDataContext(connectionString);

            try
            {
                //Determine which radio button the user has selected and
                //apply the section name accordingly. Age-Uke = 0, Chudan-Uke = 1
                string sectionName;

                if(Convert.ToInt32(sectionNameRadioList.SelectedValue) == 0)
                {
                    sectionName = "Karate Age-Uke";
                }
                else
                {
                    sectionName = "Karate Chudan-Uke";
                }
                //Create the section object and give it the sectionName
                Section mySection = new Section();
                mySection.SectionName = sectionName;

                //Parses the date text box input into a DateTime object.
                string dateInput = startDateTextBox.Text;
                var parsedDate = DateTime.Parse(dateInput);
                //Give the section object the parsed date as its SectionStartDate
                mySection.SectionStartDate = parsedDate;

                //determine if the memberID is valid by finding out if the userID
                //corresponds to a Member
                NetUser selectedMemberUser = (from user in dbcon.NetUsers
                                              where user.UserID == Convert.ToInt32(memberIDTextBox.Text)
                                              select user).First();

                //If the ID corresponds to a Member, set the section object's Member_ID to the input
                if(selectedMemberUser.UserType == "Member")
                {
                    mySection.Member_ID = Convert.ToInt32(memberIDTextBox.Text);
                }
                //If the ID doesn't correspond to a Member, tell the user the error that occurred
                else
                {
                    Response.Write("<script>alert('The memberID input does not correspond to a Member')</script>");
                    throw new Exception();
                }
                

                //determine if the instructorID is valid by finding out if the userID
                //corresponds to an Instructor
                NetUser selectedInstructorUser = (from user in dbcon.NetUsers
                                                  where user.UserID == Convert.ToInt32(instructorIDTextBox.Text)
                                                  select user).First();
                //If the ID corresponds to an Instructor, set the section object's Instructor_ID to the input
                if (selectedInstructorUser.UserType == "Instructor")
                {
                    mySection.Instructor_ID = Convert.ToInt32(instructorIDTextBox.Text);
                }
                //If the ID doesn't correspond to an Instructor, tell the user an error occurred
                else
                {
                    Response.Write("<script>alert('The instructorID input does not correspond to an Instructor')</script>");
                    throw new Exception();
                }
                
                //Set the section object's SectionFee to the sectionFee input
                mySection.SectionFee = Convert.ToDecimal(sectionFeeTextBox.Text);

                //Save the new section info to the table
                dbcon.Sections.InsertOnSubmit(mySection);
                dbcon.SubmitChanges();

                //Send the user back to the admin page once creation of section has finished.
                Response.Write("<script>alert('Section added')</script>");
                Response.Redirect("~/mywork/Administrator.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid input, try again')</script>");
            }



        }
    }
}