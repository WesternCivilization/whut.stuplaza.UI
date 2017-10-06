using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.MODEL;
using whut.stuplaza.BLL;


namespace whut.stuplaza.UI
{
    public partial class ChangeImage : System.Web.UI.Page
    { 
        ImgChangeBLL bll = new ImgChangeBLL();
        T_ImgChange model1, model2, model3, model4;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {                 //初次加载获取数据库存储的信息
                List<T_ImgChange> list = bll.GetList();
                model1 = list[0];
                model2 = list[1];
                model3 = list[2];
                model4 = list[3];
                Image1.ToolTip = "描述：" + model1.C_ImgDes.ToString() + "；路径：" + model1.C_ImgUrl.ToString();
                Image2.ToolTip = "描述：" + model2.C_ImgDes.ToString() + "；路径：" + model2.C_ImgUrl.ToString();
                Image3.ToolTip = "描述：" + model3.C_ImgDes.ToString() + "；路径：" + model3.C_ImgUrl.ToString();
                Image4.ToolTip = "描述：" + model4.C_ImgDes.ToString() + "；路径：" + model4.C_ImgUrl.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)        //当鼠标点击是，将用户输入传入
        {
            string des = TextBox1.Text;
            string url = TextBox2.Text;
             
            int chooseImg = int.Parse(DropDownList1.SelectedValue);         //获取下拉式菜单选中的值
            string path = "/frontUI/images/banner/back" + chooseImg.ToString() + ".jpg";    //为地址添加一个第一个图片的后缀
            ChangeImagePath(chooseImg, des, url);
            File.Delete(Request.MapPath(path));
            FileUpload1.SaveAs(Request.MapPath(path));
            Response.Redirect("ChangeImage.aspx");
        }


        public bool ChangeImagePath(int chooseImg,string des,string url)
        {
            
          //JiaoTiChangeImg(chooseImg);          //传入选中更改的序号的值
          T_ImgChange model = new T_ImgChange { C_ImgDes = des, C_ImgUrl = url, C_ImgId = chooseImg };    //将相应更改信息赋值给model
          return JiaoTiChangeInfo(model, chooseImg);   
        }


        public void JiaoTiChangeImg(int chooseImg) 
        {
            for (int i = 4; i > chooseImg; i--)
            {
                string path = Request.MapPath("/frontUI/images/banner/back" + (i - 1).ToString() + ".jpg");
                //Request.MapPath(string) :是将string虚拟路径映射为物理路径（asp中Request无此方法) 
                using (FileStream fs = new FileStream(path, FileMode.Open)) //FileMode.Open 指定操作系统应打开现有文件。
                //最简单的构造函数仅仅带有两个参数，即文件名和FileMode枚举值。
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fs);    //将fs（也就i-1图片的）地址传入image
                    // Image.FromStream(fs) 创建 Image 从指定的数据流。

                    if (File.Exists(path.Substring(0, path.LastIndexOf('.') - 1) + i.ToString() + ".jpg"))  //如果要插入这张存在就删掉
                    {                    //Substring获取字符串下标从0开始到.的内容   LastIndexOf从后向前返回.之前的位数这里又捡了1
                        File.Delete(path.Substring(0, path.LastIndexOf('.') - 1) + i.ToString() + ".jpg");
                    }
                    image.Save(Request.MapPath("/frontUI/images/banner/back" + i.ToString() + ".jpg"));    //将前一张的的内容全都给了第四账
                    //image.Save 这会将保存 Image 写入指定的文件或流。
                }
            }
        
        }
        public bool JiaoTiChangeInfo(T_ImgChange model,int chooseImg)
        {
            List<T_ImgChange> list = bll.GetList();
            //list.RemoveAt(3);
            list[chooseImg-1]= model;

            return bll.UpdateImageInfo(list);
        
        }
    }
}