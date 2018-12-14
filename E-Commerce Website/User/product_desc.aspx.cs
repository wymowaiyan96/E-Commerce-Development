using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_product_desc : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    int id;
    string product_name, product_desc, product_price, product_qty, product_images;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] == null)
        {//if no pic is selected
            Response.Redirect("display_item.asp");//redirect to item page for user to select
        }
        else
        {//display descriptions.

            id = Convert.ToInt32(Request.QueryString["id"].ToString());//read the id passed from the earlier page
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * From product WHERE id="+id+""; //display only the id of the clicked image
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dA = new SqlDataAdapter(command);
            dA.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
            connection.Close();
         
        }

    }

    protected void b1_Click(object sender, EventArgs e)
    {
     
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * From product WHERE id=" + id + ""; //display only the id of the clicked image
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_desc = dr["product_desc"].ToString();
            product_price = dr["product_price"].ToString();
            product_qty = dr["product_qty"].ToString();
            product_images = dr["product_images"].ToString();
        }
        connection.Close();

        //create a new cookie name AA
        if (Request.Cookies["aa"] == null) //if a cookie is empty
        {   //store multiple values in the cookies
            Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString();
            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1); //expire after one day
        }
        else
        {//if there is cookie previously, add new cookie into it <special symbol |> to split --> old cookie | new cookie
            Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + '|' + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString();
            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
        }

    }
}