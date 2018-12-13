<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="Admin_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
  <h3>Add Product Page</h3>
    
      <table>
        <tr>
            <td>Product Name</td>
            <td><asp:TextBox ID="t1" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>Product Desription</td>
            <td><asp:TextBox ID="t2" runat="server"></asp:TextBox></td>
        </tr>

             <tr>
            <td>Product Price</td>
            <td><asp:TextBox ID="t3" runat="server"></asp:TextBox></td>
        </tr>

           <tr>
            <td>Product Qty</td>
            <td><asp:TextBox ID="t4" runat="server"></asp:TextBox></td>
        </tr>

             <tr>
            <td>Product Name</td>
            <td><asp:FileUpload ID="f1" runat="server" /></td>
        </tr>

             <tr>
            <td colspan="2" align="center>">
                <asp:Button ID="b1" runat="server" Text="Upload" OnClick="b1_Click" />
            </td>
            
        </tr>_
    </table>
</asp:Content>

