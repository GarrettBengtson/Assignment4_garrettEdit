using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_garrettEdit.mywork
{
    public partial class Login : System.Web.UI.Page
    {

        KarateSchoolConnectionsDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolConnectionsDataContext(connectionString);
        }

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bengt\\Desktop\\Modern_CSCI_Dev\\Assignment4\\Assignment4_garrettEdit\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        //Reads the user's input. Sends the user to the page that corresponds
        //to the given username's userType
        protected void karateLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = karateLogin.UserName;
            string pass = karateLogin.Password;

            HttpContext.Current.Session["userName"] = userName;
            HttpContext.Current.Session["pass"] = pass;

            NetUser myUser = null;
            try
            {
                //Search for user based off username and password
                myUser = (from x in dbcon.NetUsers
                          where x.UserName == HttpContext.Current.Session["userName"].ToString()
                          && x.UserPassword == HttpContext.Current.Session["pass"].ToString()
                          select x).First();
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx", true);
            }
            

            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;

            }

            //Send to member page
            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["userName"].ToString(), true);

                Response.Redirect("~/mywork/Member.aspx");
            }
            //Send to instructor page
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["userName"].ToString(), true);

                Response.Redirect("~/mywork/Instructor.aspx");
            }
            //Send to Admin page
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["userName"].ToString(), true);

                Response.Redirect("~/mywork/Administrator.aspx");
            }
            //Refreshes the page if the input was not accepted
            else
                Response.Redirect("login.aspx", true);


        }
    }
}