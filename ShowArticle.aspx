<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ShowArticle.aspx.cs" Inherits="whut.stuplaza.UI.ShowArticle"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
    <script src="frontUI/frontjs/jquery-1.11.3.min.js"></script>
    <style type="text/css">
        #form1 {
            margin-left: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
   <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">文章展示</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
        <form id="form1" runat="server">
    <div>
        <div>
        <p><asp:RadioButton ID="RB_notice" runat="server"  GroupName="category" Text="查看通知公告"  />
        <asp:RadioButton ID="RB_news" runat="server"  GroupName="category"  Text="查看新闻动态"  />
        <asp:RadioButton ID="RB_service" runat="server"  GroupName="category" Text="查看服务指南" />
            <asp:Button ID="btn_Select" runat="server" Text="按类型查找" OnClick="btn_Select_Click" CssClass="stu_btn"/> 
            <asp:TextBox ID="txt_title" runat="server"></asp:TextBox>
            <asp:Button ID="btn_title" runat="server" Text="按标题查找" OnClick="btn_title_Click" CssClass="stu_btn" />
            <asp:Label ID="lbl_title" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        </p>
            </div>
        <asp:Repeater ID="newsList" runat="server" OnItemCommand="newsList_ItemCommand">
            <HeaderTemplate>
                <table class="tb_content" id="tbody"><tr class="tb_tr"><th style="width:20%;">文章标题</th><th style="width:10%;">发布文章部门</th><th style="width:10%;">文章类型</th><th style="width:10%;">文章所属专题</th><th style="width:10%;">所属栏目</th><th style="width:12%;">文章发布人姓名</th><th style="width:10%;">文章发布时间</th><th style="width:8%;">附件</th><th style="width:10%;">操作</th></tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ArticleTitle") %></td>
                    <td><%#Eval("ArticleSector") %></td>
                    <td><%#CheckArticleCategory(Eval("ArticleCategory"))%></td>
                    <td><%#ReturnTopicName(Eval("topic.TopicId"))%></td>
                     <td><%#ReturnColumnName(Eval("ArticleColumn"))%></td>
                    <td><%#Eval("ArticlePostStaff") %></td>
                    <td><%#Eval("ArticleTime") %></td>
                    <td><%#GetArticleAnnexAddr(Eval("ArticleAnnexAddr")) %></td>
                    <td><a href='#' newsid="<%#Eval("ArticleId") %>" class='detail'>详情</a>
                    <a href="EditArticle.aspx?editid=<%#Eval("ArticleId") %>" class="detail">修改</a>
                    <asp:Button ID="btnDelete" OnClientClick="return confirm('确定删除')" CommandArgument='<%# Eval("ArticleId") %>' CommandName="Delete" runat="server" Text="删除" CssClass="stu_btn"></asp:Button>
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>


        </asp:Repeater>
        
          <div id="navDiv" class="paginator">
            <asp:Literal ID="NavStrHtml" runat="server"></asp:Literal>
           </div>
           <div class="bgDiv" style="display:none;">

           </div>
           <div class="detailBox" id="detailBox" >
               <div class="titleDiv">
                   <span>文章详情</span>
                   <span id="close">[关闭页面]</span>
               </div>
               <div class="detailDiv" style="display:none;">
            
               </div>
           </div>
    </div>
    </form>



        <script type="text/javascript">
            $(function () {
                BindDetailButton();
                Close();
            })
            //绑定详情事件
            function BindDetailButton() {
                $("table a:contains('详情')").click(function () {
                    var newsid = $(this).attr("newsid");
                    $.ajax({
                        url: "LoadDetailById.ashx",
                        data: { "newsid": newsid },
                        success: function (data) {
                            $(".bgDiv, .detailBox").show( );
                            $(".detailDiv").show( ).html(data);
                        }

                    });

                    return false;
                });
            }
            function Close() {
                $("#close").click(function () {
                    $(".bgDiv, .detailBox").hide();
                })
            }
    </script>
</asp:Content>
