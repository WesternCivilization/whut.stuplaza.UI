<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="EditSysAdmin.aspx.cs" Inherits="whut.stuplaza.UI.EditSysAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
    <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowUser.aspx">用户管理</a></span><span><</span><span><a href="#">用户编辑</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
     <form id="form1" runat="server">
      <div>
           <p> <asp:Label ID="lbl_Id" runat="server" Text="管理员Id"></asp:Label>
             <asp:TextBox ID="txt_Id" runat="server" ReadOnly="true" ForeColor="#ccccff"></asp:TextBox>
            </p>
          <p> <asp:Label ID="lbl_Pwd" runat="server" Text="管理员密码"></asp:Label>
             <asp:TextBox ID="txt_Pwd" runat="server"></asp:TextBox>
          </p>
          <p> <asp:Label ID="lbl_Name" runat="server" Text="管理员姓名"></asp:Label>
             <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
          </p>
          <p><asp:Label ID="lbl_Tel" runat="server" Text="管理员电话"></asp:Label>
               <asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>
          </p>
           <p><asp:Label ID="lbl_Email" runat="server" Text="管理员邮箱"></asp:Label>
               <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
          </p>
              <p>
                  <asp:Button ID="btn_Update" runat="server" Text="保存更改" OnClick="btn_Update_Click" />

              </p>
             </div> 
    </form>
</asp:Content>
