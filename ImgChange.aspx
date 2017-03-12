<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ImgChange.aspx.cs" Inherits="whut.stuplaza.UI.ImgChange"  EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #imgUpload {
            margin-left: 200px;
        }
        .imgTitle 
        {
            font-size:18px;
            width:570px;
            text-align:center;
            
        }
        .imgInfoContain 
        {
            width:570px;
            height:220px;
        }
        
            .imgInfoContain h1 
            {
                font-size:16px;
            }
            .imgInfoContain ul 
            {
                width:240px;
                float:left;
                margin-left:20px;
                margin-top:2px;
            }
            .imgInfoContain li 
            {
                margin-bottom:6px;
            }
            .imgInfoContain div 
            {
                width:300px;
                float:right;  
                border:1px solid #808080;
                
            }
            .imgInfoContain .btn_change 
            {
                width:200px;
                height:35px;
                background-color:#318df3;
                font-size:16px;
                -moz-border-radius: 6px;
	            -webkit-border-radius: 6px;
                color:#fff;
                
            }
                .imgInfoContain .btn_change:visited
                {
                    background-color:#2981e4;
                    transition:all ease-in-out 0.5s;
	                -moz-box-shadow: 0 1px 3px rgba(0,0,0,0.6);
	                -webkit-box-shadow: 0 1px 3px rgba(0,0,0,0.6);
	                text-shadow: 0 -1px 1px rgba(0,0,0,0.25);
	                border-bottom: 1px solid rgba(0,0,0,0.25);
	                position: relative;
                }
                .imgInfoContain .btn_change:hover {background-color: #2575cf;}
        .btn_sub 
        {
            margin-top:10px;
            width:300px;
            height:35px;
            font-size:15px;
        }
        h1 {
display: block;
font-size: 2em;
-webkit-margin-before: 0em;
-webkit-margin-after: 0em;
-webkit-margin-start: 0px;
-webkit-margin-end: 0px;
font-weight: bold;
}

    </style>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
  首页大图更换
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="imgUpload" enctype="multipart/form-data" runat="server">
        <h1 class="imgTitle">图片大图更换</h1>
        <div class="imgInfoContain">
            
            <h1>第一张图片信息修改</h1>
            <ul>
            <li><span>图片描述信息</span><asp:TextBox ID="txtInfo1" runat="server"></asp:TextBox></li>
            <li><span>图片指向路径</span><asp:TextBox ID="txtUrl1" runat="server"></asp:TextBox></li>
                <li><span>请上传图片：</span><asp:FileUpload ID="fileUpload1" runat="server" /></li>
                
            
            <li><asp:Button ID="txtChange1" runat="server" Text="替换" CssClass="btn_change" OnClick="txtChange1_Click"/></li>
                </ul>
            <div>
            <span>预览区域</span><a href="<%=url1 %>"><asp:Image ID="img1" ImageUrl="/frontUI/images/banner/back1.jpg" Width="295" Height="101" runat="server"/>
                <%--<img src="<%=string1 %>" width="295" height="101"/>--%></a>
            
                </div>
        </div>
        <div class="imgInfoContain">
            <h1>第二张图片信息修改</h1>
            <ul>
            <li><span>图片描述信息</span><asp:TextBox ID="txtInfo2" runat="server"></asp:TextBox></li>
            <li><span>图片指向路径</span><asp:TextBox ID="txtUrl2" runat="server"></asp:TextBox></li>
                <li><span>请上传图片：</span><asp:FileUpload ID="fileUpload2" runat="server" /></li>
                
            
            <li><asp:Button ID="txtChange2" runat="server" Text="替换" CssClass="btn_change" OnClick="txtChange2_Click"/></li>
                </ul>
            <div>
            <span>预览区域</span><a href="<%=url2 %>"><asp:Image ID="img2" ImageUrl="/frontUI/images/banner/back2.jpg" Width="295" Height="101" runat="server"/></a>
            
                </div>
              
        </div>
        <div class="imgInfoContain">
            <h1>第三张图片信息修改</h1>
            <ul>
            <li><span>图片描述信息</span><asp:TextBox ID="txtInfo3" runat="server"></asp:TextBox></li>
            <li><span>图片指向路径</span><asp:TextBox ID="txtUrl3" runat="server"></asp:TextBox></li>
                <li><span>请上传图片：</span><asp:FileUpload ID="fileUpload3" runat="server" /></li>
                
            
            <li><asp:Button ID="txtChange3" runat="server" Text="替换" CssClass="btn_change" OnClick="txtChange3_Click"/></li>
                </ul>
            <div>
            <span>预览区域</span><a href="<%=url3 %>"><asp:Image ID="img3" ImageUrl="/frontUI/images/banner/back3.jpg" Width="295" Height="101" runat="server"/></a>
            
                </div>
        </div>
        <div class="imgInfoContain">
           <h1>第四张图片信息修改</h1>
            <ul>
            <li><span>图片描述信息</span><asp:TextBox ID="txtInfo4" runat="server"></asp:TextBox></li>
            <li><span>图片指向路径</span><asp:TextBox ID="txtUrl4" runat="server"></asp:TextBox></li>
                <li><span>请上传图片：</span><asp:FileUpload ID="fileUpload4" runat="server" /></li>
                
            
            <li><asp:Button ID="txtChange4" runat="server" Text="替换" CssClass="btn_change" OnClick="txtChange4_Click"/></li>
                </ul>
            <div>
            <span>预览区域</span><a href="<%=url4 %>"><asp:Image ID="img4" ImageUrl="/frontUI/images/banner/back1.jpg" Width="295" Height="101" runat="server"/></a>
            
                </div>
        </div>
        <p class="submit_p"><asp:Button ID="txtSubmit" runat="server" Text="提交信息修改" CssClass="btn_sub" OnClick="txtSubmit_Click"/></p>
    </form>
    <script type="text/javascript">
        $(":file").change(function () {
            //alert("change");
            //alert($(this).val());
            var fileName = $(this).val();
            var ext = fileName.substr(fileName.lastIndexOf('.'));
            if (ext == ".jpeg" || ext == ".jpg") {
                return true;
            } else {
                $(this).val("");
                alert("只能选择后缀名为.jpg的图片");
            }
        });
        </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>