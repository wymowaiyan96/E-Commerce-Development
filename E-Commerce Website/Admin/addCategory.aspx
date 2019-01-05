<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="addCategory.aspx.cs" Inherits="Admin_addCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    
    <h4>Add Category</h4> <br />
 
    <table>
        <tr>
            <td>Enter Category</td>
            <td>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center"><asp:Button ID="b1" runat="server" Text="Add" OnClick="b1_Click" /></td>
        </tr>
    </table>

    <br /><br />

    <h4>Delete Category</h4>
  
    <asp:DataList ID="d1" runat="server">
        <HeaderTemplate>
            <table border="1"> 
                <tr style="background-color:silver;color:white">
                    <th>Category</th>
                    <th>Action</th>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("product_category") %></td>
                <td><a href="deleteCategory.aspx?category=<%#Eval("product_category")%>">Delete</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>
   
</asp:Content>

