using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_view_cart : System.Web.UI.Page
{
    string s;
    string t;
    string[] a = new string[5];
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //create new columns
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_images")});

        //currently data is a,b,c,d,e | a,b,c,d,e
        //need to split two times (| & ,)
        if (Request.Cookies["aa"] != null)
        {
           // Label.Text = Convert.ToString(Request.Cookies["aa"].Value);
            s = Convert.ToString(Request.Cookies["aa"].Value);
            string[] strArr = s.Split('|');//split1

            for (int i=0;i<strArr.Length;i++)
            {
                t = Convert.ToString(strArr[i].ToString());
                string[] strArr1 = t.Split(',');//split2

                for (int j = 0; j < strArr1.Length; j++)
                {
                    a[j] = strArr1[j].ToString();
                }


                //added to the new Rows in the dataTable
                dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString());
            }

        }
            d1.DataSource = dt;
            d1.DataBind();
    }
}