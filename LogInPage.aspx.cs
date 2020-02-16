using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;


namespace AspNetUsingC
{
    public partial class LogInPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Focus();

            UserId.Value = "0";

    }

        protected void Enter_Click(object sender, EventArgs e)
        {
            //Empty User name or Password.
            if ((UserName.Text == "") || (Password.Text == ""))
            {
                if (UserName.Text == "") { InvalidUserName.Visible = true; }
                if (Password.Text == "") { InvalidPassword.Visible = true; }
            }
            else
            {
                InvalidUserName.Visible = false;
                InvalidPassword.Visible = false;
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TKN3DGI;Initial Catalog=MyNewDB;Integrated Security=True;Pooling=False");

                    con.Open();

                    SqlCommand comm = new SqlCommand("select count(*) from dbo.LogIn where dbo.LogIn.UserName='" + UserName.Text + "'and dbo.LogIn.Password='" + Password.Text + "'", con);
                    Int32 Counter = (Int32)comm.ExecuteScalar();
                    if (Counter == 1)
                    {
                        comm = new SqlCommand("Select dbo.Login.Password from dbo.LogIn Where dbo.LogIn.UserName='" + UserName.Text + "'", con);

                        string psw = (string)comm.ExecuteScalar();
                        comm = new SqlCommand("Select UserId from dbo.LogIn Where dbo.LogIn.UserName = '" + UserName.Text + "'", con);
                        int Id = (int)comm.ExecuteScalar();

                        comm = new SqlCommand("Select dbo.Login.JobPosition from dbo.LogIn Where dbo.LogIn.UserName='" + UserName.Text + "'", con);
                        string userPosition = (string)comm.ExecuteScalar();

                        // Enter the Admin site.

                        if ((psw == Password.Text) && (userPosition.ToUpper() == "A")) Response.Redirect("~/AdminMain.aspx");
                        else if ((psw == Password.Text) && (userPosition.ToUpper() == "C")) //Enter the Customer site.
                        {
                            UserId.Value = Convert.ToString(Id);
                            Response.Redirect("~/Main.aspx?UserId=" + Id);

                        }
                        else
                            ErrorMessage.Visible = true;
                    }
                    else
                    {

                        ErrorMessage.Visible = true;

                        UserName.Focus();
                    }


                    con.Close();
                }
                catch (Exception)
                {
                    // Catching any connecting error with the data base without make the page crash.
                    Response.Write("<script type=\"text/javascript\">alert('Data Base Error Please Call The DBA!')</script>");

                }
            }
}

        protected void Cancel_Click(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            InvalidUserName.Visible = false;
            InvalidPassword.Visible = false;
            //Should be changed when the web comes to Life
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            // Response.Redirect(@"http://localhost:56727/LogInPage.aspx");
            Response.Redirect(url);
        }


    }
}