<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="EditManuScript.aspx.cs" Inherits="whut.stuplaza.UI.EditManuScript"  ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <!--旧版文本编辑器
    <script src="bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script src="bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
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
    padding:0 2px;
	color: #fff;
    font-size:14px;
    border-radius:6px;
	-moz-border-radius: 6px;
	-webkit-border-radius: 6px;
    -o-border-radius:6px;
	cursor: pointer;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
<span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ReviewManuManager.aspx">稿件管理</a></span><span><</span><span><a href="#">稿件编辑</a></span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH1" runat="server">
     <form id="form1" runat="server" style="padding:30px 0 0 60px">
         <asp:Label ID="txt_Lab" runat="server" Text="" Visible="false"></asp:Label>
                <p>稿件标题:<asp:TextBox ID="txt_Tiltle" runat="server"></asp:TextBox></p>
         <p>稿件作者姓名:<asp:TextBox ID="txt_Author" runat="server" ReadOnly="true"  BackColor="#cccccc"></asp:TextBox></p>
         
                <div>稿件内容：</div>
         <asp:TextBox ID="txtcontent" ClientIDMode="Static" runat="server" TextMode="MultiLine" Width="80%" Height="350px"></asp:TextBox>
         <asp:Button ID="txtSub" runat="server" Text="修改" OnClick="txtSub_Click" CssClass="stu_btn"/>
         <!--实例化编辑器-->
         <script type="text/javascript">
             var ue = UE.getEditor('txtcontent');
         </script>
         </form>
</asp:Content>
