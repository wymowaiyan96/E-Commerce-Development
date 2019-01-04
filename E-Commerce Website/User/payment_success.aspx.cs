using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_payment_success : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    string order = "";
    string order_id;
    string s;
    string t;
    string[] a = new string[6];

    protected void Page_Load(object sender, EventArgs e)
    {
        connection.Open();
        //get the order number
        order = Request.QueryString["order"].ToString();

        if (order == Session["order_no"].ToString())
        {
            //retrieving user details and store it in a table
            SqlCommand cmd = new SqlCommand("SELECT * from registration WHERE email = '" + Session["user"].ToString() + "' ", connection);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dA = new SqlDataAdapter(cmd);
            dA.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            { //storing user details in the new data table
                SqlCommand cmd1 = new SqlCommand("INSERT into ORDERS VALUES('" + dr["firstname"].ToString() + "','" + dr["lastname"].ToString() + "','" + dr["email"].ToString() + "','" + dr["address"].ToString() + "','" + dr["city"].ToString() + "','" + dr["state"].ToString() + "','" + dr["postal"].ToString() + "','" + dr["mobile"].ToString() + "')", connection);
                cmd1.ExecuteNonQuery();
            }

            //get the "ID" of the order from the orders table
            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from orders where email='" + Session["user"].ToString() + "' order by id desc";
            cmd2.ExecuteNonQuery(); //top1 means only one record
            DataTable dt2 = new DataTable();
            SqlDataAdapter dA2 = new SqlDataAdapter(cmd2);
            dA2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                order_id = dr2["id"].ToString();
            }

            //Retrieved the ordered items from the cookies

            if (Request.Cookies["aa"] != null)
            {
                s = Convert.ToString(Request.Cookies["aa"].Value); //store cookie values in s
                string[] strArr = s.Split('|');//split1

                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split(',');//split2

                    for (int j = 0; j < strArr1.Length; j++)
                    {
                        a[j] = strArr1[j].ToString();
                    }
                    SqlCommand cmd3 = new SqlCommand("INSERT INTO order_details VALUES('" + order_id.ToString() + "','" + a[0].ToString() + "','" + a[2].ToString() + "','" + a[3].ToString() + "','" + a[4].ToString() + "')", connection);
                    cmd3.ExecuteNonQuery();
                }
            }
                
        }

        else
        {
            Response.Redirect("webform.aspx");
        }

        connection.Close();

        Session["user"] = "";//clear the session variable

        //delete cookies (2 times just to make sure)
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);

        Response.Redirect("display_item.aspx");
    }
}