using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;


namespace whut.stuplaza.UI
{
    public partial class AddTopic : System.Web.UI.Page
    {
        TopicBLL bll = new TopicBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            
            }
        }



        protected void btn_upload_Click(object sender, EventArgs e)
        {   
            TopicBLL topic=new TopicBLL();
              string virpath = "";
              Boolean fileOk = false;
            if (pic_upload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (pic_upload.PostedFile.ContentLength < 8192000)
                    {
                        string filepath = "/TopicImage/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        virpath = filepath + pic_upload.FileName;//这是存到服务器上的虚拟路径
                       string  mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                        pic_upload.PostedFile.SaveAs(mappath);//保存图片
                        //显示图片
                        pic.ImageUrl = virpath;
                        //清空提示
                        lbl_pic.Text = "";
                    }
                    else {
                        pic.ImageUrl = "";
                        lbl_pic.Visible =true;
                        lbl_pic.Text = "文件大小超出8M！请重新选择！";
                    }
                }
                else {
                    pic.ImageUrl = "";
                    lbl_pic.Visible = true;
                    lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                }
            }
            else
            {
                pic.ImageUrl = "";
                lbl_pic.Visible = true;
                lbl_pic.Text = "请选择要上传的图片！";
            }


            //将信息存储到数据库
            string topicTitle = txt_TopicTitle.Text.ToString().Trim();
            //标题重复
            if (CheckTopicTitle(topicTitle)) {
                lbl_Show.Visible = true;
                lbl_Show.Text = "(专题已存在，请重新添加!)";
                txt_TopicTitle.Text = " ";
                txt_TopicSummary.Text = "";
            }
              //可以添加
            else{
            string topicTime = DateTime.Now.ToLocalTime().ToString(); 
            string topicSummary = txt_TopicSummary.Text.ToString().Trim();
            int topicPriority = GetPriority();
            string topicFileName = virpath;
            try
            {
                T_stuplazaTopic model = new T_stuplazaTopic();
                model.TopicTitle = topicTitle;
                model.TopicTime = topicTime;
                model.TopicSummary =topicSummary;
                model.TopicPriority = topicPriority;
                model.TopicFileName = topicFileName;
                if (topic.InsertTopic(model)>=0)
                {
                    Response.Redirect("ShowTopic.aspx");
                }
            }
            catch
            {
                throw;
              }
            }
        }
       //检查专题标题是否重复
        public bool CheckTopicTitle(string title) {
            return bll.GetTopicNameByName(title);
        }
      
        //获取优先级
        private int GetPriority()
        {
            if (rb_Priority.SelectedValue == "1") {
                return 1;
            }
            else if (rb_Priority.SelectedValue == "2") {
                return 2;
            }
             else if (rb_Priority.SelectedValue == "3") {
                return 3;
            }
             else{
                return 4;
            }
        }

        /// <summary>
        /// 验证是否指定的图片格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsImage(string str) {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp",".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }

        /// <summary>
        /// 创建一个指定长度的随机salt值
        /// </summary>
        public string CreateSalt(int saltLenght)
        {
            //生成一个加密的随机数
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltLenght];
            rng.GetBytes(buff);
            //返回一个Base64随机数的字符串
            return Convert.ToBase64String(buff);
        }

        
        /// <summary>
        /// 返回加密后的字符串
        /// </summary>
        public string CreatePasswordHash(string pwd, int saltLenght)
        {
            string strSalt = CreateSalt(saltLenght);
            //把密码和Salt连起来
            string saltAndPwd = String.Concat(pwd, strSalt);
            //对密码进行哈希
            string hashenPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
           //转为小写字符并截取前16个字符串
            hashenPwd = hashenPwd.ToLower().Substring(0, 16);
            //返回哈希后的值
            return hashenPwd;


        }
    }
}