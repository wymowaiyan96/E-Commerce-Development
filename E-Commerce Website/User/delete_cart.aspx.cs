using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_delete_cart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Coding\ASP.Net\Web Development\E-Commerce-Development\E-Commerce Website\App_Data\shop.mdf;Integrated Security = True");
    string s;
    string t;
    string[] a = new string[6];
    int id;
    int count = 0;
    int product_id, qty;
    string product_name, product_desc, product_price, product_qty, product_images;

    protected void Page_Load(object sender, EventArgs e)
    {
        //retrive the id (from URL) that is paassed previously
        id = Convert.ToInt32(Request.QueryString["id"].ToString());

        DataTable dt = new DataTable();
        dt.Rows.Clear();
        //create new columns
        dt.Columns.AddRange(new DataColumn[7] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_images"), new DataColumn("id"), new DataColumn("product_id") });

      
        if (Request.Cookies["aa"] != null)
        {
            s = Convert.ToString(Request.Cookies["aa"].Value); //store cooking values in s
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
                dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(),i.ToString(), a[5   ].ToString());
            }
        }

        count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (count ==1) //position of cookies (
            {
                product_id = Convert.ToInt32(dr["product_id"].ToString());
                qty = Convert.ToInt32(dr["product_qty"].ToString());
            }
            count = count + 1;
        }
        count = 0;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE product SET product_qty=product_qty+" + qty + "WHERE id=" + product_id;
        cmd.ExecuteNonQuery();
        con.Close();

        //delete the value that is passed (through cookie then stored in datatable)
        dt.Rows.RemoveAt(id);

        //delete cookies (2 times just to make sure)
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);

        //new cookies are created again after deleting the old cookies
        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_desc = dr["product_desc"].ToString();
            product_price = dr["product_price"].ToString();
            product_qty = dr["product_qty"].ToString();
            product_images = dr["product_images"].ToString();
            product_id = Convert.ToInt32(dr["product_id"].ToString());
            count = count + 1;

            if (count ==1)
            {
                Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString() + "," + product_id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1); //expire after one day
            }
            else
            {//if there is cookie previously, add new cookie into it <special symbol |> to split --> old cookie | new cookie
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + '|' + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString() + "," + product_id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }
        
        }
        Response.Redirect("view_cart.aspx");
    }
}