<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ShowColumn.aspx.cs" Inherits="whut.stuplaza.UI.ShowColumns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
 <span><a href="default.aspx">首页</a></span><span><</span><span><a href="#">栏目管理</a></span> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
     <form runat="server" id="form1" style="padding:30px 0 0 60px;">
         <asp:DropDownList ID="ddl_Column" runat="server" OnSelectedIndexChanged="ddl_Column_SelectedIndexChanged" AutoPostBack="true">
               <asp:ListItem Selected="True" Value="01">部门介绍</asp:ListItem>
               <asp:ListItem  Value="02">思想教育</asp:ListItem>
               <asp:ListItem Value="03">学生管理</asp:ListItem>
               <asp:ListItem Value="04">学生资助</asp:ListItem>
               <asp:ListItem Value="05">学生园区</asp:ListItem>
               <asp:ListItem Value="06">队伍建设</asp:ListItem>
               <asp:ListItem Value="07">心理健康</asp:ListItem>
               <asp:ListItem Value="08">招生工作</asp:ListItem>
               <asp:ListItem Value="09">就业创业</asp:ListItem>
               <asp:ListItem Value="10">国防教育</asp:ListItem>
               <asp:ListItem Value="11">理工青年</asp:ListItem>
               <asp:ListItem Value="12">信息公开</asp:ListItem>
         </asp:DropDownList>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate><table id="tbody"><tr><th style="width:20%;">栏目ID</th><th style="width:20%;">栏目名称</th><th style="width:20%;">栏目类型</th><th style="width:20%;">栏目级别</th><th style="width:20%;">操作</th></tr></HeaderTemplate>
            <ItemTemplate>
                <tr><td><%#Eval("ColumnId") %></td><td><%#Eval("ColumnName") %></td><td><%#Eval("ColumnStatus").ToString()=="1"?"文章列表":"静态文本内容" %></td><td><%#GetGrade(Eval("ColumnId")) %></td>
                     <td><asp:Button ID="btn_Delete" CssClass="stu_btn"  runat="server" Text="删除"   CommandArgument='<%# Eval("ColumnId") %>' CommandName="Delete"></asp:Button>
                         <asp:Button ID="btn_Edit" CssClass="stu_btn"  runat="server" Text="修改" CommandArgument='<%# Eval("ColumnId") %>' CommandName="Update" ></asp:Button>
                     </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
       
    </form>

</asp:Content>
