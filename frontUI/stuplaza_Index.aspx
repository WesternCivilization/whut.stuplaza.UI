<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuplaza_Index.aspx.cs" Inherits="whut.stuplaza.UI.frontUI.stuplaza_Index" %>

<!DOCTYPE html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="rebot" content="index, follow" />
        
        <meta name="author" content="武汉理工大学信息管理协会" />
        <meta name="keywords" content="武汉理工大学学生工作部（处），武汉理工大学学工部，学工广场，武汉理工大学" />
        <meta name="description" content="本站前身为武汉理工大学学工广场，是由武汉理工大学学生工作部（处）主办，武汉理工大学信息管理协会开发的综合信息发布与展示平台。您可以在这里查找到所有与学工相关的信息和资源。祝您浏览愉快！" />
        <title>学工广场:首页</title>
		<meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1" />
        <link rel="icon" href="images/tit/icon.png" type="image/x-icon" />
        <link rel="stylesheet" href="frontcss/index.css" type="text/css" />
        <link rel="stylesheet" href="frontcss/tab_main.css" type="text/css" />
        <script src="frontjs/jquery-1.11.3.min.js" type="text/javascript"></script>
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

        <!--[if IE 6]>
        <script type="text/javascript">
            alert("你使用的是IE6浏览器，这是IE的过期版本，是时候该升级了！");
        </script>
        <![endif]-->
        <!--[if lte IE 7]>
        <script type="text/javascript">
            alert("你使用的是IE7浏览器，这是IE的过期版本，是时候该升级了！");
        </script>
        <![endif]-->


        <script>
                //统计网站
            var _hmt = _hmt || [];
            
               (function() {
            
                  var hm = document.createElement("script");
            
                  hm.src = "//hm.baidu.com/hm.js?753a01701c0339e8f3587ce5f1900a86";
            
                  var s = document.getElementsByTagName("script")[0];
            
                  s.parentNode.insertBefore(hm, s);
            })();
        </script>
    </head>
	<body>
