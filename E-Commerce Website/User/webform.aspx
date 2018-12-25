<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="webform.aspx.cs" Inherits="User_webform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>Enter Email</td>
            <td><asp:TextBox ID="tb1" runat="server"></asp:TextBox></td>
        </tr>
          <tr>
            <td>Enter Password</td>
            <td><asp:TextBox ID="tb2" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
       
         <tr>       
            <td colspan="2" align="center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </td>
        </tr>

          <tr>       
            <td colspan="2" align="center">
                <asp:Label ID="l1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

