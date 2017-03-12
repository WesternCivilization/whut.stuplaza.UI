<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuplaza_serviceDetail.aspx.cs" Inherits="whut.stuplaza.UI.frontUI.stuplaza_serviceDetail" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>学工广场 服务指南</title>
<link rel="shortcut icon" href="images/tit/icon.png" type="image/x-icon" />
<link rel="stylesheet" href="frontcss/common.css" type="text/css" />
<link rel="stylesheet" href="frontcss/text.css" type="text/css" />
<script  type="text/javascript" src="frontjs/jquery-1.11.3.min.js"></script>
<style type="text/css">
    .text{height:100%;}
</style>
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
			<a href="stuplaza_Index.html">首页</a>
			<span>></span>
			<a href="stuplaza_serviceList.aspx">服务指南</a>	
			<span>></span>
			<a href="#">办事指南</a>	
			<span>></span>
			<span>正文</span>		
		</div>
		<!--办事指南-->
		<div id="content">
		    <div class="title">
			    <%=model.ArticleTitle %><hr />
			</div>
			<div class="text">
			    <%=model.ArticleContent %>
			</div>
            <div class="download">
                <div style="float:left">
                <span>附件下载：</span>
               <%=aAnnex %>
              </div>
                <div style="float:right">
                    <p><%=model.ArticleSector %><br />
					<%=model.ArticleTime %></p>
                    </div>
            </div>	
		
		</div>
		<!--分享-->	
	    <div class="bdsharebuttonbox share">
		   <span>分享到：</span>
		   <div class="icon icon1">
               <a class="bds_qzone" data-cmd="qzone" href="javascript:void(0);" style="background:url();"></a>
           </div>
		   <div class="icon icon2">
               <a class="bds_tsina" data-cmd="tsina" href="javascript:void(0);" style="background:url();"></a>
           </div>
           <div class="icon icon3">
               <a class="bds_weixin" data-cmd="weixin" href="javascript:void(0);" style="background:url();"></a>
           </div>
		   <div class="icon icon4">
               <a class="bds_sqq" data-cmd="sqq" href="javascript:void(0);" style="background:url();"></a>
           </div>
		</div>  
    <script type="text/javascript">
        window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdPic": "", "bdStyle": "0", "bdSize": "16" }, "share": {},"selectShare": { "bdContainerClass": null, "bdSelectMiniList": ["qzone", "tsina", "sqq", "weixin"] } }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];
    </script>
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


