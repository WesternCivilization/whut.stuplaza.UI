<%@ Page Title="" Language="C#" MasterPageFile="~/stuplaza_BgIndex.Master" AutoEventWireup="true" CodeBehind="ReviewManuCount.aspx.cs" Inherits="whut.stuplaza.UI.ReviewManuCount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="bkgroundjs/datepick/jquery-1.11.0.min.js"></script>
   
    <link href="bkgroundcss/DateTimePicker.css" rel="stylesheet" />
    <script src="bkgroundjs/DateTimePicker2.js"></script>
    <link href="bkgroundcss/tableStyle.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH4" runat="server">
      <span><a href="default.aspx" >首页</a></span><span><</span><span><a href="#">稿件统计</a></span> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <div class="doc-dd" style="margin-bottom:30px;">
            <p>请选择时间段:</p>
             <span style="margin-left:70px">起始时间:</span><input id="act_start_time" name="act_start_time" type="text" data-field="datetime" value="" placeholder="开始时间>结束时间" title="开始时间>结束时间" style="cursor:pointer;" runat="server"/>
             <span style="margin-left:25px">终止时间:</span><input id="act_stop_time" name="act_stop_time" type="text" data-field="datetime" value="" placeholder="结束时间>开始时间" title="结束时间>开始时间"  style="cursor:pointer;" runat="server"/>            <asp:Button ID="Button1" CssClass="stu_btn" runat="server" Text="查询" OnClick="Button1_Click" />
        </div>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate><table id="tbody" style="margin-left:70px"><tr><th style="width:20%;">学院</th><th style="width:20%;">所选时间段投稿量</th><th style="width:20%;">所选时间段使用量</th><th style="width:20%;">总投稿量</th><th style="width:20%;">总使用量</th></tr></HeaderTemplate>
            <ItemTemplate> 
                <tr><td><%#Eval("学院") %></td><td><%#Eval("月投稿量").ToString().ToLower()==""?"0":Eval("月投稿量") %></td><td><%#Eval("月使用量").ToString().ToLower()==""?"0":Eval("月使用量") %></td><td><%#Eval("总投稿量").ToString().ToLower()==""?"0":Eval("总投稿量") %></td><td><%#Eval("总使用量").ToString().ToLower()==""?"0":Eval("总使用量") %></td></tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
        </form>
 

     <div id="dtBox"></div>
    
 <script type="text/javascript">

     $(document).ready(function () {
         $("#dtBox").DateTimePicker({

             isPopup: false,
             dataFormat: "yyyy-MM-dd",
             dateTimeFormat:"yyyy-MM-dd hh:mm:ss"

         });
     });

		</script>

</asp:Content>
