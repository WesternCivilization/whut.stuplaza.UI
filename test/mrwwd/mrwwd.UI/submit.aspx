<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="submit.aspx.cs" Inherits="mrwwd.UI.submit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>submit</title>
    <link rel="stylesheet" href="css/weui.css"/>
    <link rel="stylesheet" href="css/example.css"/>
</head>
<body ontouchstart>
    <form id="form1" runat="server">
    <div>
    
<div class="container" id="container">
<div class="weui_msg">
    <div class="weui_icon_area"><i class="weui_icon_success weui_icon_msg"></i></div>
    <div class="weui_text_area">
        <h2 class="weui_msg_title">操作成功</h2>
        <p class="weui_msg_desc">内容详情，可根据实际需要安排</p>
    </div>
    <div class="weui_opr_area">

				        <div class="weui_btn_area home">
		                 <a href="todayQuestion.aspx" class="weui_btn weui_btn_plain_default ">查看结果</a>
    					</div>
    				    <div class="weui_btn_area home">
		                 <a href="historyQuestion.aspx" class="weui_btn weui_btn_plain_default ">查看历史题库</a>
    					</div>

    </div>
    <div class="weui_extra_area">
        <a href="">查看详情</a>
    </div>
</div>
</div>




    <script src="js/zepto.min.js"></script>
    <script src="js/router.min.js"></script>
    <script src="js/example.js"></script>


    </div>
    </form>
</body>
</html>
