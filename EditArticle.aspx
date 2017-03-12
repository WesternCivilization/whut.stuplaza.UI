<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="whut.stuplaza.UI.EditArticle" validateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <!--旧版文本编辑器
    <script type="text/javascript" src="../bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script type="text/javascript" src="../bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
    -->
<!--引入Ueditor配置文件  -->
<script type="text/javascript" src="plugin/Ueditor/ueditor.config.js"></script>
<!--引入Ueditor编辑器-->
<script type="text/javascript" src="plugin/Ueditor/ueditor.all.min.js"></script>


    <style>
        .stu_btn{
	background: #82b440;
    width:auto;
    height:auto;
    padding:5px 30px;
	color: #fff;
    font-size:14px;
    border-radius:6px;
	-moz-border-radius: 6px;
	-webkit-border-radius: 6px;
    -o-border-radius:6px;
	cursor: pointer;
}
        #form1 p {
            margin-bottom:15px;
        }
        #form1 input {
            margin-right:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
  <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowArticle.aspx">文章管理</a></span><span><</span><span><a href="#">文章编辑</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server" style="padding:30px 0 0 60px">
    <div>
        <p>
            文章编号：<input type="text" name="column" value="<%=model.ArticleId %>" disabled="disabled" />
            文章发布人：<input type="text" name="poststaff" value="<%=model.ArticlePostStaff %>" disabled="disabled" />
            文章所属栏目：<input type="text" name="column" value="<%=model.ArticleColumn %>" disabled="disabled" />
        </p>
        <p>
            文章标题：<input type="text" name="title" value="<%=model.ArticleTitle %>" />
            文章所属专题：<select id="select1" name="select1"><%=topicBind %></select>
        </p>
        <p>
            文章内容:
            <textarea id="txtcontent" name="txtcontent" style="width:80%;height:350px"><%=model.ArticleContent %></textarea>
             <!--实例化编辑器-->
            <script type="text/javascript">
                var ue = UE.getEditor('txtcontent');
            </script>
        
        </p>
        <p>
            <asp:Button ID="btn" runat="server" Text="修改" OnClick="btn_Click" CssClass="stu_btn"/>
        </p>
    </div>
    </form>
</asp:Content>
