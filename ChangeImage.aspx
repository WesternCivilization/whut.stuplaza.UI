<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ChangeImage.aspx.cs" Inherits="whut.stuplaza.UI.ChangeImage"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imgContainer img 
        {
            margin-left:10px;
            border:solid 2px #808080;
            margin-top:20px;
        }
        #imgTitle 
        {
            text-align:center;
            margin-top:100px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH2" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH4" runat="server">
     <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">首页大图管理</a></span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH1" runat="server">
    <div>
        <form id="form1" runat="server">
            <p>描述文本：<asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></p>
            <p>图片超链接地址：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
           <asp:Label ID="lbl_Show" runat="server"  ForeColor="Red" Text="(超链接不用写http://头)"></asp:Label>
            </p>
            <p>选择要插入的图片位置：<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="4" Text="4"></asp:ListItem>
            </asp:DropDownList></p> <asp:Label ID="Label1" runat="server"  ForeColor="Red" Text="(您上传的图片分辨率最好为990*340)"></asp:Label>
            <p>选择图片路径：<asp:FileUpload ID="FileUpload1" runat="server" /></p>
            <p><asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" /></p>
            <h3 id="imgTitle">缩略图预览效果如下(鼠标悬浮查看详情)</h3>
            <div class="imgContainer">
                <table>
                   <tr>
                 <td><asp:Image ID="Image1" runat="server"  ImageUrl="/frontUI/images/banner/back1.jpg" Width="198" Height="68"/></td>
                 <td><asp:Image ID="Image2" runat="server" ImageUrl="/frontUI/images/banner/back2.jpg" Width="198" Height="68"/></td>
                 <td><asp:Image ID="Image3" runat="server" ImageUrl="/frontUI/images/banner/back3.jpg" Width="198" Height="68"/></td>
                 <td><asp:Image ID="Image4" runat="server" ImageUrl="/frontUI/images/banner/back4.jpg" Width="198" Height="68"/></td>
                 </tr>
                    <tr>
                        <td> 序号1</td> <td>序号2</td><td>序号3</td><td>序号4</td>    
                    </tr>
                </table>
               <div>
                   <asp:Label ID="Label2" runat="server" Text="(*如果无法查看预览效果，请点击刷新！)" ForeColor="Red"></asp:Label></div>
            </div>
            
            </form>
        </div>
</asp:Content>
