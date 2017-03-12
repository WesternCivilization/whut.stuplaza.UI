<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="EditColumn.aspx.cs"  validateRequest="false" Inherits="whut.stuplaza.UI.EditColumn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />
     <script src="frontUI/frontjs/jquery-1.7.min.js"></script>

     <!--旧版文本编辑器
    <script src="bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script src="bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
    -->
    <!--引入Ueditor配置文件  -->
    <script type="text/javascript" src="plugin/Ueditor/ueditor.config.js"></script>
    <!--引入Ueditor编辑器-->
    <script type="text/javascript" src="plugin/Ueditor/ueditor.all.min.js"></script>


    <style>
        #form1 div p {
            margin-bottom: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
  <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowColumn.aspx">栏目管理</a></span><span><</span><span><a href="#">栏目编辑</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
     <form id="form1" runat="server" style="padding:30px 0 0 60px">
      <div>
           <p> <asp:Label ID="lbl_Id" runat="server" Text="栏目Id"  ></asp:Label>
             <asp:TextBox ID="txt_Id" runat="server" ReadOnly="true"  BackColor="#cccccc"></asp:TextBox>
            </p>
          <p> <asp:Label ID="lbl_Name" runat="server" Text="栏目名称"></asp:Label>
             <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
          </p>
          <div><p><asp:Label ID="lbl_ColumnContent" runat="server" Text="栏目摘要"></asp:Label>
               <asp:TextBox ID="txt_ColumnContent" runat="server" TextMode="MultiLine" Width="80%" Height="350px" ClientIDMode="Static"></asp:TextBox>
                 <!--实例化编辑器-->
                <script type="text/javascript">
                    var ue = UE.getEditor('txt_ColumnContent');
                </script>
          
          </p></div>
          <div>
              <p>
                  <asp:Button ID="btn_Update" runat="server" Text="保存更改" CssClass="stu_btn"  OnClick ="btn_Update_Click" /></p>
              </div>
             </div> 
    </form>
</asp:Content>
