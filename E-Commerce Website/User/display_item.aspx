﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="display_item.aspx.cs" Inherits="User_display_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
              <ul>
        </HeaderTemplate>
        <ItemTemplate> <%--/*id is passed here */--%>
             <li class="last"> <a href="product_desc.aspx?id=<%#Eval("id") %>"><img src="../<%#Eval("product_images") %>" style="text-align:center; margin-left:30px; margin-top:30px" alt="" /></a>
            <div class="product-info">
              <h3><%#Eval("product_name") %></h3>
              <div class="product-desc">
                <h4>Available Qty <%#Eval("product_qty") %></h4>
                <p><%#Eval("product_desc") %></p>
                <strong class="price">$<%#Eval("product_price") %></strong> </div>
            </div>
          </li>
        
                 
        </ItemTemplate>
        <FooterTemplate>
             </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

