<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="update_order_details.aspx.cs" Inherits="User_update_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>first name</td>   
            <td>
                <asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox></td>  
        </tr>
          <tr>
            <td>lastname</td>   
            <td>
                <asp:TextBox ID="tbxLastname" runat="server"></asp:TextBox></td>  
        </tr>
          <tr>
            <td>address</td>   
            <td>
                <asp:TextBox ID="tbxAddress" runat="server" Height="66px" TextMode="MultiLine" Width="192px"></asp:TextBox></td>  
        </tr>
          <tr>
            <td>city</td>   
            <td>
                <asp:TextBox ID="tbxCity" runat="server"></asp:TextBox></td>  
        </tr>
          <tr>
            <td>state</td>   
            <td>
                <asp:TextBox ID="tbxState" runat="server"></asp:TextBox></td>  
        </tr>
          <tr>
            <td>mobile</td>   
            <td>
                <asp:TextBox ID="tbxMobile" runat="server"></asp:TextBox></td>  
        </tr>
          <tr>    
            <td colspan="3" align="center">
                <asp:Button ID="btnUpdate" runat="server" Text="Update & Continue" OnClick="b1_Click" />
            </td>  
        </tr>
    </table>
</asp:Content>

