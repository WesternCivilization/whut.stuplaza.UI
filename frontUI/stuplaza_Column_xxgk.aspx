<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuplaza_Column_xxgk.aspx.cs" Inherits="whut.stuplaza.UI.frontUI.stuplaza_Column_xxgk" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="index, follow" />
<meta name="author" content="武汉理工大学信息管理协会" />
<meta name="keywords" content="武汉理工大学学生工作部（处），武汉理工大学学工部，学工广场，武汉理工大学"/>
<meta name="description" content="本站前身为武汉理工大学学工广场，是由武汉理工大学学生工作部（处）主办，武汉理工大学信息管理协会开发的综合信息发布与展示平台。您可以在这里查找到所有与学工相关的信息和资源。祝您浏览愉快！"/>
<title>信息公开</title>
<link rel="shortcut icon" href="images/tit/icon.png" type="image/x-icon" />
<link rel="stylesheet" href="frontcss/common.css" type="text/css" />
<link href="frontcss/list_page.css" rel="stylesheet"  type="text/css"/>
<style>
    #contents {
    height:auto;
    margin-top: 10px;
    }
    .title {
    height: 58px;
    margin-top: 25px;
    font-size: 30px;
    text-align: center;
    width:100%;
    }
    .text {
    padding:0 20px;
    font-size: 16px;
    line-height: 28px;
    margin-top: 10px;
    }
	.text p{
	background:none !important; background:transparent;
	}
table.MsoTableGrid
	{border:solid windowtext 1.0pt;
	font-size:10.5pt;
	font-family:等线;
        height: 631px;
        width: 740px;
    }
</style>
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
  
        <!--#include file='navigation.html'-->

 <div id="main">
	<div id="container">	
		<!--当前位置-->
	 <div id="location">
		    <span class="here">当前位置：</span>
			<a href="stuplaza_Index.aspx">首页</a>
			>信息公开	
		</div>
		<!--学生园区-->
	 <div id="content">
         <div class="left_trends">
             <img src="images/list_page/stu_park/title_zuixindongtai.png" width="690" height="35" />

             <p class="title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 信息公开目录</p>
             <div class="text">



                 <div align="center">
                     <table border="1" cellpadding="0" cellspacing="0" class="MsoTableGrid">
                         <tr>
                             <td valign="top" width="43">
                                 <p align="center" class="MsoNormal">
                                     序号<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="155">
                                 <p align="center" class="MsoNormal">
                                     类别<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     公开事项<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="center" class="MsoNormal">
                                     公开内容<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td rowspan="6" valign="top" width="43">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US">1<o:p></o:p></span></p>
                             </td>
                             <td rowspan="6" valign="top" width="155">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     基本信息<span lang="EN-US"><o:p></o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     （<span lang="EN-US">6</span>项）<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     单位基本情况<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">1</span>）<a href="stuplaza_FirstColStatic.aspx?columnid=01010000">单位简介及工作职能</a><span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     领导班子<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">2</span>）<a href="stuplaza_FirstColStatic.aspx?columnid=01020000">单位领导班子分工及工作职责</a><span lang="EN-US">/</span>办公电话等<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                    机构设置 <span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">3</span>）<a href="stuplaza_FirstColStatic.aspx?columnid=01030000">组织机构设置（含科、室等），工作职责及相关岗位职责、办公地点、办公电话等</a><span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     制度规范<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">4</span>）国家相关政策法规及单位制定的规章制度<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td rowspan="2" valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     工作计划及总结<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">5</span>）单位发展规划<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">6</span>）单位年度工作要点及执行情况等<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td rowspan="6" valign="top" width="43">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US">2<o:p></o:p></span></p>
                             </td>
                             <td rowspan="6" valign="top" width="155">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     管理服务信息（<span lang="EN-US">6</span>项）<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     管理清单<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">7</span>）单位管理工作清单<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     服务清单<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">8</span>）单位服务工作清单<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     负面清单<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">9</span>）单位负面工作清单<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     内部规范<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">10</span>）内部工作规范<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     办事流程<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">11</span>）<a href="stuplaza_serviceList.aspx">办事流程</a><span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     可供下载的资料<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">12</span>）<a href="stuplaza_fileList.aspx">数据、表格、文件等下载</a><span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="43">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US">3<o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="155">
                                 <p align="center" class="MsoNormal">
                                     公示公告信息（<span lang="EN-US">1</span>项）<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     公示公告<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     （<span lang="EN-US">13</span>）需要对外公示、公告的信息<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                         </tr>
                         <tr>
                             <td valign="top" width="43">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US">4<o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="155">
                                 <p align="center" class="MsoNormal">
                                     其他信息<span lang="EN-US"><o:p></o:p></span></p>
                             </td>
                             <td valign="top" width="170">
                                 <p align="center" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                             </td>
                             <td valign="top" width="468">
                                 <p align="left" class="MsoNormal">
                                     <span lang="EN-US"><o:p>&nbsp;</o:p></span></p>
                             </td>
                         </tr>
                     </table>
                 </div>



             </div>


         </div>
			<div class="right_list">
			    <ul>
                   <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="#">>单位基本情况</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>领导班子</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>机构设置</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>制度规范</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>工作计划及总结</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>管理清单</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>服务清单</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>负面清单</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>内部规范</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>办事流程</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>可供下载的资料</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>公示公告</a></li>
                    <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">>其他信息</a></li>
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
