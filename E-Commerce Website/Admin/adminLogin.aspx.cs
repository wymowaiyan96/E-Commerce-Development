using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_adminLogin : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    int i;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        i = 0;
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * FROM admin_login WHERE username='" + t1.Text + "' and password='" + t2.Text + "'"; 
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        i = Convert.ToInt32(dt.Rows.Count.ToString());
        Response.Write(i);

        if (i==1)
        {
            Session["admin"] = t1.Text;
            Response.Redirect("add_product.aspx");
        }
        else
        {
            l1.Text = "Invalid Credentials";
        }
        connection.Close();
    }
}