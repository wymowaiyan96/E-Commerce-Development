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
    string[] a = new string[6];
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //all the values from the cookies will be stored in this data table
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_images"), new DataColumn("id") });

        //currently data is a,b,c,d,e | a,b,c,d,e
        //need to split two times (| & ,)
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
                dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(),i.ToString());
            }

        }
        d1.DataSource = dt;
        d1.DataBind();
    }

    
}