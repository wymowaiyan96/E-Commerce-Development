using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class User_register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand command = new SqlCommand("INSERT INTO registration (firstname, lastname, email, password, address, city, state, postal, mobile) VALUES (@firstname, @lastname, @email, @password, @address, @city,@state, @postal, @mobile)", con );
        command.Parameters.Add(@"firstname",tbxFirstName.Text);
        command.Parameters.Add(@"lastname", tbxLastName.Text);
        command.Parameters.Add(@"email",tbxEmail.Text);
        command.Parameters.Add(@"password",tbxPassword.Text);
        command.Parameters.Add(@"address",tbxAddress.Text);
        command.Parameters.Add(@"city",tbxCity.Text);
        command.Parameters.Add(@"state",tbxState.Text);
        command.Parameters.Add(@"postal",tbxPostal.Text);
        command.Parameters.Add(@"mobile",tbxPhone.Text);
        command.ExecuteNonQuery();
        con.Close();

        l1.Text = "Your Account has been created";
        tbxFirstName.Text = "";
        tbxLastName.Text = "";
        tbxEmail.Text = "";
        tbxPassword.Text = "";
        tbxAddress.Text = "";
        tbxCity.Text = "";
        tbxState.Text = "";
        tbxPostal.Text = "";
        tbxPhone.Text = "";


    }
}