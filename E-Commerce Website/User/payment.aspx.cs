using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_payment : System.Web.UI.Page
{
    int total = 0;
    string s;
    string t;
    string[] a = new string[6];
    string order_no;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null)
        {//redirect to the login page
            Response.Redirect("webform.aspx");
        }

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
                total = total + (Convert.ToInt32(a[2].ToString()) * Convert.ToInt32(a[3].ToString()));
                           
            }
            Session["total"] = total.ToString(); //the total amount will be passsed to checkout

        }
        //Paypal 

        order_no = Class1.GetRandomPassword(10).ToString();
        Session["order_no"] = order_no.ToString();

        Response.Write("<form action='https://www.sandbox.paypal.com/cgi-bin/webscr' method ='post' name='buyCredits' id='buyCredits'>");
        Response.Write("<input type='hidden' name='cmd' value='_xclick'>");
        //receive money address (owner)
        Response.Write("<input type='hidden' name='business' value='wymowaiyan96@gmail.com'>");
        //currency
        Response.Write("<input type='hidden' name='currency_code' value='USD'>");
        //description 
        Response.Write("<input type='hidden' name='item_name' value='payment for purchase'>");
        //item Number                                                                                                                                                                      //item Number
        Response.Write("<input type='hidden' name='item_number' value='0'>");
        //amount to pay
        Response.Write("<input type='hidden' name='amount' value='" + Session["total"].ToString() + "'>");
        //return after completing payment <VIEW CODE>
        //this order no value will be passed
        Response.Write("<input type='hidden' name='return' value='http://localhost:59404/User/payment_success.aspx?order=" + order_no.ToString() + "'>");
        Response.Write("</form>");

        Response.Write("<script type='text/javascript'>");
        Response.Write("document.getElementById('buyCredits').submit();");
        Response.Write("</script>");

    }
}