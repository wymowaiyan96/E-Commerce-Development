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

        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * from category", connection);
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        d1.DataSource = dt;
        d1.DataBind();
        connection.Close();

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        //add into database
        connection.Open();
        SqlCommand command = new SqlCommand("INSERT INTO category VALUES ('"+t1.Text+"')", connection);
        Response.Write("<script>alert('New Category Added!');</script>");
        command.ExecuteNonQuery();
        connection.Close();
        t1.Text = "";
    }
}