using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_User : System.Web.UI.MasterPage
{
    string s;
    string t;
    string[] a = new string[6];
    int total = 0;
    int totCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");

        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * from category", connection);
        command.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter dA = new SqlDataAdapter(command);
        dA.Fill(dt);
        dd.DataSource = dt;
        dd.DataBind();
        connection.Close();

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
                //added to the new Rows in the dataTable                
                total = total + (Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));
                totCount = totCount + 1;
                totItem.Text = totCount.ToString();
                totPrice.Text = total.ToString();
            }

        }
    }
}
