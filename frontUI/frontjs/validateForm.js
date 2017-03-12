///这是验证提交表单的正则
$(function () { 
$("input[name='title']").blur(function () {
    var title = $(this).val();
    if (title=="") {   //如果没有匹配到，那么就错误
        $(this).next().html("* <font color='red'>标题栏不能为空!</font>");
        return false;
    }
    else
        $(this).next().html("");
});
$("input[name='author']").blur(function () {
    var author = $(this).val();
    if (!/[\u4E00-\u9FA5]{2,5}(?:·[\u4E00-\u9FA5]{2,5})*/.test(author)) {   //如果没有匹配到，那么就错误
        $(this).next().html("* <font color='red'>请填写您正确的中文名字</font>");
        return false;
    }
    else
        $(this).next().html("");
});
$("input[name='phone']").blur(function () {
    var phone = $(this).val();
    if (!/[1][3-9]\d{9}/.test(phone)) {   //如果没有匹配到，那么就错误
        $(this).next().html("* <font color='red'>请填写正确的手机号码</font>");
        return false;
    }
    else
        $(this).next().html("");
});
$("input[name='email']").blur(function () {
    var email = $(this).val();
    if (!/\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/.test(email)) {   //如果没有匹配到，那么就错误
        $(this).next().html("* <font color='red'>请填写正确的邮箱</font>");
        return false;
    }
    else
        $(this).next().html("");
});
})
