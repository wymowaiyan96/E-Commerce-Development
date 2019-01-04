<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="view_Order.aspx.cs" Inherits="User_view_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
 <asp:Repeater ID="r2" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray;color:white">
                    <th>id</th>
                    <th>firstname</th>
                     <th>lastname</th>
                     <th>email</th>
                      <th>address</th>
                     <th>city</th>
                     <th>state</th>
                     <th>postal</th>
                    <th>mobile</th>
  
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id")%></td>
                <td><%#Eval("firstname")%></td>
                <td><%#Eval("lastname")%></td>
                    <td><%#Eval("email")%></td>
                    <td><%#Eval("address")%></td> 
                <td><%#Eval("city")%></td>
                <td><%#Eval("state")%></td>
                <td><%#Eval("postal")%></td> 
                    <td><%#Eval("mobile")%></td> 
          
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
<br/><br />

    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:grey;color:white;">
                    <td>product image</td>
                    <td>product name</td>
                    <td>product price</td>
                    <td>product qty</td>
                </tr>
  
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                 <td>
                     <img src="../<%#Eval("product_images") %>" height="100" width="100" />
                 </td>
                 <td><%#Eval("product_name") %></td>
                 <td><%#Eval("product_price") %></td>
                 <td><%#Eval("product_qty") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                      </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Label ID="l1" runat="server" Text=""></asp:Label>
</asp:Content>



