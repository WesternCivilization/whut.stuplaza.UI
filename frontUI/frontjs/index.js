	 
/**ͼƬ�ֲ�**/
var $index = 0; //��¼ͼƬ�ֲ���λ��
function slider(){
    var len =$('.ban_slider>ul>li').length;
    if($index<len-1) {
	   $index++;
	   $('.ban_slider>ul>li').eq($index).css('display','block').siblings().css('display','none');
	   $('.ban_cirl>ul>li').eq($index).addClass('show').siblings().removeClass('show');
    }
	else{
	   $index=0;
	   $('.ban_slider>ul>li').eq($index).css('display','block').siblings().css('display','none');
	   $('.ban_cirl>ul>li').eq($index).addClass('show').siblings().removeClass('show');
	}	
}


/***ѡ��л�����****/
function tabOver(ts){
    $("#cont" + ts).siblings().css('display' , 'none');
	$("#cont" + ts).css('display', 'block'); 
}

function tabOut(td){
    $("#cont" + td).css('display' , 'none');
	$("#cont0").css('display', 'block'); 
}

function contOver(cs){
	$("#cont" + cs).siblings().css('display' , 'none');
	$("#cont" + cs).css('display', 'block'); 
	if(cs == 1)  $("#tab" + cs).children().addClass('tzgg_h');
	if(cs == 2)  $("#tab" + cs).children().addClass('xwdt_h');
	if(cs == 3)  $("#tab" + cs).children().addClass('ztzx_h');
	if(cs == 4)  $("#tab" + cs).children().addClass('zdwj_h');
	if(cs == 5)  $("#tab" + cs).children().addClass('fwzn_h');
	if(cs == 6)  $("#tab" + cs).children().addClass('yqlj_h');
}

function contOut(cd){
	$("#cont" + cd).css('display' , 'none');
	$("#cont0").css('display' , 'block');
	if(cd == 1)  $("#tab" + cd).children().removeClass('tzgg_h');	
	if(cd == 2)  $("#tab" + cd).children().removeClass('xwdt_h');
	if(cd == 3)  $("#tab" + cd).children().removeClass('ztzx_h');
	if(cd == 4)  $("#tab" + cd).children().removeClass('zdwj_h');
	if(cd == 5)  $("#tab" + cd).children().removeClass('fwzn_h');
	if(cd == 6)  $("#tab" + cd).children().removeClass('yqlj_h');
}
	 
/****�����ı����***/
function controlOverFlow(){
   for(var i = 1; i<=5; i++){      //����֪ͨ
       var text1 = $("#anno" + i);
	   var str1 = text1.text();
	   var len1 = 50;
	   if(str1.length > len1){
	       text1.text(str1.substring(0 , len1) + "...");
	   }
   }
   for(var j = 1; j<=3; j++){        //����ͷ��
	      var text2 = $("#topline" + j);
	      var str2 = text2.text();
	      var len2 = 85;
	      if(str2.length > len2){
		      text2.text(str2.substring(0 , len2) + "...");
	      }
   }
   for(var k = 1; k<=3; k++){        //ר������
	      var text3 = $("#topic" + k);
	      var str3 = text3.text();
	      var len3 = 110;
	         if(str3.length > len3){
	             text3.text(str3.substring(0 , len3) + "...");
             }
   }
   for (var k = 1; k <= 3; k++) {        //新闻动态
       var text4 = $("#caption" + k);
       var str4 = text4.text();
       var len4 = 27;
       if (str4.length > len4) {
           text4.text(str4.substring(0, len4) + "...");
       }
   }

}	

window.onload = function(){
	var timer = 0;
    timer = setInterval("slider()",4000);   //ͼƬ�Զ��ֲ�
	$('#slider').mouseover(function(e) {
	    clearInterval(timer); //����������ֲ�����ʱ��ֹͣ�Զ�����
	});
	$('#slider').mouseout(function(e) {
	    timer = setInterval("slider()",4000); //������Ƴ��ֲ�����ʱ�������Զ�����
    });
    $('.ban_cirl>ul>li').click(function(e){   //������½ǰ�ťͼƬ�任
	    var index = $(this).index();
        $index = index;
	    $('.ban_slider>ul>li').eq(index).css('display','block').siblings().css('display','none');
	    $(this).addClass('show').siblings().removeClass('show');
    });
    controlOverFlow(); //���ú�����ʵ�ֿ����������
}
