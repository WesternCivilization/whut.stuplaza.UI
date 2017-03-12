using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class ImgChange : System.Web.UI.Page
    {
        
 
        public string url1 { get; set; }
        public string url2 { get; set; }
        public string url3 { get; set; }
        public string url4 { get; set; }
        ImgChangeBLL bll = new ImgChangeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                List<T_ImgChange> list = bll.GetList();
                txtInfo1.Text = list[0].C_ImgDes;
                txtInfo2.Text = list[1].C_ImgDes;
                txtInfo3.Text = list[2].C_ImgDes;
                txtInfo4.Text = list[3].C_ImgDes;
                txtUrl1.Text = list[0].C_ImgUrl;
                txtUrl2.Text = list[1].C_ImgUrl;
                txtUrl3.Text = list[2].C_ImgUrl;
                txtUrl4.Text = list[3].C_ImgUrl;
                url1 = list[0].C_ImgUrl;
                url2 = list[1].C_ImgUrl;
                url3 = list[2].C_ImgUrl;
                url4 = list[3].C_ImgUrl;
            }
            
            
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now - new TimeSpan(1, 0, 0);
            Response.Expires = 0;
            Response.CacheControl = "no-cache"; 
                
            
           
            
        }

        protected void txtChange1_Click(object sender, EventArgs e)
        {
            if (fileUpload1.HasFiles)
            {
                HttpPostedFile file = fileUpload1.PostedFile;
                if (Path.GetExtension(file.FileName) == ".jpg"||Path.GetExtension(file.FileName)==".jpeg")
                {   
                    try
                    {
                        img2.ImageUrl = "/frontUI/images/banner/back1.jpg";
                        img3.ImageUrl = "/frontUI/images/banner/back2.jpg";
                        img4.ImageUrl = "/frontUI/images/banner/back3.jpg";
                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                        Graphics graphics = Graphics.FromImage(img);
                        string str = "IMWA";
                        //往画布上画了一个坨字符串。
                        graphics.DrawString(str, new Font("微软雅黑", 30), new SolidBrush(Color.Cornsilk), new PointF(img.Width - (36 * str.Length), img.Height - 40));
                        string path = Request.MapPath("/frontUI/images/banner/back1.jpg");
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        img.Save(path);
                    }
                    catch { throw; }
                    img1.ImageUrl = "/frontUI/images/banner/back1.jpg";
                    //Image1.ImageUrl = "/frontUI/images/banner/back1.jpg";
                }
            }
        }

        protected void txtChange2_Click(object sender, EventArgs e)
        {
            if (fileUpload2.HasFiles)
            {
                HttpPostedFile file = fileUpload2.PostedFile;
                if (Path.GetExtension(file.FileName) == ".jpg" || Path.GetExtension(file.FileName) == ".jpeg")
                {
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                        Graphics graphics = Graphics.FromImage(img);
                        string str = "IMWA";
                        //往画布上画了一个坨字符串。
                        graphics.DrawString(str, new Font("微软雅黑", 30), new SolidBrush(Color.Cornsilk), new PointF(img.Width - (36 * str.Length), img.Height - 40));
                        string path = Request.MapPath("/frontUI/images/banner/back2.jpg");
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        img.Save(path);
                    }
                    catch { throw; }

                    img2.ImageUrl = "/frontUI/images/banner/back2.jpg";
                }
            }
        }

        protected void txtChange3_Click(object sender, EventArgs e)
        {
            if (fileUpload3.HasFiles)
            {
                HttpPostedFile file = fileUpload3.PostedFile;
                if (Path.GetExtension(file.FileName) == ".jpg" || Path.GetExtension(file.FileName) == ".jpeg")
                {
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                        Graphics graphics = Graphics.FromImage(img);
                        string str = "IMWA";
                        //往画布上画了一个坨字符串。
                        graphics.DrawString(str, new Font("微软雅黑", 30), new SolidBrush(Color.Cornsilk), new PointF(img.Width - (36 * str.Length), img.Height - 40));
                        string path = Request.MapPath("/frontUI/images/banner/back3.jpg");
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        img.Save(path);
                    }
                    catch { throw; }

                    img3.ImageUrl = "/frontUI/images/banner/back3.jpg";
                }
            }
        }

        protected void txtChange4_Click(object sender, EventArgs e)
        {
            if (fileUpload4.HasFiles)
            {
                HttpPostedFile file = fileUpload4.PostedFile;
                if (Path.GetExtension(file.FileName) == ".jpg" || Path.GetExtension(file.FileName) == ".jpeg")
                {
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                        Graphics graphics = Graphics.FromImage(img);
                        string str = "IMWA";
                        //往画布上画了一个坨字符串。
                        graphics.DrawString(str, new Font("微软雅黑", 30), new SolidBrush(Color.Cornsilk), new PointF(img.Width - (36 * str.Length), img.Height - 40));
                        string path = Request.MapPath("/frontUI/images/banner/back4.jpg");
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        img.Save(path);
                    }
                    catch { throw; }

                    img4.ImageUrl = "/frontUI/images/banner/back4.jpg";
                }
            }
        }

        protected void txtSubmit_Click(object sender, EventArgs e)
        {
            List<T_ImgChange> list = new List<T_ImgChange>();
            list.Add(new T_ImgChange { C_ImgDes = txtInfo1.Text, C_ImgUrl = txtUrl1.Text,C_ImgId=1 });
            list.Add(new T_ImgChange { C_ImgDes = txtInfo2.Text, C_ImgUrl = txtUrl2.Text,C_ImgId=2 });
            list.Add(new T_ImgChange { C_ImgDes = txtInfo3.Text, C_ImgUrl = txtUrl3.Text,C_ImgId=3 });
            list.Add(new T_ImgChange { C_ImgDes = txtInfo4.Text, C_ImgUrl = txtUrl4.Text ,C_ImgId=4});
            if (bll.UpdateImageInfo(list))
            {
                this.Page.Response.Write("<script>aleet('更新成功')</script>");
            }
        }
    }
}