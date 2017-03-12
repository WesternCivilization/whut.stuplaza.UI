<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuplaza_FirstColDynmic.aspx.cs" Inherits="whut.stuplaza.UI.frontUI.stuplaza_FirstColDynmic" %>

<!DOCTYPE html>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="index, follow" />
<meta name="author" content="武汉理工大学信息管理协会" />
<meta name="keywords" content="武汉理工大学学生工作部（处），武汉理工大学学工部，学工广场，武汉理工大学"/>
<meta name="description" content="本站前身为武汉理工大学学工广场，是由武汉理工大学学生工作部（处）主办，武汉理工大学信息管理协会开发的综合信息发布与展示平台。您可以在这里查找到所有与学工相关的信息和资源。祝您浏览愉快！"/>
<title><%=DynamicTitle %></title>
<link rel="shortcut icon" href="images/tit/icon.png" type="image/x-icon" />
<link rel="stylesheet" href="frontcss/common.css" type="text/css" />
<link rel="stylesheet" href="frontcss/stu_park.css" type="text/css" />
<style type="text/css">
.title, .info, .text{width:890px; margin-left:50px;}
.title{height:58px; margin-top:25px; font-size:30px; text-align:center;}
.info{color:#999; text-align:center;}
.text{font-size:16px; line-height:28px; margin-top:20px;}
.text p{margin-bottom:20px;}
</style>
<script type="text/javascript" src="frontjs/jquery-1.11.3.min.js"></script>
<script type="text/javascript">
            function Search() {
                //这个a的值就是我们在输入框里面的值
                var a = document.searchform.searchword.value;
                window.open("http://www.baidu.com/s?wd=" + a);
                return false;
            }
            //进入邮箱
            function Mail() {
                window.open("https://mail.qq.com/");
            }
            //点击部长信箱，出现弹出层
            function Showbox() {
                $("#bg, #mailbox").show();
            }
            //关闭弹出层
            function Close() {
                $("#bg, #mailbox").hide();
            }
</script>
</head>

<body>
<%--    <div id="web_bg">
        <img style="position:fixed;" src="images/tit/bg_02.png" height="60%" width="100%" />
    </div>--%>

        <!--#include file='navigation.html'-->

 <div id="main">
	<div id="container">	
		<!--当前位置-->
		<div id="location">
		    <span class="here">当前位置：</span>
            <a href="stuplaza_Index.aspx">首页</a>
            <%=nav %>
		</div>
        <div id="content">
		 <div class="left_trends">
			    <img src="images/list_page/stu_park/title_zuixindongtai.png" width="690" height="35" />
				<ul>
                <%=content %>
                </ul>
             <div class="page_number">
					<!--<a href="#" class="last_page"><</a>
				    <a href="#" class="selected">1</a>
					<a href="#">2</a>
					<a href="#">3</a>
					<a href="#">4</a>
					<a href="#">5</a>
					<a href="#">6</a>
					<a href="#">7</a>
					<a href="#" class="next_page">> </a>			-->	
                    <asp:Literal ID="NavStrHtml" runat="server"></asp:Literal>
				</div>
                
			</div>
			<div class="right_list">
			    <ul>
			
			
                    <%=sidebar%>
				
				</ul>
			</div>		    
		</div>
	</div>
	</div>
	<!--footer-->
    <div id="footer">
	    <div class="foot_main">
		    <div class="foot_one">
			    <ul>
			    	<li><a href="#">关于我们</a><span>|</span></li>
			    	<li><a href="#">学工博客</a><span>|</span></li>
			    	<li><a href="#">团队风采</a><span>|</span></li>
			    	<li><a href="#">诚聘英才</a><span>|</span></li>
			    	<li><a href="#">在线投稿</a></li>
			    </ul>
		    </div>
		    <div class="foot_two">
			    <p>&copy;Copyright 2013-2015 武汉理工大学学生工作部（处） All Rights Reaserved.</p>
			    <p>地址：武汉理工大学马房山校区东院 电话：027-87750516 邮箱：xgb@whut.edu.cn 技术支持：武汉理工大学信息管理协会</p>
		    </div>
		</div>
    </div>
    
</body>
</html>


