using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_displayOrder : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");

    
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["user"] == null)
        {//redirect to the login page
            Response.Redirect("webform.aspx");
        }

        connection.Open();
        //retrieve the current user email
        SqlCommand command = new SqlCommand("SELECT * FROM orders WHERE email='" + Session["user"].ToString() + "'ORDER BY id DESC", connection);
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        r1.DataSource = dt;
        r1.DataBind();
        connection.Close();
    }
}