using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.stuplaza.DAL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.BLL
{
   public class ColumnBLL
    {
       ColumnDAL dal = new ColumnDAL();
       //需求：根据父类节点遍历子类节点
       public List<T_stuplazaColumn> GetColListByParent(string parent)
       {
           return DataTableToList(dal.GetColDataTableByParent(parent));
       }
       public List<T_stuplazaColumn> DataTableToList(DataTable tb)
       {
           List<T_stuplazaColumn> list = new List<T_stuplazaColumn>();
           int rowCount = tb.Rows.Count;
           if (rowCount > 0)
           {
               
               for (int i = 0; i < rowCount; i++)
               {
                   T_stuplazaColumn model = new T_stuplazaColumn();
                   if (tb.Rows[i]["C_ColumnId"] != null)
                       model.ColumnId = tb.Rows[i]["C_ColumnId"].ToString();
                   if (tb.Rows[i]["C_ColumnName"] != null)
                       model.ColumnName = tb.Rows[i]["C_ColumnName"].ToString();
                   if (tb.Rows[i]["C_ColumnStatus"] != null)
                       model.ColumnStatus = int.Parse(tb.Rows[i]["C_ColumnStatus"].ToString());
                   if (tb.Rows[i]["C_ColumnContent"] != null)
                       model.ColumnContent = tb.Rows[i]["C_ColumnContent"].ToString();
                   if (tb.Rows[i]["C_ColumnParent"] != null)
                       model.ColumnParent = tb.Rows[i]["C_ColumnParent"].ToString();
                   if (tb.Rows[i]["C_ColumnDelStatus"] != null)
                       model.ColumnDelStatus = int.Parse(tb.Rows[i]["C_ColumnDelStatus"].ToString());
                   list.Add(model);
               }

               
           }
           return list;
       }

       //插入model数据
       public int InsertColumn(T_stuplazaColumn model)
       {
           return dal.InsertColumn(model);
       }
       //获取是否父节点具有子节点
       public int GetRecordByParent(string parent)
       {
           return dal.GetRecordByParent(parent);
       
       }
       //根据id获取兄弟list集合
       public List<T_stuplazaColumn> GetDTSiblingsById(string columnid)
       {
           return DataTableToList(dal.GetDTSiblingsById(columnid));
       }
       //根据id获取model
       public T_stuplazaColumn GetModelById(string columnid)
       {
           return dal.GetModelById(columnid);
       }
       //根据name获取id
       public string GetIdByName(string parent)
       {
           return dal.GetIdByName(parent);
       }
       //根据name获取name
       public bool GetNameByName(string name) {
           return dal.GetNameByName(name);    
       }
       //根据部门名称获取对应栏目名称
       public string GetColumnNameBySector(string sector)
       {
           string str="";
           switch (sector)
           {

               case "学生教育办公室(学生)": str = "思想教育"; break;
               case "学生管理办公室(日常)": str = "学生管理"; break;
               case "学生资助与服务中心(资助)": str = "学生资助"; break;
               case "学生资助与服务中心(住宿、勤工助学)": str = "学生园区"; break;
               case "学生教育办公室(辅导员)": str = "队伍建设"; break;
               case "心理健康教育中心": str = "心理健康"; break;
               case "招生办公室": str = "招生工作"; break;
               case "学生管理办公室(就业)": str = "就业创业"; break;
               case "武装部": str = "国防教育"; break;
               case "团委": str = "理工青年"; break;
               default: break;
           }
           return str;
       }
       //根据一级栏目查询可以插入文件的栏目
       public List<T_stuplazaColumn> GetColumnListByFirstCol(string firstColId)
       {
           return DataTableToList(dal.GetColumnListByFirstCol(firstColId));
       }
       //更新栏目
       public bool Update(T_stuplazaColumn model)
       {
           return dal.Update(model);
       }
       //根据以及栏目获取他的子栏目
       public List<T_stuplazaColumn> GetColumn(string id)
       {
           List<T_stuplazaColumn> list = new List<T_stuplazaColumn>();
           DataTable ColumnTab = dal.GetChildModelById(id);
           if (ColumnTab.Rows.Count > 0)
           {
               for (int i = 0; i < ColumnTab.Rows.Count; i++)
               {
                   T_stuplazaColumn model = new T_stuplazaColumn();
                   model.ColumnId = ColumnTab.Rows[i]["C_ColumnId"].ToString();
                   model.ColumnName = ColumnTab.Rows[i]["C_ColumnName"].ToString();
                   model.ColumnStatus= int.Parse(ColumnTab.Rows[i]["C_ColumnStatus"].ToString());
                   
                   list.Add(model);
               }
           }
           return list;
       }
       //删除栏目
       public bool delete(string id)
       {
           ColumnDAL dal = new ColumnDAL();
           return dal.Delete(id);
       }
       public List<T_stuplazaArticle> GetListByColumn(int pageIndex, int pageSize, string columnId, out int total)
       {
           ArticleBLL article = new ArticleBLL();
           return article.DataTableToList(dal.GetListByColumn(pageIndex,pageSize,columnId,out total));
       }
    }
}
