<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ShowFile.aspx.cs" Inherits="whut.stuplaza.UI.ShowFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
  <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">文件展示</a></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form runat="server" id="form1">
     <asp:Repeater ID="fileList" runat="server" OnItemCommand="fileList_ItemCommand">
            <HeaderTemplate>
                <table class="tb_content" id="tbody"><tr class="tb_tr"><th style="width:10%;">文件Id</th><th style="width:15%;">文件描述标题</th><th style="width:17%;">文件名称</th><th style="width:10%;">文件扩展名</th><th style="width:10%;">文件下载次数</th><th style="width:10%;">文件上传时间</th><th style="width:10%;">文件上传部门</th><th style="width:8%;">操作</th></tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("FileId") %></td>
                    <td><%#Eval("FileSummary") %></td>
                    <td><%#Eval("FileName")%></td>
                    <td><%#Eval("FileExt")%></td>
                    <td><%#Eval("FileDowNum") %></td>
                    <td><%#Eval("FileTime") %></td>
                    <td><%#Eval("FileSector") %></td>
                    <td><asp:Button ID="btnDelete" CssClass="stu_btn" OnClientClick="return confirm('确定删除')" CommandArgument='<%# Eval("FileId") %>' CommandName="Delete" runat="server" Text="删除"></asp:Button></td>
               </tr>
          </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
          <div id="navDiv" class="paginator">
            <asp:Literal ID="NavStrHtml" runat="server"></asp:Literal>
           </div>
           <div class="bgDiv" style="display:none;">
           </div>
    </form>
</asp:Content>
