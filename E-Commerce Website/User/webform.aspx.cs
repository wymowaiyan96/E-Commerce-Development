﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class User_webform : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    int total;
    int id;
   

    protected void Page_Load(object sender, EventArgs e)
    {

      
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
       
        con.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM registration WHERE email='" + tb1.Text + "' and password= '" + tb2.Text + "'", con);
        command.ExecuteNonQuery();       
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        total = Convert.ToInt32(dt.Rows.Count.ToString());
    

        if (total > 0)
        {
            if (Session["checkoutbutton"] == "yes") //user come from the checkout page
            {
                Session["User"] = tb1.Text; //storing the email of current login user
                Response.Redirect("update_order_details.aspx");
            }
            else
            {
                Session["User"] = tb1.Text;
                Response.Redirect("order_details.aspx");
            }      
        }
        else
        {
            l1.Text = "Invalid Username or Password";
        }

        con.Close();
    }
}