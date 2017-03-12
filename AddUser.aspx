<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="whut.stuplaza.UI.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="frontUI/frontjs/jquery-1.11.3.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
    <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowUser.aspx">用户管理</a></span><span><</span><span><a href="#">添加用户</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
      <div>
           <p><asp:Label ID="lbl_Pwd" runat="server" Text="登录密码"></asp:Label>
               <asp:TextBox ID="txt_Pwd" runat="server"></asp:TextBox><asp:Label ID="error" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
          </p>
          <p><asp:Label ID="lbl_UserName" runat="server" Text="用户姓名"></asp:Label>
               <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="(提示：此处姓名不作为系统登录用户名，添加完后进入用户管理界面可找到该用户！)"></asp:Label>
          </p>
          <p><asp:Label ID="lbl_Category" runat="server" Text="用户类别"></asp:Label>
              <asp:DropDownList ID="ddl_Category" runat="server">
               <asp:ListItem Selected="True" Value="03">系统管理员</asp:ListItem>
               <asp:ListItem Value="02">稿件审核员</asp:ListItem>
               <asp:ListItem Value="00">超级发布员</asp:ListItem>
               <asp:ListItem Value="01">普通发布员</asp:ListItem>
              </asp:DropDownList>
             </p>
          <p>
              <asp:Label ID="lbl_Sector" runat="server" Text="所属部门"></asp:Label>
              <asp:DropDownList ID="ddl_Sector" runat="server">
                  <asp:ListItem Selected="True" Value="学生教育办公室(学生)">学生教育办公室(学生)</asp:ListItem>
               <asp:ListItem Value="学生管理办公室(日常)">学生管理办公室(日常)</asp:ListItem>
               <asp:ListItem Value="学生资助与服务中心(资助)">学生资助与服务中心(资助)</asp:ListItem>
               <asp:ListItem Value="学生资助与服务中心(住宿、勤工助学)">学生资助与服务中心(住宿、勤工助学)</asp:ListItem>
               <asp:ListItem Value="学生教育办公室(辅导员)">学生教育办公室(辅导员)</asp:ListItem>
               <asp:ListItem Value="心理健康教育中心">心理健康教育中心</asp:ListItem>
               <asp:ListItem Value="招生办公室">招生办公室</asp:ListItem>
               <asp:ListItem Value="学生管理办公室(就业)">学生管理办公室(就业)</asp:ListItem>
               <asp:ListItem Value="武装部">武装部</asp:ListItem>
               <asp:ListItem Value="团委">团委</asp:ListItem>
              </asp:DropDownList>
              <asp:Label ID="lbl_Tell" runat="server" ForeColor="Red"  Text="(提示：当只有添加普通信息发布员时，才可选择所属部门！)"></asp:Label>
          </p>
           <p><asp:Label ID="lbl_Tel" runat="server" Text="用户电话"></asp:Label>
               <asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>
          </p>
           <p><asp:Label ID="lbl_Email" runat="server" Text="用户邮箱"></asp:Label>
               <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
          </p>
            <p>
                <asp:Button ID="btn_Insert" runat="server" Text="提交" OnClick="btn_Insert_Click" /></p>
        </div>
        </form>
    
</asp:Content>
