<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSystem.aspx.cs" Inherits="mrwwd.UI.LoginSystem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>每日微问答后台登陆</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_AdminAccount" runat="server" placeholder="登陆账号" name="adminAccount" data-validate="required:请填写账号,length#>=5:账号长度不符合要求" ></asp:TextBox>
        <asp:TextBox ID="txt_Password" runat="server" placeholder="请输入密码" TextMode="Password" name="password" data-validate="required:请填写密码,length#>=6:密码长度不符合要求" ></asp:TextBox>
        <asp:Button ID="login" runat="server" Text="登陆" OnClick="login_Click" />
    </div>
    </form>
</body>
</html>
