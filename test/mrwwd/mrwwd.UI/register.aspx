<!DOCTYPE html>
<html lang="zh-cmn-Hans">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0">
    <title>submit</title>
    <link rel="stylesheet" href="css/weui.css"/>
    <link rel="stylesheet" href="css/example.css"/>
</head>
<body ontouchstart>
<div class="container" id="container">
</div>

<script type="text/html" id="tpl_home">
<div class="button">
<div class="bd" style="background:#790102">
<div class="weui_cells">
    <div class="weui_cells_title">基本信息填写</div>
        <div class="weui_cells weui_cells_form">

            <div class="weui_cell">
                <div class="weui_cell_hd"><label class="weui_label">姓名</label></div>
                <div class="weui_cell_bd weui_cell_primary">
                    <input class="weui_input" type="text" id="name" placeholder="请填写姓名"/>
                </div>
            </div>

            <div class="weui_cell">
                <div class="weui_cell_hd"><label class="weui_label">电话</label></div>
                <div class="weui_cell_bd weui_cell_primary">
                    <input class="weui_input" type="number" id="phone" pattern="[0-9]*" placeholder="请填写电话"/>
                </div>
            </div>

            <div class="weui_cells_title">所在区域填写</div>
            
            <div class="weui_cells">
                
                <div class="weui_cell weui_cell_select weui_select_after">
                    <div class="weui_cell_hd">
                        <label for="" class="weui_label">所在市</label>
                    </div>
                    <div class="weui_cell_bd weui_cell_primary">
                        <select class="weui_select" name="select1" id="province">
                            <option value="1">武汉</option>     
                            <option value="2">黄石</option>     
                            <option value="3">十堰</option>     
                            <option value="4">荆州</option>     
                            <option value="5">宜昌</option>     
                            <option value="6">襄樊</option>     
                            <option value="7">鄂州</option>     
                            <option value="8">荆门</option>     
                            <option value="9">孝感</option>     
                            <option value="10">黄冈</option>     
                            <option value="11">咸宁</option>     
                            <option value="12">随州</option>     
                            <option value="13">恩施</option>     
                            <option value="14">天门</option>     
                            <option value="15">仙桃</option>     
                            <option value="16">潜江</option>     
                            <option value="17">神龙架</option>   
                            <option value="121">省局</option> 
                        </select>
                    </div>
                </div>

                <div class="weui_cell weui_cell_select weui_select_after">
                    <div class="weui_cell_hd">
                        <label for="" class="weui_label">所在县</label>
                    </div>
                    <div class="weui_cell_bd weui_cell_primary">
                        <select class="weui_select" name="select2" id="city">
                           <optgroup
                            <option value="18">江岸区</option>
                            <option value="19">武昌区</option>
                            <option value="20">江汉区</option>
                            <option value="21">硚口区</option>
                            <option value="22">汉阳区</option>
                            <option value="23">青山区</option>
                            <option value="24">洪山区</option>
                            <option value="25">东西湖区</option>
                            <option value="26">汉南区</option>
                            <option value="27">蔡甸区</option>
                            <option value="28">江夏区</option>
                            <option value="29">黄陂区</option>
                            <option value="30">新洲区</option>
                          </optgroup> 

                          <optgroup
                            <option value="31">黄石港区</option>
                            <option value="32">西塞山区</option>
                            <option value="33">下陆区</option>
                            <option value="34">铁山区</option>
                            <option value="35">大冶市</option>
                            <option value="36">阳新县</option>
                          </optgroup>

                          <optgroup
                            <option value="37">张湾区</option>
                            <option value="38">茅箭区</option>
                            <option value="39">丹江口市</option>
                            <option value="40">郧县</option>
                            <option value="41">竹山县</option>
                            <option value="42">房县</option>
                            <option value="43">郧西县</option>
                            <option value="44">竹溪县</option>
                          </optgroup>

                          <optgroup
                            <option value="45">沙市区</option>
                            <option value="46">荆州区</option>
                            <option value="47">洪湖市</option>
                            <option value="48">石首市</option>
                            <option value="49">松滋市</option>
                            <option value="50">监利县</option>
                            <option value="51">公安县</option>
                            <option value="52">江陵县</option>
                          </optgroup>

                          <optgroup
                            <option value="53">西陵区</option>
                            <option value="54">伍家岗区</option>
                            <option value="55">点军区</option>
                            <option value="56">猇亭区</option>
                            <option value="57">夷陵区</option>
                            <option value="58">宜都市</option>
                            <option value="59">当阳市</option>
                            <option value="60">枝江市</option>
                            <option value="61">秭归县</option>
                            <option value="62">远安县</option>
                            <option value="63">兴山县</option>
                            <option value="64">五峰镇</option>
                            <option value="65">龙舟坪镇</option>
                          </optgroup>

                          <optgroup
                            <option value="66">襄城区</option>
                            <option value="67">樊城区</option>
                            <option value="68">襄州区</option>
                            <option value="69">老河口市</option>
                            <option value="70">枣阳市</option>
                            <option value="71">宜城市</option>
                            <option value="72">南漳县</option>
                            <option value="73">谷城县</option>
                            <option value="74">保康县</option>
                          </optgroup>

                          <optgroup
                            <option value="75">鄂城区</option>
                            <option value="76">梁子湖区</option>
                            <option value="77">华容区</option>
                          </optgroup>

                          <optgroup
                            <option value="78">东宝区</option>
                            <option value="79">掇刀区</option>
                            <option value="80">钟祥市</option>
                            <option value="81">京山县</option>
                            <option value="82">沙洋县</option>
                          </optgroup>

                          <optgroup
                            <option value="83">孝南区</option>
                            <option value="84">应城市</option>
                            <option value="85">安陆市</option>
                            <option value="86">汉川市</option>
                            <option value="87">孝昌县</option>
                            <option value="88">大悟县</option>
                            <option value="89">云梦县</option>
                          </optgroup>

                          <optgroup>
                            <option value="90">黄州区</option>
                            <option value="91">麻城市</option>
                            <option value="92">武穴市</option>
                            <option value="93">团风县</option>
                            <option value="94">红安县</option>
                            <option value="95">罗田县</option>
                            <option value="96">英山县</option>
                            <option value="97">浠水县</option>
                            <option value="98">蕲春县</option>
                            <option value="99">黄梅县</option>
                          </optgroup>

                          <optgroup>
                            <option value="100">咸安区</option>
                            <option value="101">赤壁市</option>
                            <option value="102">嘉鱼县</option>
                            <option value="103">通城县</option>
                            <option value="104">崇阳县</option>
                            <option value="105">通山县</option>
                          </optgroup>

                          <optgroup>
                            <option value="106">曾都区</option>
                            <option value="107">广水市</option>
                            <option value="108">随县</option>
                          </optgroup>

                          <optgroup>
                            <option value="109">恩施市</option>
                            <option value="110">利川市</option>
                            <option value="111">建始县</option>
                            <option value="112">巴东县</option>
                            <option value="113">宣恩县</option>
                            <option value="114">咸丰县</option>
                            <option value="115">来凤县</option>
                            <option value="116">鹤峰县</option>
                          </optgroup>

                          <optgroup>
                            <option value="117">天门市</option>
                          </optgroup>

                          <optgroup>
                            <option value="118">仙桃市</option>
                          </optgroup>

                          <optgroup> 
                            <option value="119">潜江市</option>
                          </optgroup>

                          <optgroup>       
                            <option value="120">神农架林区</option>
                          </optgroup>

                          <optgroup>
                            <option value="120">湖北省港航管理局</option>
                          </optgroup>   

                        </select>
                    </div>
                </div>

                <div class="button button_sp_area">
                    <button  onClick="fun()" class="weui_btn weui_btn_plain_default" style="border:2px solid white;background:#ff3d00;color:white;line-height:2;">确认</button>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
</script>
    <script src="js/zepto.min.js"></script>
    <script src="js/router.min.js"></script>
    <script src="js/example.js"></script>
    <script type="text/javascript">
    function double_select(master, slave){        
        var change_slave = function() {  
            var idx = $(master).attr("selectedIndex") + 1;  
            $(slave).children("optgroup").hide();  
            $(slave).children("optgroup:nth-child("+idx+")").show();  
        }        
        $(master).change( change_slave );  
        change_slave();  
    }

    function fun(){
                 var SelectedRadioValue = "";
                 var a=$("#name").val();
                 var b=$("#phone").val();
                 var c=$("#province").val();
                 var d=$("#city").val();
                 SelectedRadioValue = a + " " + b + " " + c + " " + d +" ";
                 var url="RegisterSuccess.aspx?radioValue="+SelectedRadioValue;
                 window.location.href = url;

    };     
    //使用  
    $(function(){  
        double_select("#province", "#city");  
    });  
    </script>
</body>
</html>