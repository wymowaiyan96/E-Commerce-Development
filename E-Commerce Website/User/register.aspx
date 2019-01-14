<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="User_register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">

        <h3 style="text-align:center">New User Registration</h3> <br /><br />
  
   <table align="center">
        <tr>
            <td>firstname</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>lastname</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxLastName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>email</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>password</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td>address</td>
            <td>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbxAddress" runat="server" Height="67px" TextMode="MultiLine" Width="139px"></asp:TextBox></td>
        </tr>
         <tr>
            <td>city</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxCity" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>state</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxState" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>postal</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxPostal" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>phone</td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="tbxPhone" runat="server"></asp:TextBox></td>
        </tr>

       <tr><td></td></tr>
         <tr>          
            <td colspan ="2" align="center">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </td>
            <td colspan ="2" align="center">
                <asp:Label ID="l1" runat="server" ></asp:Label>
            </td>           
        </tr>
    </table>
  </div>
</asp:Content>

