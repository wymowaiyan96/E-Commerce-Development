using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_display_item : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand command = con.CreateCommand();
        command.CommandType = CommandType.Text;

        if (Request.QueryString["category"]==null)
        { //no category is selected
            command.CommandText = ("SELECT * from product");
        }
        else
        { //category is selected
            command.CommandText = "SELECT * from product WHERE product_category='" + Request.QueryString["category"].ToString()+ "'";
        }
      
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        d1.DataSource = dt;
        d1.DataBind();
        con.Close();
    }
}