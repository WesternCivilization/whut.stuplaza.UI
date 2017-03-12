<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="AddTopic.aspx.cs" Inherits="whut.stuplaza.UI.AddTopic" EnableEventValidation="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
   <style type="text/css">
   .container{
	   width:450px;
	   height:500px;
	   padding:10px 30px;
	   margin-left:200px;
	   border:1px solid #999;
	   
   }
    .container p{
		width:auto;
		height:auto;
		padding:5px 15px;
		margin:25px 0;
	}
    .col_span{
		display:block;
        float:left;
        font-size:14px;
		width:auto;
        height:auto;
		padding:3px 3px 3px 0;
		margin-right:10px;
	}
	#txt_TopicTitle{
		width:200px;
		height:26px;
        border:1px solid #317eb4;
	}
	#txt_TopicSummary{
		width:200px;
		height:100px;
		border:1px solid #317eb4;
	}
	#lbl_Priority{
		font-size:14px;
		margin-right:10px;		
	}
	 input[type='radio'] {
            width:14px;
            height:14px;
            margin-right:8px;      
        }
	.tip{
		display:block;
		font-size:14px;
		color:#999;
		margin-top:10px;
	}
	#btn_upload{
	    background: #3992d0;
	    display: inline-block;
        width:80px;
        height:30px;
        line-height:30px;
	    color: #fff;
        font-size:14px;
        border-radius:6px;
	    -moz-border-radius: 6px;
	    -webkit-border-radius: 6px;
        -o-border-radius:6px;
	    cursor: pointer;
	    margin-left:140px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
   <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowTopic.aspx">专题管理</a></span><span><</span><span><a href="#">添加专题</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
     <form id="form1" runat="server">
      <div id="container">
          <p><span class="col_span">专题标题：</span>
             <asp:TextBox ID="txt_TopicTitle" runat="server"></asp:TextBox>
              <asp:Label ID="lbl_Show" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
          </p>
          <p><span class="col_span">专题摘要：</span>
             <asp:TextBox ID="txt_TopicSummary" runat="server" TextMode="MultiLine"></asp:TextBox>
          </p>
          <p><asp:Label ID="lbl_Priority" runat="server" Text="专题优先级"></asp:Label>
              <asp:Label ID="lbl_PriorityShow" runat="server"  ForeColor="Red"   Text="（优先级越低越优先显示，同级的按专题名字排序。）"></asp:Label>
                <asp:RadioButtonList ID="rb_Priority" runat="server" RepeatDirection="Horizontal" >
                                <asp:ListItem Text="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="2"></asp:ListItem>
                                <asp:ListItem Text="3"></asp:ListItem>
                                <asp:ListItem Text="4"></asp:ListItem>
                            </asp:RadioButtonList>
          </p>
         <p>
             <asp:FileUpload ID="pic_upload" runat="server" />
             <asp:Label ID="lbl_pic" runat="server"  ForeColor="Red"  Visible="false"></asp:Label><br/>
             <span class="tip" >上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M</span>
         </p>
         <p>
             <asp:Button ID="btn_upload" runat="server"  Text="上传" onclick="btn_upload_Click"/>
         </p>
          <div style="margin:5px; width:300px; height:400px"><asp:Image ID="pic" runat="server"/></div>
          </div>
    </form>
</asp:Content>
