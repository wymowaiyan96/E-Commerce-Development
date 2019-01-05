using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_deleteCategory : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    string category;

    protected void Page_Load(object sender, EventArgs e)
    {
        category = Request.QueryString["category"].ToString();
        connection.Open();
        SqlCommand command = new SqlCommand("DELETE from category WHERE product_category='"+category.ToString()+"'", connection);
        command.ExecuteNonQuery();
        SqlCommand command2 = new SqlCommand("DELETE from product WHERE product_category='" + category.ToString() + "'", connection);
        command2.ExecuteNonQuery();
        connection.Close();
        Response.Redirect("addCategory.aspx");
    }
}