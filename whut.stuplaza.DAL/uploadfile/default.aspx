<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="uploadfile._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="JS/jquery.uploadify-v2.1.0/example/css/default.css" rel="stylesheet" type="text/css" />
    <link href="JS/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="JS/jquery.uploadify-v2.1.0/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="JS/jquery.uploadify-v2.1.0/swfobject.js"></script>

    <script type="text/javascript" src="JS/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#uploadify").uploadify({
                'uploader': 'JS/jquery.uploadify-v2.1.0/uploadify.swf',
                'script': 'UploadHandler.ashx',
                'cancelImg': 'JS/jquery.uploadify-v2.1.0/cancel.png',
                'folder': 'UploadFile',
                'queueID': 'fileQueue',
                'auto': false,
                'multi': true,
                'fileDesc': '请选择word,pdf,excel,image或压缩文件',
                'fileExt': '*.doc;*.pdf;*.rar;*.xsl;*.xslx;*.docx;*.jpg;*.jpeg;*.bmp;*.png;*.gif;*.zip;',
                
                'sizeLimit':20971520
            });
        });
    </script>

</head>
<body>
    
    <div id="fileQueue"></div>
       <input type="file" name="uploadify" id="uploadify"/>
    <p>
      <a href="javascript:$('#uploadify').uploadifyUpload()" runat="server" id="href">上传</a>| 
      <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
        

    </p>
    <form method="get" action="UploadHandler.ashx">
        <input type="text" name="txt"/>
        <input type="submit" name="sub" value="提交"/>
        </form>
</body>
</html>
