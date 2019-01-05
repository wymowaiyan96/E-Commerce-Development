using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_addCategory : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("adminLogin.aspx");
        }

        //add into database
        connection.Open();
        SqlCommand command = new SqlCommand("INSERT INTO category VALUES @category", connection);
        command.Parameters.Add(@"category", t1.Text);
        l1.Text = t1.Text + " has been added";
        command.ExecuteNonQuery();
        connection.Close();
    }
}