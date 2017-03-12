<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="AddFile.aspx.cs" Inherits="whut.stuplaza.UI.AddFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="bkgroundjs/jquery-1.11.3.min.js"></script>
    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />
    <style type="text/css">
        #fileForm {
            margin-left: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
   <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowFile.aspx">文件管理</a></span><span><</span><span><a href="#">添加文件</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form method="post" action="FileHandle.ashx" enctype="multipart/form-data" id="fileForm" class="row">
        <p><span class="col_span">文件标题：</span><input name="summary" type="text" class="col_input"/></p>
         <p> <span class="col_span"> 请上传文件：</span><input name="files" type="file" id="fileUp" class="col_input"/></p>
                <input type="hidden" name="filename"/>
                 <input type="hidden" name="fileext"/>
                 <input type="hidden" name="filepath"/>
                 <input type="hidden" name="filetime"/>   
        
           <p> <span class="col_span">请点击:</span><input id="btnUpload" name="btn" type="submit" class="stu_btn"/></p>
           <div class="filecontent" style="display:none;"></div>

        
    </form>
    <script type="text/javascript">
       
        </script>
    <script>

     $(":file").change(function () {
                var fileName = $(this).val();
                var ext = fileName.substr(fileName.lastIndexOf('.'));
                if (ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif") {
                    alert("请不要选择图片");
                    return false;
                } else {
                    alert("符合正确的格式");
                }
            });
       
    </script>
</asp:Content>
