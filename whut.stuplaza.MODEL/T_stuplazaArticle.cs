using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.stuplaza.MODEL
{
   public class T_stuplazaArticle
    {
       //文章表的model类，对应属性，这里面使用类当属性来模仿主外键关系
       //C_ArticleId, C_ArticleTitle, C_ArticleSector, C_ArticleCategory, C_ArticleTopic, C_ArticleContent, C_ArticlePostStaff, C_ArticleAnnexAddr, C_ArticleTime
        public string ArticleId{ get; set; }
        public string ArticleTitle{ get; set; }
        public string ArticleSector { get; set; }
        public int ArticleCategory { get; set; }
        public T_stuplazaTopic topic { get; set; }
        public string ArticleColumn { get; set; }
        public string ArticleContent { get; set; }
        public string ArticlePostStaff { get; set; }
        public string ArticleAnnexAddr { get; set; }
        public string ArticleTime { get; set; }
    }
}
