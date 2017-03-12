<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ReviewManu.aspx.cs" Inherits="whut.stuplaza.UI.ReviewManu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
    <script src="bkgroundjs/jquery-easyui-1.3.1/jquery-1.8.0.min.js"></script>
    <link href="bkgroundjs/jquery-easyui-1.3.1/themes/default/easyui.css" rel="stylesheet" />
    <link href="bkgroundjs/jquery-easyui-1.3.1/themes/icon.css" rel="stylesheet" />
    <script src="bkgroundjs/jquery-easyui-1.3.1/jquery.easyui.min.js"></script>
    
    <style type="text/css">
        #form1 {
            margin-left: 15px;
        }       
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
    <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">稿件审核</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form runat="server" id="form1">

        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand1">
            <HeaderTemplate><table id="tbody"><tr><th style="width:10%;">稿件编号</th><th style="width:20%;">稿件标题</th><th style="width:15%;">稿件所属学院</th><th style="width:10%;">稿件作者</th><th style="width:10%;">作者电话</th><th style="width:10%;">作者email</th><th style="width:15%;">稿件审核状态</th><th style="width:10%;">操作</th></tr></HeaderTemplate>
            <ItemTemplate>
                <tr><td><%#Eval("ManuScriptId") %></td><td><%#Eval("ManuScriptTitle") %></td><td><%#Eval("ManuScriptAcademy") %></td><td><%#Eval("ManuScriptAuthor") %></td><td><%#Eval("ManuScriptTel") %></td><td><%#Eval("ManuScriptEmail") %></td><td><%#CheckManuScriptStatus(Eval("ManuScriptStatus"))%></td><td><a href="#" manusid='<%#Eval("ManuScriptId") %>'>详情</a><a href="EditManuScript.aspx?manuid=<%#Eval("ManuScriptId") %>">修改</a><input type="button" class="stu_btn" manuid='<%#Eval("ManuScriptId") %>'" name="btnReview" value="点击通过审核"/><asp:Button ID="btn_change" CssClass="stu_btn" CommandName="Update"   CommandArgument='<%# Eval("ManuScriptId") %>' runat="server" Text="标记为审核未通过" /><asp:Button ID="btn_delete" CommandName="Delete"  CssClass="stu_btn" CommandArgument='<%# Eval("ManuScriptId") %>' runat="server" Text="删除" /></td></tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
          <div id="navDiv" class="paginator">
            <asp:Literal ID="NavStrHtml" runat="server"></asp:Literal>
        </div>
    </form>
     <!----------------------显示详情信息的对话框 开始------------------------------>
        <div id="DetailDiv" style="display:none;">
            <h1>显示详情信息</h1>
            <hr/>
            <div>稿件标题：<span id="spTitle"></span></div>
            <p>稿件内容：</p>
            <div id="spContent"></div>
                
        </div>
    
        <!----------------------显示修改的对话框 结束------------------------------>
    <script type="text/javascript">
        $(function () {
         
            BindReviewClick();
            BindDetailClick();
          
        })
        
        function BindReviewClick() {
            $(".stu_btn").click(function () {
                if (confirm("确定要审核通过么?")) {
                    var str = $(this).val();
                    var s = $(this);
                    if (str == "点击通过审核") {
                        var manuid = $(this).attr("manuid");
                        $.ajax({
                            url: "ReviewHandle.ashx",
                            data: { "manuid": manuid },
                            success: function (data) {
                                s.val("已经通过审核");
                                window.location.reload();

                            }

                        })

                    }
                }

            });
        }
        
        function BindDetailClick()
        {
            $("#tbody a:contains('详情')").click(function () {

                var manusid = $(this).attr("manusid");
                getManusToDetail(manusid);//获取稿件详情然后把数据放到div上去。
                showDetailDialog();//弹出一个显示详情的Div

                return false;
            });

        }
        function showDetailDialog() {
            //弹出一个Div
            $("#DetailDiv").css("display", "block");
            //把这个div弹出到 中间，而且是模态
            $("#DetailDiv").dialog({
                title: "详情对话框",
                width: 500,
                height: 500,
                modal: true,
                minimizable: true,
                maximizable: true,
                resizable: true,
                buttons: [{
                    text: "关闭",
                    iconCls: "icon-cancel",
                    handler: function () {
                        $("#DetailDiv").dialog("close");
                    }
                }]
            });
        }
        function getManusToDetail(manusid) {
            //发送一个异步请求，把后台加载的数据放到div上去。
            $.getJSON("ManuScriptDetail.ashx", { id:manusid }, function (data) {
                $("#spTitle").text(data.ManuScriptTitle);
                $("#spContent").html(data.ManuScriptContent);
            });

        }
      
     
        
     

        </script>
</asp:Content>
