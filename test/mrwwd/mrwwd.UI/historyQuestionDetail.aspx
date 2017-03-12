<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historyQuestionDetail.aspx.cs" Inherits="mrwwd.UI.historyQuestionDetail" %>

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
        <div class="container" id="container">
            <div class="weui_cells">
                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p><%=questionPublishTime %>题目</p>
                    </div>
                </div>

                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>党章党史</p>
                    </div>
                </div>

                <!--单选选项11-->
                <div class="weui_cells_title"><%=QuesModel1.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x11">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel1.C_QuestionOptionA %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio1" id="x11">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x12">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel1.C_QuestionOptionB %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio1" class="weui_check" id="x12" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x13">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel1.C_QuestionOptionC %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio1" id="x13">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x14">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel1.C_QuestionOptionD %></p>
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
                                <p><%=QuesModel1.C_QuestionAnswer %></p>
                            </div>
                        </div>
                    </div>
                </div>

                <!--单选2-->
                <div class="weui_cells_title"><%=QuesModel1.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x21">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel2.C_QuestionOptionA %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x21">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x22">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel2.C_QuestionOptionB %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x22" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x23">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel2.C_QuestionOptionC %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio2" id="x23">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x24">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel2.C_QuestionOptionD %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio2" class="weui_check" id="x24" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p><%=QuesModel2.C_QuestionAnswer %></p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>党纪党纲</p>
                    </div>
                </div>

                <!--单选3-->
                <div class="weui_cells_title"><%=QuesModel3.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x31">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel3.C_QuestionOptionA %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio3" id="x31">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x32">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel3.C_QuestionOptionB %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio3" class="weui_check" id="x32" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x33">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel3.C_QuestionOptionC %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio3" id="x33">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x34">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel3.C_QuestionOptionD %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio3" class="weui_check" id="x34" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p><%=QuesModel3.C_QuestionAnswer %></p>
                            </div>
                        </div>
                    </div>
                </div>

                <!--单选4-->
                <div class="weui_cells_title"><%=QuesModel4.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x41">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel4.C_QuestionOptionA %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio4" id="x41">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x42">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel4.C_QuestionOptionB %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio4" class="weui_check" id="x42" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x43">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel4.C_QuestionOptionC %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio4" id="x43">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x44">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel4.C_QuestionOptionD %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio4" class="weui_check" id="x44" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p><%=QuesModel4.C_QuestionAnswer %></p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>行业相关</p>
                    </div>
                </div>

                <!--单选5-->
                <div class="weui_cells_title"><%=QuesModel5.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x51">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel5.C_QuestionOptionA %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio5" id="x51">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x52">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel5.C_QuestionOptionB %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio5" class="weui_check" id="x52" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x53">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel5.C_QuestionOptionC %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio5" id="x53">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x54">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel5.C_QuestionOptionD %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio5" class="weui_check" id="x54" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p><%=QuesModel5.C_QuestionAnswer %></p>
                            </div>
                        </div>
                    </div>
                </div>

                <!--单选6-->
                <div class="weui_cells_title"><%=QuesModel6.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x61">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel6.C_QuestionOptionA %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio6" id="x61">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x62">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel6.C_QuestionOptionB %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio6" class="weui_check" id="x62" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <label class="weui_cell weui_check_label" for="x63">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel6.C_QuestionOptionC %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" class="weui_check" name="radio6" id="x63">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>


                    <label class="weui_cell weui_check_label" for="x64">

                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel6.C_QuestionOptionD %></p>
                        </div>
                        <div class="weui_cell_ft">
                            <input type="radio" name="radio6" class="weui_check" id="x64" checked="checked">
                            <span class="weui_icon_checked"></span>
                        </div>
                    </label>

                    <div class="weui_cells_title">答案</div>
                    <div class="weui_cells">
                        <div class="weui_cell">
                            <div class="weui_cell_bd weui_cell_primary">
                                <p><%=QuesModel6.C_QuestionAnswer %></p>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <p>必背问答</p>
                    </div>
                </div>
                <!--问答题-->
                <div class="weui_cells_title"><%=QuesModel7.C_QuestionInfo %></div>
                <div class="weui_cells weui_cells_radio">
                    <label class="weui_cell weui_check_label" for="x71">
                        <div class="weui_cell_bd weui_cell_primary">
                            <p><%=QuesModel7.C_QuestionAnswer %></p>
                        </div>
                        <%--<div class="weui_cell_ft">
		                <input type="radio" class="weui_check" name="radio7" id="x71">
		                <span class="weui_icon_checked"></span>
		            </div>--%>
                    </label>
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
                        <a href="historyQuestion.aspx" class="weui_btn weui_btn_plain_default ">返回</a>
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
