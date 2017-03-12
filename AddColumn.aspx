<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="AddColumn.aspx.cs" Inherits="whut.stuplaza.UI.AddColumn" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="frontUI/frontjs/jquery-1.7.min.js"></script>

    <!--旧版文本编辑器
    <script type="text/javascript" src="bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script type="text/javascript" src="bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
    -->
<!--引入Ueditor配置文件  -->
<script type="text/javascript" src="plugin/Ueditor/ueditor.config.js"></script>
<!--引入Ueditor编辑器-->
<script type="text/javascript" src="plugin/Ueditor/ueditor.all.min.js"></script>




     <style type="text/css">
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
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
   <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowColumn.aspx">栏目展示</a></span><span><</span><span><a href="#">添加栏目</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
     <form id="form1" runat="server" style="padding:30px 0 0 60px;">
    <div>
        新建栏目名称：<asp:TextBox ID="colName" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        <br/>
        <asp:Label ID="lbl_column" runat="server" Text="选择新建栏目位置："></asp:Label>
             <asp:DropDownList ID="column1" runat="server" OnSelectedIndexChanged="column1_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="00000000">未分栏</asp:ListItem>
            <asp:ListItem Value="01000000">部门介绍</asp:ListItem>
            <asp:ListItem Value="02000000">思想教育</asp:ListItem>
            <asp:ListItem Value="03000000">学生管理</asp:ListItem>
            <asp:ListItem Value="04000000">学生资助</asp:ListItem>
            <asp:ListItem Value="05000000">学生园区</asp:ListItem>
            <asp:ListItem Value="06000000">队伍建设</asp:ListItem>
            <asp:ListItem Value="07000000">心理健康</asp:ListItem>
            <asp:ListItem Value="08000000">招生工作</asp:ListItem>
            <asp:ListItem Value="09000000">就业创业</asp:ListItem>
            <asp:ListItem Value="10000000">国防教育</asp:ListItem>
            <asp:ListItem Value="11000000">理工青年</asp:ListItem>
            <asp:ListItem Value="12000000">信息公开</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="column2" runat="server" Visible="false" OnSelectedIndexChanged="column2_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>新建分栏</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="column3" runat="server" Visible="false" OnSelectedIndexChanged="column3_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>新建分栏</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="column4" runat="server" Visible="false" AutoPostBack="true">
            <asp:ListItem>新建分栏</asp:ListItem>
        </asp:DropDownList>
        <br/>
        新建栏目的类型:<asp:RadioButton ID="colDynamic" runat="server"  GroupName="status" Text="动态内容"/>

        <asp:RadioButton ID="colStatus" runat="server"  GroupName="status" Text="静态内容"/>
        <br/>
        <p style="color:red">动态：该栏目下有多篇文章</p>
        <p style="color:red">静态：该栏目下只有一篇文章，并填写在下方编辑区域内</p>
        <asp:TextBox ID="colContent" runat="server" TextMode="MultiLine" Width="80%" Height="350px" ClientIDMode="Static"></asp:TextBox>
        <!--实例化编辑器-->    
        <script type="text/javascript">
                var ue = UE.getEditor('colContent');
            </script>
            
        <br/>
   
        <asp:Button ID="txtBtn" runat="server" CssClass="stu_btn" Text="提交" OnClick="txtBtn_Click" />
    </div>
    </form>
</asp:Content>
