using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetUsingC
{
    public partial class AddNewCustomer : System.Web.UI.Page
    {
        string SendId;
        protected void Page_Load(object sender, EventArgs e)
        {
            FirstName.Focus();
            dateTime.Text = DateTime.Now.ToLongDateString();
            //ID.Value = Request.QueryString["UserId"];
            SendId = Request.QueryString["UserId"];
            

        }
        // Create and Save a new Customer Recored
        protected void Save_Button_Click(object sender, EventArgs e)
        {
            Boolean TestResult =  ErrorTest();
            if (TestResult == true)

            {
                string FName = FirstName.Text;
                string LName = LastName.Text;
                string EMAdress = EmailAdress.Text;
                string PhNumber = PhoneNo.Text;
                DateTime DT = DateTime.Now;
                string VAdress = Adress.Text;
                string Promo = Promotion.Text;

                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-TKN3DGI;Initial Catalog=MyNewDB;Integrated Security=True;Pooling=False");
                    con.Open();
                    SqlCommand comm = new SqlCommand(@"INSERT INTO  dbo.Customer (FirstName,LastName,EmailAdress,PhoneNo,Adress,JoinedDate,Promotions,UserID)values(@FName,@LName,@Email,@PhNum,@Adress,@Date,@Promo,@UserId)", con);
                    comm.Parameters.Add("@FName", SqlDbType.VarChar).Value = FName;
                    comm.Parameters.Add("@LName", SqlDbType.VarChar).Value = LName;
                    comm.Parameters.Add("@Email", SqlDbType.VarChar).Value = EMAdress;
                    comm.Parameters.Add("@PhNum", SqlDbType.VarChar).Value = PhNumber;
                    comm.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@Adress", SqlDbType.VarChar).Value = VAdress;
                    comm.Parameters.Add("@Promo", SqlDbType.VarChar).Value = Promo;
                    comm.Parameters.Add("@UserId", SqlDbType.Int).Value = Convert.ToInt32(SendId);
                    comm.ExecuteNonQuery();
                    ErrorMessage.Text = "New Customer is Added To the System.";
                    ErrorMessage.ForeColor = System.Drawing.Color.Green;
                    ErrorMessage.Visible = true;
                }
                catch (Exception ex)
                {

                    ErrorMessage.Text = ex.Message;
                    ErrorMessage.ForeColor = System.Drawing.Color.Red;
                    ErrorMessage.Visible = true;
                }
            }

        }
        public void resetControls()
        {
            ErrorMessage.Visible = false;
           FirstName.Text="";
            LastName.Text= "";
            EmailAdress.Text= "";
            PhoneNo.Text= "";
            Adress.Text= "";
            Promotion.Text= "";
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            string test = Result.Value;
            if (test == "true")
            {
                //string url = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("~/AddNewCustomer.aspx?UserId=" + SendId);
            }

        }
        public Boolean ErrorTest()
        {
           Boolean VFirstName =  IsValidFistName(FirstName.Text);
           Boolean VLastName = IsValidLastName(LastName.Text);
           Boolean VEmailAddress = IsValidEmailAdress(EmailAdress.Text);
           Boolean VPhoneNum = IsValidPhoneNumber(PhoneNo.Text);
            if ((VFirstName == true)&&(VLastName== true)&&(VEmailAddress==true)&&(VPhoneNum == true))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        bool IsValidFistName(string FirstName)
        {
            if (FirstName == "")
            {
                ErrorMessage.Text = "Invalid Entry";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Visible = true;
                LFirstName.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                ErrorMessage.Visible = false;
                LFirstName.ForeColor = System.Drawing.Color.Black;
                return true;
            }
        }
        bool IsValidLastName(string LastName)
        {
            if (LastName == "")
            {
                ErrorMessage.Text = "Invalid Entry";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Visible = true;
                LLastName.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                ErrorMessage.Visible = false;
                LLastName.ForeColor = System.Drawing.Color.Black;
                return true;
            }
        }
        bool IsValidEmailAdress(string EmailAdress)
        {
            if (EmailAdress == "") 
            {

                ErrorMessage.Text = "Invalid Entry";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Visible = true;
                LEmail.ForeColor = System.Drawing.Color.Red;
                return false;

            }
            else
            {
                ErrorMessage.Visible = false;
                LEmail.ForeColor = System.Drawing.Color.Black;
                return true;
            }
        }
        //bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        bool IsValidPhoneNumber(string phoneNum)
        {
            string CleanNumber;
            CleanNumber = Regex.Replace(phoneNum, @"[^0-9]+", "");

            if ((CleanNumber == "") || (CleanNumber.Length != 10))
            {
                ErrorMessage.Text = "Invalid Entry";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Visible = true;
                LPhoneNum.ForeColor = System.Drawing.Color.Red;
                return false;

            }
            else
            {
                ErrorMessage.Visible =false;
                LPhoneNum.ForeColor = System.Drawing.Color.Black;
                return true;
            }
        }

        protected void BackToMenu_Click(object sender, EventArgs e)
        {
            string test = Result.Value;
            if (test == "true")
            {
                //string url = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("~/Main.aspx?UserId="+SendId);
            }
        }

        protected void AddAnotherCustomer_Click(object sender, EventArgs e)
        {
            resetControls();
        }
    }
}