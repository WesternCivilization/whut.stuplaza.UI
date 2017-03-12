using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using whut.stuplaza.DAL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.BLL
{
    public class ArticleBLL
    {
        DAL.ArticleDAL dal = new DAL.ArticleDAL();
        /// <summary>
        /// 业务逻辑层添加model方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertArticle(T_stuplazaArticle model)
        {
            ArticleDAL dal = new ArticleDAL();
            return dal.Insert(model);
        
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_stuplazaArticle model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }
        //根据部门获取列表
        public List<T_stuplazaArticle> GetListBySector(int pageIndex, int pageSize, string sector,int category, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, category,out total));
        }


        /// <summary>
        /// 根据查询的条数得到新闻通知的集合
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<T_stuplazaArticle> GetNoticeModelListByNum(int total,int category)
        {
          return  DataTableToList(dal.GetNoticeDateTableByNum(total,category));
        
        }

        public List<T_stuplazaArticle> DataTableToList(DataTable table)
        {
            List<T_stuplazaArticle> list = new List<T_stuplazaArticle>();
            int rowCount = table.Rows.Count;
            if (rowCount > 0)
            {
                T_stuplazaArticle model;
                for(int i=0;i<rowCount;i++)
                {

                    model = dal.DataRowToModel(table.Rows[i]);
                    if (model != null)
                        list.Add(model);
                
                }
                
            
            }
            return list;
        
        }
        public T_stuplazaArticle GetArticleById(string id)
        {
            return dal.GetArticleById(id);
        }

        //根据日期时间模糊查询获取编号
        public string GetIdByTime(string dateTime)
        {
            T_stuplazaArticle AricleModel = new T_stuplazaArticle();
            DataTable articl = dal.GetIdByTime(dateTime);
            string str = null;
            if (articl.Rows.Count == 0)
            {
                str = dateTime + "001";
            }
            else { 
               AricleModel.ArticleId=articl.Rows[0]["C_ArticleId"].ToString().Trim();
               int  strId=Int32.Parse(AricleModel.ArticleId.Substring(8,3))+1;
                
                if(strId <=9 && strId >=0)
                {
                    str = dateTime + "00" + strId.ToString().Trim();
                }
                else if(strId>=10 && strId <=99){
                  str=dateTime+"0"+strId.ToString().Trim();
                }
                else if(strId>=100 && strId <=999){
                   str=dateTime+strId.ToString().Trim();
                }
                else if(strId >=1000 && strId <=9999)
                {
                   str=dateTime.Substring(2,6)+"0"+strId.ToString().Trim();
                }
                else
                {
                    str = dateTime.Substring(2, 6) + strId.ToString().Trim();
                }
            }
            return str;
        
        }
        
        //根据栏目id获取文章list集合
        public List<T_stuplazaArticle> GetListByColId(string columnid)
        {
            DataTable tb = new DataTable();
            tb = dal.GetListByColId(columnid);
            List<T_stuplazaArticle> list = new List<T_stuplazaArticle>();
            if (tb.Rows.Count > 0)
            {

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    T_stuplazaArticle model = new T_stuplazaArticle();
                    if (tb.Rows[i]["C_ArticleId"] != null && tb.Rows[i]["C_ArticleId"].ToString() != "")
                    {
                        model.ArticleId = tb.Rows[i]["C_ArticleId"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleTitle"] != null)
                    {
                        model.ArticleTitle = tb.Rows[i]["C_ArticleTitle"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleSector"] != null)
                    {
                        model.ArticleSector = tb.Rows[i]["C_ArticleSector"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleCategory"] != null)
                    {
                        model.ArticleCategory = int.Parse(tb.Rows[i]["C_ArticleCategory"].ToString());
                    }
                    if (tb.Rows[i]["C_ArticleContent"] != null)
                    {
                        model.ArticleContent = tb.Rows[i]["C_ArticleContent"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleColumn"] != null && tb.Rows[i]["C_ArticleColumn"].ToString() != "")
                    {
                        
                        model.ArticleColumn= tb.Rows[i]["C_ArticleColumn"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleTopic"] != null && tb.Rows[i]["C_ArticleTopic"].ToString() != "")
                    {
                        model.topic = new T_stuplazaTopic();
                        model.topic.TopicId = int.Parse(tb.Rows[i]["C_ArticleTopic"].ToString());
                    }
                    if (tb.Rows[i]["C_ArticlePostStaff"] != null)
                    {
                        model.ArticlePostStaff = tb.Rows[i]["C_ArticlePostStaff"].ToString();
                    }
                    if (tb.Rows[i]["C_ArticleAnnexAddr"] != null)
                    {
                        model.ArticleAnnexAddr = tb.Rows[i]["C_ArticleAnnexAddr"].ToString();
                    }
                    model.ArticleAnnexAddr = "0";
                    if (tb.Rows[i]["C_ArticleTime"] != null)
                    {
                        DateTime time = DateTime.Parse(tb.Rows[i]["C_ArticleTime"].ToString());
                        model.ArticleTime = time.ToString("yyyy-MM-dd");
                        //model.ArticleTime = Convert.ToDateTime((DateTime.Parse(row["C_ArticleTime"].ToString()).ToShortDateString().ToString()));
                    }
                    list.Add(model);
                }
            }
            return list;
        }

        ////获取文章内容中有图片标签的list
        public List<T_stuplazaArticle> GetListByContent()
        {
            List<T_stuplazaArticle> list= DataTableToList(dal.GetListByContent());
            Regex re = new Regex(@"<img[\b\t\s\n]*[^<>]*[\b\t\s\n]*src=['""]/ArticleContentFile.*?['""][^<>]*?/>");
            foreach (var model in list)
            {
                Match mar = re.Match(model.ArticleContent);
                model.ArticleContent = mar.Value;
            }
            return list;

        }
        ///根据起始记录和终止记录和文章类型获取list集合
        public List<T_stuplazaArticle> GetListByIndexCategory(int beginIndex, int endIndex, int cateGory)
        {
            return DataTableToList(dal.GetListByIndexCategory(beginIndex, endIndex, cateGory));
        }
        //根据查询的附件字符串解析附件地址
        public string[] GetAnnexAddrByAnnex(string annex)
        {
            
            string[] sp = null;
            
            if (annex.IndexOf(',') > 0)
            {  sp = annex.Split(','); }
            else
                sp=new string[]{annex};

            for (int i = 0; i < sp.Length; i++)
            {
                string downloadPath = "/ArticleUploadFile/";
                FileTypeExt type = CheckFileExt(sp[i]);
                switch (type)
                {
                    case FileTypeExt.doc: downloadPath += "doc" + "/"; break;
                    case FileTypeExt.img: downloadPath += "img" + "/"; break;
                    case FileTypeExt.pdf: downloadPath += "pdf" + "/"; break;
                    case FileTypeExt.rar: downloadPath += "rar" + "/"; break;
                    default: downloadPath += "xsl" + "/"; break;
                }
                sp[i] = downloadPath + sp[i];
            }
            return sp;
        }
        //检测附件的扩展名
        public FileTypeExt CheckFileExt(string str)
        {
            if (str != null)
            {
                //获取文件的后缀名
                string ext = Path.GetExtension(str).ToLower();
                if (ext.Equals(".doc") || ext.Equals(".docx"))
                {
                    return FileTypeExt.doc;
                }
                else if (ext.Equals(".xsl") || ext.Equals(".xslx"))
                {
                    return FileTypeExt.xsl;
                }
                else if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png") || ext.Equals("gif"))
                {
                    return FileTypeExt.img;
                }
                else if (ext.Equals(".pdf"))
                {
                    return FileTypeExt.pdf;
                }
                else
                    return FileTypeExt.rar;
            }
            return 0;



        }
        /// <summary>
        /// 枚举
        /// </summary>
        public enum FileTypeExt
        {
            doc,
            pdf,
            xsl,
            rar,
            img
        }
        public List<T_stuplazaArticle> GetListByTopic(int pageIndex, int pageSize, int topicid, out int total)
        {
            return DataTableToList(dal.GetListByTopic(pageIndex,pageSize,topicid,out total));
        }
        //根据类型分页
        public List<T_stuplazaArticle> GetListByCategory(int pageIndex, int pageSize, int category, out int total)
        { 
            return DataTableToList(dal.GetListByCategory(pageIndex, pageSize, category,out total));
        }
        //根据部门获取分页
        public List<T_stuplazaArticle> GetListBySector(int pageIndex, int pageSize, string sector, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, out total));
        
        }
        //根据部门，类型分页
        public List<T_stuplazaArticle> GetListBySectorAndCategory(int pageIndex, int pageSize, string sector, int category, out int total)
        {
            return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector,category, out total));
        }
        //根据标题分页
        public List<T_stuplazaArticle> GetListByTitle(int pageIndex, int pageSize, string title, out int total)
        {
            return DataTableToList(dal.GetListByTitle(pageIndex, pageSize, title, out total));
        }

        //根据部门、标题分页
        public List<T_stuplazaArticle> GetListByTitleAndSector(int pageIndex, int pageSize, string sector,string title, out int total)
        {
            return DataTableToList(dal.GetListByTitleAndSector(pageIndex, pageSize, sector,title, out total));
        }


    }
}
