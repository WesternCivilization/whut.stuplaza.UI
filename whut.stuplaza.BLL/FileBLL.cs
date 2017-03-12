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
   public class FileBLL
    {
       FileDAL dal = new FileDAL();
       //根据所属部门获取List
       public List<T_stuplazaFile> GetListBySector(string sector)
       {
           return DataTableToList(dal.GetDataTableBySector(sector));
       }
       //获取所有文件list
       public List<T_stuplazaFile> GetListleAll() {
           return DataTableToList(dal.GetDataTableAll()); 
       }
       //转化datatable 为list
       public List<T_stuplazaFile> DataTableToList(DataTable tb)
       {
           List<T_stuplazaFile> list=new List<T_stuplazaFile>();
           if (tb.Rows.Count > 0)
           {
               for (int i = 0; i < tb.Rows.Count; i++)
               {
                   T_stuplazaFile model=new T_stuplazaFile();
                   model.FileId = tb.Rows[i]["C_FileId"].ToString();
                   if(tb.Rows[i]["C_FileId"].ToString()!="")
                   model.FileName = tb.Rows[i]["C_FileName"].ToString();
                   if(tb.Rows[i]["C_FileSector"].ToString()!="")
                       model.FileSector=tb.Rows[i]["C_FileSector"].ToString();
                   if(tb.Rows[i]["C_FileTime"]!=null)
                        {
                            DateTime time = DateTime.Parse(tb.Rows[i]["C_FileTime"].ToString());
                            model.FileTime = time.ToString("yyyy-MM-dd");
                        }
                   if (tb.Rows[i]["C_FileSummary"].ToString() != "")
                       model.FileSummary = tb.Rows[i]["C_FileSummary"].ToString();
                   if (tb.Rows[i]["C_FilePath"].ToString() != "")
                       model.FilePath = tb.Rows[i]["C_FilePath"].ToString();
                   if (tb.Rows[i]["C_FileExt"].ToString() != "")
                       model.FileExt = tb.Rows[i]["C_FileExt"].ToString();
                   if (tb.Rows[i]["C_FileDowNum"].ToString() != "")
                       model.FileDowNum = int.Parse(tb.Rows[i]["C_FileDowNum"].ToString());
                   list.Add(model);
               }
               
           }
           return list;
       }

       //插入
       public int Insert(T_stuplazaFile file)
       {
           return dal.Insert(file);
       }
       //根据日期模糊查询获取编号
       public string GetIdByTime(string dateTime)
       {
           T_stuplazaFile fileModel = new T_stuplazaFile();
           DataTable file = dal.GetIdByTime(dateTime);
           string str=null;
           if (file.Rows.Count == 0)
           {
               str = dateTime + "001";
           }
           else {
               fileModel.FileId = file.Rows[0]["C_FileId"].ToString().Trim();
               int strId = Int32.Parse(fileModel.FileId.Substring(8,3))+1;
               if (strId >=10) {
                   str = dateTime + "0" + strId.ToString().Trim(); 
               }
               else if (strId >= 100)
               {
                   str = dateTime + strId.ToString().Trim();
               }
               else {
                   str = dateTime + "00" + strId.ToString().Trim();
               }
           
           }
           return str;

       }
       /// <summary>
       /// 根据获取数目获取记录
       /// </summary>
       /// <param name="total"></param>
       /// <returns></returns>
       public List<T_stuplazaFile> GetPreNumList(int total)
       {
           return DataTableToList(dal.GetPreNumList(total));
       }
       //根据下载次数排列
       public List<T_stuplazaFile> GetListByNumOrderByDow(int num)
       {
           return DataTableToList(dal.GetListByNumOrderByDow(num));
       }
       //根据shijian
       public List<T_stuplazaFile> GetListByTime(int num)
       {
           return DataTableToList(dal.GetListByTime(num));
       }
       ///根据起始记录和终止记录和文章类型获取list集合
       public List<T_stuplazaFile> GetListByIndexCategory(int beginIndex, int endIndex)
       {
           return DataTableToList(dal.GetListByIndexCategory(beginIndex, endIndex));
       }

       //更新下载次数
       public bool UpdateDowNumById(string fileId)
       {
           return dal.UpdateDowNumById(fileId);
       }
       //根据id获取mode
       public T_stuplazaFile GetModelById(string id)
       {
           DataTable tb = dal.GetModelById(id);
           T_stuplazaFile model = new T_stuplazaFile();
           if (tb.Rows.Count > 0)
           {
               
               model.FileId = tb.Rows[0]["C_FileId"].ToString();
               if (tb.Rows[0]["C_FileId"].ToString() != "")
                   model.FileName = tb.Rows[0]["C_FileName"].ToString();
               if (tb.Rows[0]["C_FileSector"].ToString() != "")
                   model.FileSector = tb.Rows[0]["C_FileSector"].ToString();
               if (tb.Rows[0]["C_FileTime"] != null)
               {
                   DateTime time = DateTime.Parse(tb.Rows[0]["C_FileTime"].ToString());
                   model.FileTime = time.ToString("yyyy-MM-dd");
               }
               if (tb.Rows[0]["C_FileSummary"].ToString() != "")
                   model.FileSummary = tb.Rows[0]["C_FileSummary"].ToString();
               if (tb.Rows[0]["C_FilePath"].ToString() != "")
                   model.FilePath = tb.Rows[0]["C_FilePath"].ToString();
               if (tb.Rows[0]["C_FileExt"].ToString() != "")
                   model.FileExt = tb.Rows[0]["C_FileExt"].ToString();
               if (tb.Rows[0]["C_FileDowNum"].ToString() != "")
                   model.FileDowNum = int.Parse(tb.Rows[0]["C_FileDowNum"].ToString());
           }
           return model;
       }
       //分页list
       public List<T_stuplazaFile> GetListByPage(int pageIndex, int pageSize, out int total)
       {
           return DataTableToList(dal.GetListByPage(pageIndex, pageSize, out total));
       }
       public List<T_stuplazaFile> GetListBySector(int pageIndex, int pageSize, string sector, out int total)
       {
           return DataTableToList(dal.GetListBySector(pageIndex, pageSize, sector, out total));
       }


       public bool deleteFile(string id)
       {
           FileDAL dal = new FileDAL();
           return dal.deleteFile(id);
       }
    }
}
