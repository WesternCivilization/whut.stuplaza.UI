<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ShowTopic.aspx.cs" Inherits="whut.stuplaza.UI.ShowTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />--%>
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
    <style type="text/css">
        #form1 {
            margin-left: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
  <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">专题管理</a></span>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
   <form runat="server" id="form1">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate><table id="tbody"><tr><th style="width:10%;">专题ID</th><th style="width:15%;">专题标题</th><th style="width:15%;">专题添加时间</th><th style="width:10%;">专题优先级</th><th style="width:20%;">专题摘要</th><th style="width:15%;">图片路径</th><th style="width:15%;">操作</th></tr></HeaderTemplate>
            <ItemTemplate>
                <tr><td><%#Eval("TopicId") %></td><td><%#Eval("TopicTitle") %></td><td><%#Eval("TopicTime") %></td><td><%#Eval("TopicPriority") %></td><td><%#Eval("TopicSummary") %></td><td><%#Eval("TopicFileName") %></td>
                     <td><asp:Button ID="btn_Delete" runat="server" Text="删除"   CommandArgument='<%# Eval("TopicId") %>' CommandName="Delete" CssClass="stu_btn"></asp:Button>
                         <asp:Button ID="btn_Edit" runat="server" Text="修改" CommandArgument='<%# Eval("TopicId") %>' CommandName="Update" CssClass="stu_btn"></asp:Button>
                     </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
       
    </form>
</asp:Content>
