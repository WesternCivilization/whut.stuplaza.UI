<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuplaza_articleListBySector.aspx.cs" Inherits="whut.stuplaza.UI.frontUI.stuplaza_articleListBySector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="index, follow" />
<meta name="author" content="武汉理工大学信息管理协会" />
<meta name="keywords" content="武汉理工大学学生工作部（处），武汉理工大学学工部，学工广场，武汉理工大学"/>
<meta name="description" content="本站前身为武汉理工大学学工广场，是由武汉理工大学学生工作部（处）主办，武汉理工大学信息管理协会开发的综合信息发布与展示平台。您可以在这里查找到所有与学工相关的信息和资源。祝您浏览愉快！"/>
<title>学工广场 文章列表</title>
<link rel="shortcut icon" href="images/tit/icon.png" type="image/x-icon" />
<link rel="stylesheet" href="frontcss/common.css" type="text/css" />
<link href="frontcss/listpagesector.css" rel="stylesheet" />
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
 
</head>

<body>
<%--    <div id="web_bg">
        <img style="position:fixed; height="60%" width="100%" />
    </div>--%>

        <!--#include file='navigation.html'-->

 <div id="main">
	<div id="container">		
		<!--3个悬停按钮-->
		<div class="hover_btn">
			<ul>
				<li>
				    <a href="OnlineSubmit.html" target="_blank" class="zxtg">在线投稿</a>
				</li>
				<li>
				    <a href="#" class="bzxx" onclick="Showbox()">部长信箱</a>
				</li>
				<li>
				    <a href="stuplaza_Index.aspx" class="fhzy">返回主页</a>
				</li>
			</ul>
		</div>
        <!--部长信箱弹出层-->
        <div id="bg" class="bg"></div> 
        <div id="mailbox" class="mailbox">
            <div class="mailtop">
                <img src="images/hover_btn/close4.jpg" width="28" height="28" onclick="Close()"/>
            </div>
            <div class="mailcont">
                <p>您若有任何问题欢迎联系学工部部长！<br />部长邮箱为：</p>
                <p>xuegongbu@whut.edu.cn</p>
                <button type="button" onclick="Mail()">登录邮箱</button>
            </div>
        </div>
		<!--当前位置-->
		<div id="location">
		    <span class="here">当前位置：</span>
			<a href="stuplaza_Index.aspx">首页</a>
			<span>></span>
            <span><%=prenav %></span>
            <span>></span>
			<span><%=nav%></span>
		</div>
		<!--最新动态-->
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
                    <li><a href="stuplaza_articleListBySector.aspx?sector=11&&category=<%=Acategory %>">综合办公室</a></li>
				   <li><a href="stuplaza_articleListBySector.aspx?sector=1&&category=<%=Acategory %>">学生教育办公室（学生）</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=2&&category=<%=Acategory %>">学生教育办公室（辅导员）</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=3&&category=<%=Acategory %>">学生管理办公室(日常)</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=4&&category=<%=Acategory %>">学生管理办公室(就业)</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=5&&category=<%=Acategory %>">心理健康教育中心</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=6&&category=<%=Acategory %>">学生资助与服务中心(资助)</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=7&&category=<%=Acategory %>">学生资助与服务中心(住宿、勤工助学)</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=8&&category=<%=Acategory %>">招生办公室</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=9&&category=<%=Acategory %>">武装部</a></li>
                    <li><a href="stuplaza_articleListBySector.aspx?sector=10&&category=<%=Acategory %>">团委</a></li>
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
