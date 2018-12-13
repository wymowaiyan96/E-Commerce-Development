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
    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\WebSite4NOW\App_Data\shop.mdf;Integrated Security=True");
    int id;
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
}