//分享到qq空间
function shareToQzone()
{
    var _shareUrl = window.location.href;
    var shareqqzonestring = 'http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url=' + _shareUrl;
    window.open(shareqqzonestring, 'newwindow', 'height=500,width=500,top=100,left=100');
}
//分享新浪微博
function shareToSinaWB() {
    var _shareUrl = window.location.href;
    var sharesinastring = 'http://v.t.sina.com.cn/share/share.php?url=' + _shareUrl;
    window.open(sharesinastring, 'newwindow', 'height=500,width=500,top=100,left=100');
}
//feniangqq
function shareToQQ() {
    var _shareUrl = window.location.href;
    var sharesinastring = 'http://v.t.qq.com/share/share.php?url='+_shareUrl;
    window.open(sharesinastring, 'newwindow', 'height=500,width=500,top=100,left=100');
}