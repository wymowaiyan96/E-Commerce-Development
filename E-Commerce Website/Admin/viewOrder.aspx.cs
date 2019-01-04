using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_viewOrder : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    int id;
    int total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] == null)
        {
            Response.Redirect("adminLogin.aspx");
        }

        //id passed from the displayOrder page
        id = Convert.ToInt32(Request.QueryString["id"].ToString());

        connection.Open();
        SqlCommand command1 = new SqlCommand("SELECT * FROM orders where id="+id+"", connection);
        command1.ExecuteNonQuery();
        DataTable dt1 = new DataTable();
        SqlDataAdapter dA1 = new SqlDataAdapter(command1);
        dA1.Fill(dt1);
        r2.DataSource = dt1;
        r2.DataBind();
        connection.Close();




        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * From order_details WHERE order_id=" + id + ""; //display only the id of the clicked image
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            total = total + Convert.ToInt32(dr["product_price"].ToString()) * Convert.ToInt32(dr["product_qty"].ToString());

        }
        l1.Text = "Total Price: " + total.ToString();
        r1.DataSource = dt;
        r1.DataBind();
        connection.Close();
    }
}