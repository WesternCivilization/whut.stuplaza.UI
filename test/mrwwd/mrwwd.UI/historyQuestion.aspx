<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historyQuestion.aspx.cs" Inherits="mrwwd.UI.historyQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WeUI</title>
    <link rel="stylesheet" href="css/weui.css"/>
    <link rel="stylesheet" href="css/example.css"/>
</head>
<body ontouchstart>
    <form id="form1" runat="server">
    <div class="hd">
        <h1 class="page_title">历史题库 </h1>
    </div>
    <div class="bd">
        <div class="weui_cells_title">请选择题库</div>
        <div class="weui_cells weui_cells_access">
            <%=listPage %>
        </div>
    </div>
    </form>
</body>
</html>
