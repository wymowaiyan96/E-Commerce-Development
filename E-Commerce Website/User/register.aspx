<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="User_register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>firstname</td>
            <td><asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>lastname</td>
            <td><asp:TextBox ID="tbxLastName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>email</td>
            <td><asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>password</td>
            <td><asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td>address</td>
            <td><asp:TextBox ID="tbxAddress" runat="server" Height="67px" TextMode="MultiLine" Width="139px"></asp:TextBox></td>
        </tr>
         <tr>
            <td>city</td>
            <td><asp:TextBox ID="tbxCity" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>state</td>
            <td><asp:TextBox ID="tbxState" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>postal</td>
            <td><asp:TextBox ID="tbxPostal" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>phone</td>
            <td><asp:TextBox ID="tbxPhone" runat="server"></asp:TextBox></td>
        </tr>
         <tr>          
            <td colspan ="2" align="center">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </td>
            <td colspan ="2" align="center">
                <asp:Label ID="l1" runat="server" ></asp:Label>
            </td>           
        </tr>

    </table>
</asp:Content>

