using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_update_order_details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["user"] == null)
        {//redirect to the login page
            Response.Redirect("webform.aspx");
        }

        if (IsPostBack)
        {
            return;
        }

        con.Open();
        //retrieve the email of current user from LoginPage using Session["Users"]
        SqlCommand command = new SqlCommand("SELECT * from registration WHERE email='" + Session["user"].ToString() + "' ", con);
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {//from the database
            tbxFirstName.Text = dr["firstname"].ToString();
            tbxLastname.Text = dr["lastname"].ToString();
            tbxAddress.Text = dr["address"].ToString();
            tbxCity.Text = dr["city"].ToString();
            tbxState.Text = dr["state"].ToString();
            tbxMobile.Text = dr["mobile"].ToString();
        }
        con.Close();        
    }

    protected void b1_Click(object sender, EventArgs e)
    { 
          
            con.Open();
            //retrieve current user infos
            SqlCommand command = new SqlCommand("UPDATE registration SET firstname=@firstname,lastname=@lastname,address=@address,city=@city,state=@state,mobile=@mobile WHERE email='" + Session["user"].ToString() + "' ", con);
        command.Parameters.Add("@firstname", tbxFirstName.Text);
            command.Parameters.Add("@lastname", tbxLastname.Text);
            command.Parameters.Add("@address", tbxAddress.Text);
            command.Parameters.Add("@city", tbxCity.Text);
            command.Parameters.Add("@state", tbxState.Text);
            command.Parameters.Add("@mobile", tbxMobile.Text);
            command.ExecuteNonQuery();
            con.Close();
        
       
       Response.Redirect("payment.aspx");
    }
}