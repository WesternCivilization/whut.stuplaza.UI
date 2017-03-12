<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="mrwwd.UI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WeUI</title>
    <link rel="stylesheet" href="css/weui.css"/>
    <link rel="stylesheet" href="css/example.css"/>
</head>
<body ontouchstart>
    <div class="container" id="container">

    </div>


<script type="text/html" id="tpl_home">
<div class="bd">  
    <img src="img/bg.png"></img>

	<div class="button login">
		<div class="bd spacing">
		    <div class="button button_sp_area">
		        <a href="#/button" class="weui_btn weui_btn_plain_default ">开始答题</a>
		        <a href="javascript:;" class="weui_btn weui_btn_plain_primary">查看规则</a>
		    </div>
		</div>
	</div>
</div>
</script>

<form id="form1" runat="server">
<script type="text/html" id="tpl_button">
<div class="bd">
    <div class="weui_cells_title">尊敬的<%=UserName %></div>
    <div class="weui_cells">
        <div class="weui_cell">
            <div class="weui_cell_bd weui_cell_primary">
                <p>党章党史</p>
            </div>
        </div>


<!--单选选项11-->
    		<div class="weui_cells_title"><%=Ques1 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x11">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer11 %></p>
		            </div>
		            <div class="weui_cell_ft">
                        <%--<asp:RadioButton ID="x11" runat="server" Class="weui_check" />
                        <input type="radio" name="radio1" class="weui_check" id="x11" checked="checked">--%>
		                <input type="radio" class="weui_check" id="x11" name='radio1' value="A">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>


		        <label class="weui_cell weui_check_label" for="x12">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer12 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio1' class="weui_check" id="x12" value="B" >
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>

		       <label class="weui_cell weui_check_label" for="x13">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer13 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio1' id="x13" value="C">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>


		        <label class="weui_cell weui_check_label" for="x14">

		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer14 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio1' class="weui_check" id="x14" value="D">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>



<!--单选选项12-->
    		<div class="weui_cells_title"><%=Ques2 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x21">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer21 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio2' id="x21" value="A">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x22">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer22 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio2' class="weui_check" id="x22" value="B">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		       <label class="weui_cell weui_check_label" for="x23">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer23 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio2' id="x23" value="C">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x24">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer24 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio2' class="weui_check" id="x24"  value="D">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>	


<!-- button-->
   
<!-- /button-->

    <div class="weui_cells">
        <div class="weui_cell">
            <div class="weui_cell_bd weui_cell_primary">
                <p>党纪党纲</p>
            </div>
        </div>


<!--单选选项11-->
    		<div class="weui_cells_title"><%=Ques3 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x31">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer31 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio3' id="x31" value="A">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>


		        <label class="weui_cell weui_check_label" for="x32">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer32 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio3' class="weui_check" id="x32"  value="B">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>

		       <label class="weui_cell weui_check_label" for="x33">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer33 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio3' id="x33" value="C">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>


		        <label class="weui_cell weui_check_label" for="x34">

		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer34 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio3' class="weui_check" id="x34" value="D">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>



<!--单选选项12-->
    		<div class="weui_cells_title"><%=Ques4 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x41">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer41 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio4' id="x41" value="A">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x42">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer42 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio4' class="weui_check" id="x42"  value="B">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		       <label class="weui_cell weui_check_label" for="x43">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer43 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio4' id="x43" value="C">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x44">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer44 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio4' class="weui_check" id="x44" value="D">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>	

<!-- button-->
		    
<!-- /button-->
    <div class="weui_cells">
        <div class="weui_cell">
            <div class="weui_cell_bd weui_cell_primary">
                <p>行业相关</p>
            </div>
        </div>



        <!--单选选项15-->
    		<div class="weui_cells_title"><%=Ques5 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x51">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer51 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio5' id="x51" value="A">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x52">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer52 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio5' class="weui_check" id="x52" checked="checked" value="B">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		       <label class="weui_cell weui_check_label" for="x53">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer53 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio5' id="x53" value="C">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x54">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer54 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio5' class="weui_check" id="x54" checked="checked" value="D">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>		    	    
    </div>



<!--单选选项13-->
    		<div class="weui_cells_title"><%=Ques6 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x61">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer61 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio6' id="x61" value="A">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x62">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer62 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio6' class="weui_check" id="x62" checked="checked" value="B">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		       <label class="weui_cell weui_check_label" for="x63">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer63 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio6' id="x63" value="C">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		        <label class="weui_cell weui_check_label" for="x64">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer64 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" name='radio6' class="weui_check" id="x64" checked="checked" value="D">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>		    	    
    </div>

<!-- button-->
		    
<!-- /button-->
    <div class="weui_cells">
        <div class="weui_cell">
            <div class="weui_cell_bd weui_cell_primary">
                <p>必备答题</p>
            </div>
        </div>


<!--单选选项11-->
    		<div class="weui_cells_title"><%=Ques7 %></div>
		    <div class="weui_cells weui_cells_radio">
		        <label class="weui_cell weui_check_label" for="x71">
		            <div class="weui_cell_bd weui_cell_primary">
		                <p><%=Answer07 %></p>
		            </div>
		            <div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name='radio7' id="x71">
		                <span class="weui_icon_checked"></span>
		            </div>
		        </label>
		    </div>

<!-- button-->
				<div class=" bd spacing">
				    <div class="weui_progress">
				        <div class="weui_progress_bar">
				            <div class="weui_progress_inner_bar js_progress" style="width: 0%;"></div>
				        </div>
				        <a href="javascript:;" class="weui_progress_opr">
				            <i class="weui_icon_cancel"></i>
				        </a>
				    </div>
				        <div class="weui_btn_area home" >
		                 <button onclick="GetRadioValue()" class="weui_btn weui_btn_plain_default" >提交</button>
    					</div>
				</div>		    
<!-- /button-->
</script>
    </form>
    <script src="js/zepto.min.js"></script>
    <script src="js/router.min.js"></script>
    <script src="js/example.js"></script>
    <script src="scripts/jquery-2.2.3.min.js"></script>
    <script type="text/javascript">
         function GetRadioValue(){
             var SelectedRadioValue = "";
             var a = $("input[name='radio1']").filter(':checked').val();
             var b = $("input[name='radio2']").filter(':checked').val();
             var c = $("input[name='radio3']").filter(':checked').val();
             var d = $("input[name='radio4']").filter(':checked').val();
             var e = $("input[name='radio5']").filter(':checked').val();
             var f = $("input[name='radio6']").filter(':checked').val();
             SelectedRadioValue = a + " " + b + " " + c + " " + d + " " + e + " " + f;
             var url="submit.aspx?radioValue="+SelectedRadioValue;
             window.location.href = url;
        
        }
    </script>
</body>
</html>
