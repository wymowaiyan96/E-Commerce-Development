<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="addCategory.aspx.cs" Inherits="Admin_addCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>Category</td>
            <td>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="b1" runat="server" Text="Add" /></td>
        </tr>
    </table>
    <br />
    <asp:Label ID="l1" runat="server" Text=""></asp:Label>
</asp:Content>

