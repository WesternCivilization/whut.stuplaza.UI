<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ShowUser.aspx.cs" Inherits="whut.stuplaza.UI.ShowUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
    <script type="text/javascript" src="bkgroundjs/jquery.idTabs.min.js"></script>
    <style>
        .usual {
            background: #181818;
            color: #111;
            padding: 15px 20px;
            width:100%;
            border: 1px solid #222;
            margin: 8px auto;
        }

        ul {
            display: block;
            list-style-type: disc;
            -webkit-margin-before: 1em;
            -webkit-margin-after: 1em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
            -webkit-padding-start: 40px;
            padding:0;
        }

        .usual div {
            padding: 10px 10px 8px 10px;
            clear: left;
            background: snow;
            font: 10pt Microsoft YaHei;
        }

        .usual li {
            list-style: none;
            float: left;
        }

        .usual ul a.selected {
            margin-bottom: 0;
            color: #000;
            background: snow;
            border-bottom: 1px solid snow;
            cursor: default;
        }

        .usual ul a {
            display: block;
            padding: 6px 10px;
            text-decoration: none!important;
            margin: 1px;
            margin-left: 0;
            font: 10px Microsoft YaHei;
            color: #FFF;
            background: #444;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
   <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">用户管理</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
     <form runat="server" id="form1">
         <%--<div>
             <p>系统管理员</p>
             <asp:Repeater ID="rpt_SysAdmin" runat="server" OnItemCommand="rpt_SysAdmin_ItemCommand">
                 <HeaderTemplate>
                     <table id="tbody">
                         <tr>
                             <th>管理员ID</th>
                             <th>管理员密码</th>
                             <th>管理员姓名</th>
                             <th>管理员电话</th>
                             <th>管理员邮箱</th>
                             <th>操作</th>
                         </tr>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <tr>
                         <td><%#Eval("SysAdminAccount") %></td>
                         <td><%#GetPwd(Eval("SysAdminPwd")) %></td>
                         <td><%#Eval("SysAdminName") %></td>
                         <td><%#Eval("SysAdminTel") %></td>
                         <td><%#Eval("SysAdminEmail") %></td>
                         <td>
                             <asp:Button ID="btn_EditSysAdmin" runat="server" Text="修改" CommandArgument='<%# Eval("SysAdminAccount") %>' CommandName="Update"></asp:Button>
                             <asp:Button ID="btn_DeletSysAdmin" runat="server" Text="删除" CommandArgument='<%# Eval("SysAdminAccount") %>' CommandName="Delete"></asp:Button>
                         </td>
                     </tr>
                 </ItemTemplate>
                 <FooterTemplate></table></FooterTemplate>
             </asp:Repeater>
         </div>
         <div>
             <p>信息发布人员表</p>
             <asp:Repeater ID="rpt_InfoAdmin" runat="server" OnItemCommand="rpt_InfoAdmin_ItemCommand">
                 <HeaderTemplate>
                     <table id="tbody">
                         <tr>
                             <th>发布员ID</th>
                             <th>发布员密码</th>
                             <th>所属部门</th>
                             <th>发布员级别</th>
                             <th>发布员姓名</th>
                             <th>发布员电话</th>
                             <th>发布员邮箱</th>
                             <th>操作</th>
                         </tr>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <tr>
                         <td><%#Eval("C_InfoAdminAccount") %></td>
                         <td><%#GetPwd(Eval("C_InfoAdminPwd")) %></td>
                         <td><%#Eval("C_InfoAdminSector") %></td>
                         <td><%#Eval("C_InfoAdminCategory").ToString()=="0"?"超级发布员":"普通发布员" %></td>
                         <td><%#Eval("C_InfoAdminName") %></td>
                         <td><%#Eval("C_InfoAdminTel") %></td>
                         <td><%#Eval("C_InfoAdminEmail") %></td>
                         <td>
                             <asp:Button ID="btn_EditInfoAdmin" runat="server" Text="修改" CommandArgument='<%# Eval("C_InfoAdminAccount") %>' CommandName="Update"></asp:Button>
                             <asp:Button ID="btn_DeletInfoAdmin" runat="server" Text="删除" CommandArgument='<%# Eval("C_InfoAdminAccount") %>' CommandName="Delete"></asp:Button>
                         </td>
                     </tr>
                 </ItemTemplate>
                 <FooterTemplate></table></FooterTemplate>
             </asp:Repeater>
         </div>
         <div>
             <p>稿件审核人员</p>
             <asp:Repeater ID="rpt_Reviewer" runat="server" OnItemCommand="rpt_Reviewer_ItemCommand">
                 <HeaderTemplate>
                     <table id="tbody">
                         <tr>
                             <th>审核员ID</th>
                             <th>审核员密码</th>
                             <th>审核员姓名</th>
                             <th>审核员电话</th>
                             <th>审核员邮箱</th>
                             <th>操作</th>
                         </tr>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <tr>
                         <td><%#Eval("C_ReviewerAccount") %></td>
                         <td><%#GetPwd(Eval("C_ReviewerPwd")) %></td>
                         <td><%#Eval("C_ReviewerName") %></td>
                         <td><%#Eval("C_ReviewerTel") %></td>
                         <td><%#Eval("C_ReviewerEmail") %></td>
                         <td>
                             <asp:Button ID="btn_EditReviewer" runat="server" Text="修改" CommandArgument='<%# Eval("C_ReviewerAccount") %>' CommandName="Update"></asp:Button>
                             <asp:Button ID="btn_DeletReviewer" runat="server" Text="删除" CommandArgument='<%# Eval("C_ReviewerAccount") %>' CommandName="Delete"></asp:Button>
                         </td>
                     </tr>
                 </ItemTemplate>
                 <FooterTemplate></table></FooterTemplate>
             </asp:Repeater>
         </div>--%>
         <div id="usual1" class="usual">
            <ul>
                <li><a href="#tab1" class="selected">系统管理员</a></li>
                <li><a href="#tab2">信息发布员</a></li>
                <li><a href="#tab3">稿件审核员</a></li>
            </ul>
            <div id="tab1">
                <asp:Repeater ID="rpt_SysAdmin" runat="server" OnItemCommand="rpt_SysAdmin_ItemCommand">
                 <HeaderTemplate>
                     <table id="tbody">
                         <tr>
                             <th>管理员ID</th>
                             <th>管理员密码</th>
                             <th>管理员姓名</th>
                             <th>管理员电话</th>
                             <th>管理员邮箱</th>
                             <th>操作</th>
                         </tr>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <tr>
                         <td><%#Eval("SysAdminAccount") %></td>
                         <td><%#GetPwd(Eval("SysAdminPwd")) %></td>
                         <td><%#Eval("SysAdminName") %></td>
                         <td><%#Eval("SysAdminTel") %></td>
                         <td><%#Eval("SysAdminEmail") %></td>
                         <td>
                             <asp:Button ID="btn_EditSysAdmin" runat="server" Text="修改" CommandArgument='<%# Eval("SysAdminAccount") %>' CommandName="Update"></asp:Button>
                             <asp:Button ID="btn_DeletSysAdmin" runat="server" Text="删除" CommandArgument='<%# Eval("SysAdminAccount") %>' CommandName="Delete"></asp:Button>
                         </td>
                     </tr>
                 </ItemTemplate>
                 <FooterTemplate></table></FooterTemplate>
             </asp:Repeater>
            </div>
            <div id="tab2">
                <asp:Repeater ID="rpt_InfoAdmin" runat="server" OnItemCommand="rpt_InfoAdmin_ItemCommand">
                 <HeaderTemplate>
                     <table id="tbody">
                         <tr>
                             <th>发布员ID</th>
                             <th>发布员密码</th>
                             <th>所属部门</th>
                             <th>发布员级别</th>
                             <th>发布员姓名</th>
                             <th>发布员电话</th>
                             <th>发布员邮箱</th>
                             <th>操作</th>
                         </tr>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <tr>
                         <td><%#Eval("C_InfoAdminAccount") %></td>
                         <td><%#GetPwd(Eval("C_InfoAdminPwd")) %></td>
                         <td><%#Eval("C_InfoAdminSector") %></td>
                         <td><%#Eval("C_InfoAdminCategory").ToString()=="0"?"超级发布员":"普通发布员" %></td>
                         <td><%#Eval("C_InfoAdminName") %></td>
                         <td><%#Eval("C_InfoAdminTel") %></td>
                         <td><%#Eval("C_InfoAdminEmail") %></td>
                         <td>
                             <asp:Button ID="btn_EditInfoAdmin" runat="server" Text="修改" CommandArgument='<%# Eval("C_InfoAdminAccount") %>' CommandName="Update"></asp:Button>
                             <asp:Button ID="btn_DeletInfoAdmin" runat="server" Text="删除" CommandArgument='<%# Eval("C_InfoAdminAccount") %>' CommandName="Delete"></asp:Button>
                         </td>
                     </tr>
                 </ItemTemplate>
                 <FooterTemplate></table></FooterTemplate>
             </asp:Repeater>
            </div>
            <div id="tab3">
                <asp:Repeater ID="rpt_Reviewer" runat="server" OnItemCommand="rpt_Reviewer_ItemCommand">
                 <HeaderTemplate>
                     <table id="tbody">
                         <tr>
                             <th>审核员ID</th>
                             <th>审核员密码</th>
                             <th>审核员姓名</th>
                             <th>审核员电话</th>
                             <th>审核员邮箱</th>
                             <th>操作</th>
                         </tr>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <tr>
                         <td><%#Eval("C_ReviewerAccount") %></td>
                         <td><%#GetPwd(Eval("C_ReviewerPwd")) %></td>
                         <td><%#Eval("C_ReviewerName") %></td>
                         <td><%#Eval("C_ReviewerTel") %></td>
                         <td><%#Eval("C_ReviewerEmail") %></td>
                         <td>
                             <asp:Button ID="btn_EditReviewer" runat="server" Text="修改" CommandArgument='<%# Eval("C_ReviewerAccount") %>' CommandName="Update"></asp:Button>
                             <asp:Button ID="btn_DeletReviewer" runat="server" Text="删除" CommandArgument='<%# Eval("C_ReviewerAccount") %>' CommandName="Delete"></asp:Button>
                         </td>
                     </tr>
                 </ItemTemplate>
                 <FooterTemplate></table></FooterTemplate>
             </asp:Repeater>
            </div>
        </div> 
    </form>
    <script type="text/javascript">
        $("#usual1 ul").idTabs();
    </script>
</asp:Content>
