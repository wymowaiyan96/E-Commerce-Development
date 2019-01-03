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
    int id, qty;
    string product_name, product_desc, product_price, product_qty, product_images;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] == null)
        {//if no pic is selected
            Response.Redirect("display_item.aspx");//redirect to item page for user to select
        }
        else
        {//display descriptions.

            id = Convert.ToInt32(Request.QueryString["id"].ToString());//read the id passed from the earlier page
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * From product WHERE id=" + id + ""; //display only the id of the clicked image
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dA = new SqlDataAdapter(command);
            dA.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
            connection.Close();

        }

        qty = get_qty(id);

        if (qty==0)
        {
            l2.Visible = false;
            t1.Visible = false;
            b1.Visible = false;
            l1.Text = "Out of Stock";
            l1.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }

        connection.Open();

        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * From product WHERE id=" + id + ""; //display only the id of the clicked image
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        //place holder for the values to store in cookies
        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_desc = dr["product_desc"].ToString();
            product_price = dr["product_price"].ToString();
            product_qty = dr["product_qty"].ToString();
            product_images = dr["product_images"].ToString();
        }
        // connection.Close();

        if (Convert.ToInt32(t1.Text) > Convert.ToInt32(product_qty))
        {
            l1.Text = "Please lower Quantity";
            l1.ForeColor = System.Drawing.Color.Red;
        }

        else
        {
            l1.Text = "";
            //create a new cookie name AA
            if (Request.Cookies["aa"] == null) //if a cookie is empty
            {   //store multiple values in the cookies. Separate each value with a ,
                Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + t1.Text + "," + product_images.ToString() + "," + id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1); //expire after one day
            }
            else
            {//if there is cookie previously, add new cookie into it <special symbol |> to split --> old cookie | new cookie
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + '|' + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + t1.Text + "," + product_images.ToString() + "," + id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }

            SqlCommand cmd1 = connection.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "UPDATE product SET product_qty=product_qty-" + t1.Text + "WHERE id="+id;
            cmd1.ExecuteNonQuery();
            Response.Redirect("product_desc.aspx?id=" + id.ToString()); //display the current page with the current id of the item

        }

    }

    public int get_qty(int id)
    {
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * From product WHERE id=" + id + ""; //display only the id of the clicked image
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        //place holder for the values to store in cookies
        foreach (DataRow dr in dt.Rows)
        {
            qty = Convert.ToInt32(dr["product_qty"].ToString());
        }
        return qty;
    }
}



