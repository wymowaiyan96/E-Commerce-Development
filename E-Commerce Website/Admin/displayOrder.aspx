<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="displayOrder.aspx.cs" Inherits="Admin_displayOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray;color:white">
                    <th>id</th>
                    <th>firstname</th>
                     <th>lastname</th>
                     <th>city</th>
                     <th>state</th>
                     <th>postal</th>
                    <td>View Order</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("id")%></td>
                <td><%#Eval("firstname")%></td>
                <td><%#Eval("lastname")%></td>
                <td><%#Eval("city")%></td>
                <td><%#Eval("state")%></td>
                <td><%#Eval("postal")%></td> 
                <td><a href="viewOrder.aspx?id=<%#Eval("id")%>">View Order</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>

