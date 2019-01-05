using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_add_product : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    string a,b;
    

    protected void Page_Load(object sender, EventArgs e)
    {
       if ( Session["admin"] == null)
        {
            Response.Redirect("adminLogin.aspx");
        }

        if (IsPostBack) return;

        dd.Items.Clear(); //ckear drop down
        connection.Open();
        SqlCommand command =new SqlCommand("Select * from category", connection);
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        { //display category in dropdown 
            dd.Items.Add(dr["product_category"].ToString());
        }
        connection.Close();
    }

    protected void b1_Click(object sender, EventArgs e)
    { //addImages into the database
        a = Class1.GetRandomPassword(10).ToString();  //for image name to b diff (download from the class <tutorial>)
        f1.SaveAs(Request.PhysicalApplicationPath + "./Images/" + a + f1.FileName.ToString());
        b = "Images/" + a + f1.FileName.ToString();
        //storing in database
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "INSERT INTO product VALUES ('"+t1.Text+"','"+t2.Text+"',"+t3.Text+","+t4.Text+",'"+b.ToString()+ "','" + dd.SelectedItem.ToString()+"')";
        command.ExecuteNonQuery();
        connection.Close();

        l1.Text = t1.Text + " has been added!";
        
        t1.Text = "";
        t2.Text = "";
        t3.Text = "";
        t4.Text = "";
       
    }
}

