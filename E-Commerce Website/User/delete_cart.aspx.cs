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
    string s;
    string t;
    string[] a = new string[5];
    int id;
    int count = 0;
    string product_name, product_desc, product_price, product_qty, product_images;

    protected void Page_Load(object sender, EventArgs e)
    {
        //retrive the id (from URL) that is paassed previously
        id = Convert.ToInt32(Request.QueryString["id"].ToString());

        DataTable dt = new DataTable();
        dt.Rows.Clear();
        //create new columns
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_images"), new DataColumn("id") });

      
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
                dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(),i.ToString());
            }
        }
        
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
            count = count + 1;

            if (count ==1)
            {
                Response.Cookies["aa"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1); //expire after one day
            }
            else
            {//if there is cookie previously, add new cookie into it <special symbol |> to split --> old cookie | new cookie
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + '|' + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }
        
        }
        Response.Redirect("view_cart.aspx");
    }
}