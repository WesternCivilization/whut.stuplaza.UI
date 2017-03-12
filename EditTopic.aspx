<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="EditTopic.aspx.cs" Inherits="whut.stuplaza.UI.EditTopic"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH4" runat="server">
   <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="ShowTopic.aspx">专题管理</a></span><span><</span><span><a href="#">专题编辑</a></span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
      <div>
         <div>
             <p> <asp:Label ID="lbl_Id" runat="server" Text="专题Id"></asp:Label>
             <asp:TextBox ID="txt_Id" runat="server" ReadOnly="true"  BackColor="#cccccc"></asp:TextBox>
         </p>
             <p> <asp:Label ID="lbl_TopicTitle" runat="server" Text="专题标题"></asp:Label>
             <asp:TextBox ID="txt_TopicTitle" runat="server"></asp:TextBox>
         </p>
              <p> <asp:Label ID="lbl_Time" runat="server" Text="添加时间"></asp:Label>
             <asp:TextBox ID="txt_Time" runat="server" ReadOnly="true"  BackColor="#cccccc"></asp:TextBox>
         </p>
          <p><asp:Label ID="lbl_TopicSummary" runat="server" Text="专题摘要"></asp:Label>
               <asp:TextBox ID="txt_TopicSummary" runat="server" TextMode="MultiLine"></asp:TextBox>
          </p>
           <p><asp:Label ID="lbl_PriorityShow" runat="server" Text="优先级"></asp:Label>
               <asp:TextBox ID="txt_PriorityShow" runat="server"></asp:TextBox> 
               <asp:Button ID="btn_PriorityChange" runat="server" Text="更改优先级" OnClick="btn_PriorityChange_Click" />
          </p>
            
             <asp:Panel ID="pl_PriorityChange" runat="server" Visible="false">
               <p><asp:Label ID="lbl_Priority" runat="server" Text="专题优先级"></asp:Label>
                <asp:RadioButtonList ID="rb_Priority" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="1"></asp:ListItem>
                                <asp:ListItem Text="2"></asp:ListItem>
                                <asp:ListItem Text="3"></asp:ListItem>
                                <asp:ListItem Text="4"></asp:ListItem>
                            </asp:RadioButtonList>
             </p>
             </asp:Panel>
         </div>
          <div>
              <p>
               <asp:Label ID="lbl_PicFilePath" runat="server" Text="专题图片路径"></asp:Label>
               <asp:TextBox ID="txt_PicFilePath" runat="server" Width="200"></asp:TextBox> 
              </p>
              <p>
               <asp:Image ID="Image1" runat="server"  Width="198" Height="68"/>
               <asp:Button ID="btn_PicFilePathChange" runat="server" Text="更改图片" OnClick="btn_PicFilePathChange_Click" />
              </p>
              <asp:Panel ID="pl_show" runat="server" Visible="false" > 
              <div><asp:FileUpload ID="pic_upload" runat="server" /><asp:Label ID="lbl_pic" runat="server"  ForeColor="Red"  Visible="false"></asp:Label></div>
              <div style="color:Gray; margin-top:5px; margin-bottom:5px;">上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M</div>
              <div><asp:Button ID="btn_upload" runat="server"  Text="上传" onclick="btn_upload_Click"/></div>
               <div style="margin:5px;"><asp:Image ID="pic" runat="server" /></div>
              </asp:Panel>
              <div>
                  <asp:Button ID="btn_Modify" runat="server" Text="提交更改" OnClick="btn_Modify_Click" />
              </div>
        </div>
        
      </div>
    </form>




</asp:Content>
