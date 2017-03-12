<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="whut.stuplaza.UI.AddArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/default.css" rel="stylesheet" />
    <link href="bkgroundcss/uploadify.css" rel="stylesheet" />
    <link href="bkgroundcss/DateTimePicker.css" rel="stylesheet" /> 
    <script src="bkgroundjs/datepick/jquery-1.11.0.min.js"></script>
    <script src="bkgroundjs/uploadify/jquery.uploadify.v2.1.0.min.js"></script>
    <script src="bkgroundjs/uploadify/swfobject.js"></script>
    <!--旧版文本编辑器
    <script src="bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script src="bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
    -->
    <!--引入Ueditor配置文件  -->
    <script type="text/javascript" src="plugin/Ueditor/ueditor.config.js"></script>
    <!--引入Ueditor编辑器-->
    <script type="text/javascript" src="plugin/Ueditor/ueditor.all.min.js"></script>

    <script src="bkgroundjs/DateTimePicker2.js"></script>
    <style type="text/css">
        #ArtileForm {
            margin-left: 30px;
        }
        input[name=txtTitle]
        {
            width:200px;
            height:22px;
            border:1px solid #317eb4;
            margin:6px 10px;
            float: left;  
        }
        select
        {
            width: 200px;
    height: 28px;
    font-size: 14px;
    border:1px solid #317eb4;
    margin:6px 10px;
        }
        option
{
    font-size: 14px;
}
.des
{
    display:inline;
    float:left;
    font-size:14px;
    height: 26px;
}
.show_article {
    position: relative;
    top: -244px;
    left: 620px;
    width: 200px;
    height: 220px;
    border:1px solid rgb(0, 0, 0);
    display:none;
}
.show_article p:first-child {
    text-align:center;
    margin: 0 auto;
    border-bottom:1px dotted rgb(0,0,0);
    margin-bottom:5px;
}
.show_article p {
    text-align:center;
    padding:5px;
}
</style>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
    <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowArticle.aspx">文章管理</a></span><span><</span><span><a href="#">添加文章</a></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <div id="box" style="width:auto; height:auto; margin-left:60px;">
        <form id="ArtileForm" method="post" action="ArticlePostHandle.ashx">
    
    <p style="font-size:14px;width:auto;height:34px;line-height:34px;padding:0;margin-bottom:10px"><span class="des">文章填写标题：</span><input type="text" name="txtTitle"/></p>
             <p>   <span class="des">文章所属类别：</span><select name="txtCategory">
                 <option value="1">通知公告</option>
                 <option value="2">新闻</option>
                 <option value="3">服务指南</option>
                  </select></p>
             <p style="font-size:14px;width:auto;height:34px;line-height:34px;padding:0;margin-bottom:10px"><span class="des">文章所属专题:</span><select name="txtTopic">

                         </select></p>
             <div class="column_Content" style="margin-bottom:10px"><span class="des">文章所属栏目:</span><select name="txtcolumn">

                         </select><span class="advice" style="color:red;font-size:12px;">(*若选择不设置栏目，则本文章不会显示在您的栏目中，仅在首页标签中显示) </span></div>
            <p><span style="font-size:14px;">文章发布时间:</span><input id="act_start_time" name="act_start_time" type="text" data-field="datetime" value="" placeholder="发布时间" title="发布时间" style="cursor:pointer;"/></p>
            <div id="datetime"></div>
            <asp:Label ID="Label1" runat="server" Text="(*若要在文章中添加图片，请尽量居中放置，以免影响文章布局)" ForeColor="Red"></asp:Label>  
        <textarea id="txtcontent" name="txtcontent" style="width:750px;height:300px"></textarea>
            <!--实例化编辑器-->
        <script type="text/javascript">
                var ue = UE.getEditor('txtcontent');
            </script>
        


    
    <p class="show_btn" style="background-color:#8193f8;cursor:pointer;width:600px;height:20px;line-height:17px;margin-top:20px;text-align:center">附件：选择文件（可选）</p>
    <div class="show_annex">
        
        <div id="fileQueue"></div>
        
        <input type="file" name="uploadify" id="uploadify" value="浏览"/>
       <input type="hidden" id="name" name="txtAnnex"/>
    
      <p>
      <a href="javascript:$('#uploadify').uploadifyUpload()" runat="server" id="href" style="margin-right:6px">上传</a><span>|</span>
      <a href="javascript:$('#uploadify').uploadifyClearQueue()" style="margin-right:6px;">取消上传</a>
          <span style="color:red">(*点击BROWSE选择上传文件，选择文件后别忘了点击上传哦！)</span>
      </p>
    </div>
  
    <p style="font-size:14px;width:auto;height:34px;line-height:34px;padding:0;margin-bottom:10px"><input type="submit" id="txtbtn" value="提交" class="stu_btn"/></p>
     <div class="show_article">
         <p>已上传的文件</p>
     </div>
    </form>
    </div>
    <script>
        $(document).ready(function () {
            $("#datetime").DateTimePicker({

                isPopup: false,
                dataFormat: "yyyy-MM-dd",
                dateTimeFormat: "yyyy-MM-dd hh:mm:ss"

            });
        });
    </script>
     <script type="text/javascript">
         $(function () {
             InitialTopicSelect();
             InitialColumnAdvice();
             $(".show_btn").click(function () {
                 $(".show_annex").toggle("500");

             });

         })
         //初始化下拉列表专题
         function InitialTopicSelect() {
             $.ajax({
                 url: "loadAllTopic.ashx",
                 dataType: "json",
                 success: function (data) {
                     str = "<option value='0'>不设置专题</option>";
                     for (var key in data) {
                         str += "<option value=" + data[key].TopicId + ">" + data[key].TopicTitle + "</option>";
                     }
                     $("select[name='txtTopic']").append(str);
                 }


             });


         }
         //初始化提示
         function InitialColumnAdvice()
         {
             $.ajax({
                 url: 'InitialColumnAdvice.ashx',
                 type: 'get',
                 dataType: 'json',
                 success: function (data)
                 {
                     str = "<option value='00000000'>不设置栏目</option>";
                     for (var key in data) {
                         str += "<option value=" + data[key].ColumnId + ">" + data[key].ColumnName + "</option>";
                     }
                     $("select[name='txtcolumn']").append(str);
                 }

             })
         }
  
         $(document).ready(function () {
             var s = "";
             $("#uploadify").uploadify({
                 'uploader': 'bkgroundjs/uploadify/uploadify.swf',
                 'script': 'ArticleUploadHander.ashx',
                 'cancelImg': 'bkgroundjs/uploadify/cancel.png',
                 'folder': 'ArticleUploadFile',
                 'queueID': 'fileQueue',
                 'auto': false,
                 'multi': true,
                 'fileDesc': '请选择word,pdf,excel,image或压缩文件',
                 'fileExt': '*.doc;*.pdf;*.rar;*.xsl;*.xslx;*.docx;*.jpg;*.jpeg;*.bmp;*.png;*.gif;*.zip;',
                 'sizeLimit': 20971520,
                 'onComplete': function (event, queueId, fileObj, response, data) {
                     s += fileObj.name + ",";
                     $("#name").val(s.substring(0, s.length - 1));
                     $(".show_article").css("display","block").append("<p>"+fileObj.name+"</p>");
                     alert("文件上传成功！");
                 }
             });
         });
        </script>

</asp:Content>