<div style="width:1349px;">
        <!--#include file='navigation.html'-->
        
        <!--快速通道-->
		<div class="channel">
			<p><img src="images/channel/fast_channel.png" width="66" height="17" alt="快速通道"/></p>
			<ul>
				<li>
				    <span>></span>
				    <a href="http://stu.whut.edu.cn" target="_blank">学工信息系统</a>
				    <img src="images/channel/line.png" width="105" height="1"/>
				</li>
				<li>
				    <span>></span>
				    <a href="http://vpn.whut.edu.cn" target="_blank">虚拟化校园网</a>
				    <img src="images/channel/line.png" width="105" height="1"/>    
				</li>
				<li>
				    <span>></span>
				    <a href="http://i.whut.edu.cn" target="_blank">理工首页</a>
				    <img src="images/channel/line.png" width="105" height="1"/>
				</li>
				<li>
				    <span>></span>
				    <a href="http://lib.whut.edu.cn" target="_blank">理工图书馆</a>
                    <img src="images/channel/line.png" width="105" height="1"/>
				</li>
				<li>
				    <span>></span>
				    <a href="http://jwc.whut.edu.cn" target="_blank">理工教务处</a>
				    <img src="images/channel/line.png" width="105" height="1"/>
				</li>
				<li>
				    <span>></span>
				    <a href="http://jcc.whut.edu.cn" target="_blank">理工财务处</a>
				    <img src="images/channel/line.png" width="105" height="1"/>	
				</li>
				<li>
				    <span>></span>
				    <a href="http://202.114.173.72:8083/" target="_blank">校园卡服务</a>
				    <img src="images/channel/line.png" width="105" height="1"/>
				</li>
                <li>
				    <span>></span>
				    <a href="http://172.16.65.17/" target="_blank">电费查询</a>
				    <img src="images/channel/line.png" width="105" height="1"/>
				</li>
			</ul>
		</div>
	
     <div id="main">
		<!--slider-->
		<div id="banner">
            <div class="ban_slider" id="slider">
	            <ul>
                  <%=PreImg %>
	            </ul>
            </div>
            <div class="ban_cirl" id="cirl">			
	            <ul>
			        <li class="show"></li>
			        <li class=""></li>
			        <li class=""></li>
			        <li class=""></li>
			        
                </ul>
            </div>
		</div>

        <!--------------------------------------数据显示部分----------------------------------------------->

        <div id="content">
		    <div class="cont_tab">
			    <ul>
				    <li id="tab1" onmouseover="tabOver(1)" onmouseout="tabOut(1)">
					    <a href="stuplaza_articleList.aspx?category=1" target="_blank" class="tzgg">通知公告</a>					
					</li>
				    <li id="tab2" onmouseover="tabOver(2)" onmouseout="tabOut(2)">
					    <a href="stuplaza_articleList.aspx?category=2" target="_blank" class="xwdt">新闻动态</a>					
					</li>
				    <li id="tab3" onmouseover="tabOver(3)" onmouseout="tabOut(3)">
					    <a href="stuplaza_topicpicList.aspx" target="_blank" class="ztzx">专题在线</a>					
					</li>
				    <li id="tab4" onmouseover="tabOver(4)" onmouseout="tabOut(4)">
					    <a href="stuplaza_fileList.aspx" target="_blank" class="zdwj">制度文件</a>					
					</li>
				    <li id="tab5" onmouseover="tabOver(5)" onmouseout="tabOut(5)">
					    <a href="stuplaza_serviceList.aspx" target="_blank" class="fwzn">服务指南</a>					
					</li>
				    <li id="tab6" style="margin-right:0;" onmouseover="tabOver(6)" onmouseout="tabOut(6)">
					    <a href="#" target="_blank" class="yqlj">友情链接</a>					
					</li>
			    </ul>
		    </div>
		    <div class="cont_main">
			    <!--默认页面-->
			    <div class="cont_default" id="cont0">
				    <div class="left">
					    <div class="notice">
                            <div class="zxtzgg">
                                <span>最新通知公告</span>                    
						        <img src="images/cont_main/default/six.png" width="464" height="5" />
                            </div>
							<ul>
							        <%=PreNotice %>
							</ul>
					    </div>
					    <div class="plate">
						     <div class="cybk">
                                <span id="four">常用板块</span>               
						        <img src="images/cont_main/default/four.png" width="464" height="5" />
                            </div>
							<div class="plate_cont">
								<div class="left">
									<img src="images/cont_main/default/newest_files.png" width="90" height="18"/>
							        <ul>
							        	
                                        <%=PreFile %>
							        </ul>
								</div>
								<div class="right">
									<img src="images/cont_main/default/hot_themes.png" width="90" height="18"/>
							        <ul>
							        	<%=PreTopic %>
							        </ul>
								</div>
							</div>
					    </div>
				    </div>
				    <div class="right">
					    <div class="news">
						    <div class="zxxwdt">
                                <span>最新新闻动态</span>            
						        <img src="images/cont_main/default/six.png" width="464" height="5">
                            </div>
							<ul>
								<%=PreNews %>						                               
							</ul>
					    </div>
					    <div class="pic" id="pic">
						    <div class="tsxw">
                                <span>图说新闻</span>  
						        <img src="images/cont_main/default/four.png" width="464" height="5" />
                            </div>
							<div class ="scroll_pic">							
                                <%=PrePic %>						
						    </div>
					    </div>
				    </div>
			    </div>
			    
			    <!--通知公告-->
			    <div class="cont_tzgg" id="cont1" style="display: none;" onmouseover="contOver(1)" onmouseout="contOut(1)">
				    <div class="recent">
					    <div class="jqtzgg">
                                <span>近期通知公告</span>
						        <img src="images/cont_main/tzgg/listFour.png" height="5" />
                      </div>
					    <%= tzgg_Recent%>
       
					</div>
					<div class="early">
					    <div class="zqtzgg">
                                <span>早期通知公告</span>
						        <img src="images/cont_main/tzgg/listFour.png" height="5" />
                      </div>
						<ul>
						    <%=tzgg_Early %>
						</ul>
						<span class="more"><a href="stuplaza_articleList.aspx?category=1" target="_blank">查看更多</a></span>
					</div>													    
				</div>
			    <!--新闻动态-->
			    <div class="cont_xwdt" id="cont2" style="display: none;" onmouseover="contOver(2)" onmouseout="contOut(2)">
				      <div class="xwtt">
                                <span>新闻头条</span>
						        <img src="images/cont_main/xwdt/xinwenTop.png" height="5" />
                      </div>
				<%=xwdt_toutiao%>
                    <span class="more" style="clear:both; position:absolute; top:265px; left:890px;"><a href="stuplaza_articleList.aspx?category=2" target="_blank">查看更多</a></span>
					<div class="pic_news">
					    <div class="tsxww">
                                <span>图说新闻</span>
						        <img src="images/cont_main/xwdt/xinwenLeft.png" height="5" />
                      </div>
						<div class="pic_img">
						   
							<% =xwdt_pic%>
							
						</div>
					</div>
					<div class="re_news">
					    <div class="xyxw">
                                <span>学院新闻</span>
						        <img src="images/cont_main/xwdt/xinwenRight.png" height="5" />
                       </div>
						<ul>
						    <%=xwdt_recent %>
			
						</ul>
						<span class="more"><a href="stuplaza_manuList.aspx?" target="_blank">查看更多</a></span>
					</div>				    
				</div>
			    <!--专题在线-->
			    <div class="cont_ztzx" id="cont3" style="display: none;" onmouseover="contOver(3)" onmouseout="contOut(3)">
				    <%=ztzx_early %>
                    <span class="more"><a href="stuplaza_topicpicList.aspx" target="_blank">查看更多</a></span>	    
				</div>
			    <!--制度文件-->
			    <div class="cont_zdwj" id="cont4" style="display: none;" onmouseover="contOver(4)" onmouseout="contOut(4)">
				    <div class="left">
					    <div class="common_files">
                            <div class="cywj">
                                <span>常用文件</span>
						        <img src="images/cont_main/tzgg/listFour.png" width="440" height="5" />
                            </div>
							<ul>
                                <%=zdwj_common%>							    
							</ul>
						</div>
						<div class="recent_files">
						   <div class="jqwj">
                                <span>近期文件</span>
						        <img src="images/cont_main/tzgg/listFour.png" width="440" height="5" />
                            </div>
							<ul>
                                <%=zdwj_recent %>
							    
							</ul>
						</div>
					</div>
					<div class="line"><img src="images/cont_main/zdwj/fenlanxian.png" width="2" height="370" /></div>
					<div class="right">
					    <div class="early_files">
						   <div class="zqwj">
                                <span>早期文件</span>
						        <img src="images/cont_main/tzgg/listFour.png" width="440" height="5" />
                            </div>
							<ul>
							    <%=zdwj_early %>
							</ul>
							<span class="more"><a href="stuplaza_fileList.aspx" target="_blank">查看更多</a></span>
						</div>
					</div>				    
				</div>
			    <!--服务指南-->
			    <div class="cont_fwzn" id="cont5" style="display: none;" onmouseover="contOver(5)" onmouseout="contOut(5)">
				    <div class="guide">
					    <div class="bszn">
                                <span>办事指南</span>
						        <img src="images/cont_main/fwzn/listFour.png" width="440" height="5" />
                            </div>
						<ul>
                            <%=fwzn_guide %>
							
						</ul>
						<span class="more"><a href="stuplaza_serviceList.aspx" target="_blank">查看更多</a></span>
					</div>
					<div class="line"><img src="images/cont_main/fwzn/fenlanxian.png" width="2" height="390" /></div>
					<div class="download">
					     <div class="cyxz">
                                <span>常用下载</span>
						        <img src="images/cont_main/fwzn/listFour.png" width="440" height="5" />
                            </div>
						<ul>
                            <%=fwzn_download%>
							
						</ul>
						<span class="more"><a href="stuplaza_fileList.aspx" target="_blank">查看更多</a></span>
					</div>		    
				</div>
			    <!--友情链接-->
			    <div class="cont_yqlj" id="cont6" style="display: none;" onmouseover="contOver(6)" onmouseout="contOut(6)">
				    <div class="fast_channel">
					   <div class="kstd">
                                <span>快速通道</span>
						        <img src="images/cont_main/fwzn/listFour.png" width="440" height="5" />
                            </div>
						<ul>
						    <li>
							    <a href="http://stu.whut.edu.cn" target="_blank">学工信息系统</a>
								<span>></span>
							</li>
							<li>
							    <a href="http://vpn.whut.edu.cn" target="_blank">虚拟化校园网</a>
								<span>></span>
							</li>
							<li>
							    <a href="http://i.whut.edu.cn" target="_blank">理工首页</a>
								<span>></span>
							</li>
							<li>
							    <a href="http://lib.whut.edu.cn" target="_blank">理工图书馆</a>
								<span>></span>
							</li>
							<li>
							    <a href="http://jwc.whut.edu.cn" target="_blank">理工教务处</a>
								<span>></span>
							</li>
							<li>
							    <a href="http://jcc.whut.edu.cn" target="_blank">理工财务处</a>
								<span>></span>
							</li>
							<li>
							    <a href="http://202.114.173.72:8083/" target="_blank">校园卡服务</a>
								<span>></span>
							</li>
                            <li>
							    <a href="http://172.16.65.17/" target="_blank">电费查询</a>
								<span>></span>
							</li>
						</ul>
					</div>
					<div class="line"><img src="images/cont_main/yqlj/fenlanxian.png" width="1" height="356" /></div>
					<div class="right">
						<div class="links" style="margin-top:60px;">
						    <div class="icon"><img src="images/cont_main/yqlj/jiaoyubu0.png" width="40" height="40" alt="教育部" /></div>
						    <div class="name"><a href="http://www.moe.gov.cn/" target="_blank">教育部</a></div>
						</div>
						<div class="links" style="margin-top:60px;">
						    <div class="icon"><img src="images/cont_main/yqlj/wangluoxinxizhongxin0.png" width="40" height="40" alt="网络信息中心" /></div>
						    <div class="name"><a href="http://dept.whut.edu.cn/nic/" target="_blank">网络信息中心</a></div>
						</div>
						<div class="links">
						    <div class="icon"><img src="images/cont_main/yqlj/zhongguodaxueshengzaixian0.png" width="45" height="33" alt="中国大学生在线" /></div>
						    <div class="name"><a href="http://www.univs.cn/" target="_blank">中国大学生在线</a></div>
						</div>
						<div class="links">
						    <div class="icon"><img src="images/cont_main/yqlj/zhongguogaoxiaojiuyelianmeng0.png" width="45" height="36" alt="中国高校就业联盟" /></div>
						    <div class="name"><a href="http://www.job9151.com/" target="_blank">中国高校就业联盟</a></div>
						</div>
                        <div class="links">
					        <div class="icon"><img src="images/cont_main/yqlj/jingweiwang0.png" width="40" height="40" alt="经纬网" /></div>
						    <div class="name"><a href="http://www.wutnews.net/" target="_blank">经纬网</a></div>
						</div>
						<div class="links">
						    <div class="icon"><img src="images/cont_main/yqlj/xinguanxiehui0.png" width="40" height="40" alt="信息管理协会" /></div>
						    <div class="name"><a href=" http://www.imaw.org/index/intro.html" target="_blank">信息管理协会</a></div>
						</div>
						<div class="links">
						    <div class="icon"><img src="images/cont_main/yqlj/yanjiushenghui0.png" width="40" height="40" alt="研究生会" /></div>
						    <div class="name"><a href="http://gd.whut.edu.cn/" target="_blank">研究生会</a></div>
						</div>
						<div class="links">
						    <div class="icon"><img src="images/cont_main/yqlj/ligongzhisheng0.png" width="40" height="40" alt="理工之声" /></div>
						    <div class="name"><a href="http://public.whut.edu.cn/ygb/" target="_blank">理工之声</a></div>
						</div>
					</div>			    
				</div>			    
		    </div>
		</div>
        </div>

	
	<!--begin footer -->
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

	<!--end footer-->
    <script type="text/javascript" src="frontjs/index.js"></script>
       <script type="text/javascript">
           $(function () {
               $("div").filter(".toutiao").first().css("margin-left", "16px");
               $("div").filter(".toutiao").last().css("border-right", "1px solid #4b4b4b");
               BindFileAClick();
           })
           //绑定点击文件下载后后台更新下载次数
           function BindFileAClick() {
               $("a[fileid]").click(function () {
                   var fileId = $(this).attr("fileid");
                   $.ajax({
                       url: 'ProcessUpdateFileNum.ashx',
                       data: { 'fileId': fileId },
                       type: 'get',
                       success: function (data) {
                           if (data != "ok") {
                               return false;
                           }
                       }
                   })


               })

           }
        </script>
</div>
</body>
</html>
