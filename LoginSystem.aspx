<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSystem.aspx.cs" Inherits="whut.stuplaza.UI.LoginSystem" %>
<!DOCTYPE html>
<html lang="zh-cn">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="renderer" content="webkit">
    <title>学工广场后台登录</title>
    <link rel="stylesheet" href="bkgroundcss/pintuer.css">
    <link rel="stylesheet" href="bkgroundcss/admin.css">
    <script src="frontUI/frontjs/jquery-1.11.3.min.js"></script>
    <script src="bkgroundjs/pintuer.js"></script>
    <link type="image/x-icon" href="/favicon.ico" rel="shortcut icon" />
    <link href="/favicon.ico" rel="bookmark icon" />
</head>
<body>
<div id="web_bg" style="position:absolute; width:100%; height:100%; z-index:-1; border:none;">
    <img style="position:fixed;" src="bkgroundimg/content/background.png" height="100%" width="100%" />
</div>
<div class="container">
    <div class="line">
        <div class="xs6 xm4 xs3-move xm4-move">
            <br /><br />
            <form runat="server" id="form1">
            <div class="panel">
                <div class="panel-head"></div>
                <div class="panel-body" style="padding:30px;">
                    <div class="form-group">
                        <div class="field field-icon-right">
                            <%--<input type="text" class="input" name="admin" placeholder="登录账号" data-validate="required:请填写账号,length#>=5:账号长度不符合要求" />--%>
                            <asp:TextBox ID="admin" runat ="server" CssClass="input"  name="admin" placeholder="登录账号" data-validate="required:请填写账号,length#>=5:账号长度不符合要求"></asp:TextBox>
                            <span class="icon icon-user"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="field field-icon-right">
                            <asp:TextBox ID="password" runat ="server" CssClass="input" TextMode="Password"  name="password" placeholder="登录密码" data-validate="required:请填写密码,length#>=8:密码长度不符合要求"></asp:TextBox>
                            <span class="icon icon-key"></span>
                        </div>
                    </div>
                 
                  
                    <div class="form-group">
                        <div class="field">
                            <h5>请选择对应类型管理员登录</h5>
                            <asp:RadioButtonList ID="rb_admin" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="信息发布者" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="稿件审核员"></asp:ListItem>
                                <asp:ListItem Text="系统管理员"></asp:ListItem>
                            </asp:RadioButtonList>
                            
                            
                        </div>
                    </div>
                    <div class="form-group">
                        <div style="text-align:center;color:#f00"><asp:Label ID="show" runat="server" Text="" Visible="false"><font color="red">*</font></asp:Label>
                    </div>
                        </div>
                </div>
                <div class="panel-foot text-center"><asp:Button  ID="btn_login"  runat="server" cssClass="button button-block bg-main text-big" Text="立即登录后台" OnClick="btn_login_Click"></asp:Button></div>
            </div>
            </form>
            
        </div>
    </div>
</div>

</body>
</html>