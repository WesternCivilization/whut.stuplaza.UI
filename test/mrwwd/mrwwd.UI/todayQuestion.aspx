<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todayQuestion.aspx.cs" Inherits="mrwwd.UI.todayQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>今日题库</title>
    <link rel="stylesheet" href="css/weui.css" />
    <link rel="stylesheet" href="css/example.css" />
</head>
<body ontouchstart>

    <form id="form1" runat="server">
        <div class="container">
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
                            <input type="radio" class="weui_check" name="radio1" id="x11">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x12">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer12 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x12" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x13">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer13 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio1" id="x13">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x14">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer14 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x14" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p>本题答案：<%=Answer01 %></p>
                            </div>
                            <div class="weui_cell_ft">
                                您的答案：<%=UserAnswer01 %>
                            </div>
                        </div>
                    </div>

                </div>


                <!--单选选项12-->
                <div class="weui_cells_title"><%=Ques2 %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x21">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer21 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x21">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x22">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer22 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x22" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x23">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer23 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x23">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x24">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer24 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x24" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                </div>

                <div class="weui_cells_title">答案</div>
                <div class="weui_cells">
                    <div class="weui_cell">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p>本题答案：<%=Answer02 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            您的答案：<%=UserAnswer02 %>
                        </div>
                    </div>
                </div>

            </div>
            <div class="weui_cells">
                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>党章党史</p>
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
                            <input type="radio" class="weui_check" name="radio1" id="x31">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x32">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer32 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x32" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x33">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer33 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio1" id="x33">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x34">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer34 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x34" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                </div>


                <div class="weui_cells_title">答案</div>
                <div class="weui_cells">
                    <div class="weui_cell">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p>本题答案：<%=Answer03 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            您的答案：<%=UserAnswer03 %>
                        </div>
                    </div>
                </div>


                <!--单选选项12-->
                <div class="weui_cells_title"><%=Ques4 %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x41">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer41 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x41">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x42">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer42 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x42" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x43">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer43 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x43">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x44">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer44 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x44" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                </div>
            </div>

            <div class="weui_cells_title">答案</div>
            <div class="weui_cells">
                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>本题答案：<%=Answer04 %></p>
                    </div>
                    <div class="weui_cell_ft">
                        您的答案：<%=UserAnswer04 %>
                    </div>
                </div>
            </div>

            <div class="weui_cells">
                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>行业相关问答</p>
                    </div>
                </div>


                <!--单选选项11-->
                <div class="weui_cells_title"><%=Ques5 %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x51">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer51 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio1" id="x51">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x52">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer52 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x52" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x53">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer53 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio1" id="x53">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x54">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer54 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x54" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                </div>

                <div class="weui_cells_title">答案</div>
                <div class="weui_cells">
                    <div class="weui_cell">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p>本题答案：<%=Answer05 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            您的答案：<%=UserAnswer05 %>
                        </div>
                    </div>
                </div>


                <!--单选选项12-->
                <div class="weui_cells_title"><%=Ques6 %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x61">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer61 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x61">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x62">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer62 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x62" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x63">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer63 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x63">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>
                    <label class="weui_cell weui_check_label" for="x64">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=Answer64 %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x64" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p>本题答案：<%=Answer06 %></p>
                            </div>
                            <div class="weui_cell_ft">
                                您的答案：<%=UserAnswer06 %>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class=" bd spacing">
                <div class="weui_progress">
                    <div class="weui_progress_bar">
                        <div class="weui_progress_inner_bar js_progress" style="width: 0%;"></div>
                    </div>
                    <a href="javascript:;" class="weui_progress_opr">
                        <i class="weui_icon_cancel"></i>
                    </a>
                </div>

                <div class="weui_btn_area home">
                    <a href="TodayHaveDone.html" class="weui_btn weui_btn_plain_default ">返回</a>
                </div>
            </div>
        </div>
    </form>

        <script src="js/zepto.min.js"></script>
    <script src="js/router.min.js"></script>
    <script src="js/example.js"></script>
</body>
</html>
