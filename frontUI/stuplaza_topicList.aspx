<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuplaza_topicList.aspx.cs" Inherits="whut.stuplaza.UI.frontUI.stuplaza_topicList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="index, follow" />
<meta name="author" content="武汉理工大学信息管理协会" />
<meta name="keywords" content="武汉理工大学学生工作部（处），武汉理工大学学工部，学工广场，武汉理工大学"/>
<meta name="description" content="本站前身为武汉理工大学学工广场，是由武汉理工大学学生工作部（处）主办，武汉理工大学信息管理协会开发的综合信息发布与展示平台。您可以在这里查找到所有与学工相关的信息和资源。祝您浏览愉快！"/>
<title>学工广场  专题列表</title>
<link rel="shortcut icon" href="images/tit/icon.png" type="image/x-icon" />
<link rel="stylesheet" href="frontcss/common.css" type="text/css" />
<link rel="stylesheet" href="frontcss/list_page.css" type="text/css" />
<script  type="text/javascript" src="frontjs/jquery-1.11.3.min.js"></script>
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
<style type="text/css">
    .more {
        position: relative;
        top: 0px;
        left: 125px;
    }
    .more a{
        font-size:18px;
        color:#444;
        text-decoration:none;
    }
    .more a:hover{
        text-decoration:underline;
        color:#567fe6;
        font-weight:bold;
    }
</style>
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
            <span>></span>
			<a href="stuplaza_topicpicList.aspx">专题在线</a>	
            <span>></span>
			<span><%=nav %></span>
		</div>
		<!--学生园区-->
		<div id="content">
		    <div class="left_trends">
			    <img src="images/list_page/stu_park/title_zuixindongtai.png" width="690" height="35" />
				<ul>
                   
                    <%=GetList %>
				</ul>
               
				<div class="page_number">
					
                    <%=navHtml %>			
				</div>
			</div>
			<div class="right_list">
			    <ul>
				   <%=sideNav %>
				</ul>
                 <span class="more"><a href="stuplaza_topicpicList.aspx" target="_blank">查看更多</a></span>
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


