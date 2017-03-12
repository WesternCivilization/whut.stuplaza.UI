using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.stuplaza.COMMON;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.DAL
{
   public class FileDAL
    {
       //根据所属部门获取datatable
       public DataTable GetDataTableBySector(string sector)
       {
           string sql = "select * from T_stuplazaFile where C_FileSector=@sector order by C_FileTime desc";
           SqlParameter[] sp = { new SqlParameter("@sector", sector) };
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
       }
       //获取所有文件datatable
       public DataTable GetDataTableAll ()
       {
           string sql = "select * from T_stuplazaFile order by C_FileTime desc";
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
       }

       public DataTable GetModelById(string id)
       {
           string sql = "select * from T_stuplazaFile where C_FileId=@id";
           SqlParameter[] sp = { new SqlParameter("@id", id) };
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text,sp);
       }
       //插入
       public int Insert(T_stuplazaFile file)
       {
           string sql = "insert into T_stuplazaFile values(@id,@name,@time,@sector,@summary,@path,@ext,@num)";
           SqlParameter[] sp ={
                              new SqlParameter("@id",file.FileId),
                              new SqlParameter("@name",file.FileName),
                              new SqlParameter("@time",file.FileTime),
                              new SqlParameter("@sector",file.FileSector),
                              new SqlParameter("@summary",file.FileSummary),
                              new SqlParameter("@path",file.FilePath),
                              new SqlParameter("@ext",file.FileExt),
                              new SqlParameter("@num",file.FileDowNum)
           
                              
                              };
           return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
       }

       //获取编号
       public DataTable GetIdByTime(string dateTime)
       {

           string sql = string.Format("select top(1) *from  T_stuplazaFile where (C_FileId like '{0}%') order by C_FileTime desc", dateTime);
           return  SqlHelper.ExecuteDataTable(sql, CommandType.Text);

       }
       //根据时间排列获取前几条
       public DataTable GetPreNumList(int total)
       {
           string sql = "select top " + total + " * from T_stuplazaFile order by C_FileTime desc";
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
       }
       //根据下载次数排列获取前几条数据
       public DataTable GetListByNumOrderByDow(int num)
       {
           string sql = "select top " + num + " * from T_stuplazaFile order by C_FileDowNum desc";
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
       }
       //根据时间排列获取最近的数条数据
       public DataTable GetListByTime(int num)
       {
           string sql = "select top " + num + " * from T_stuplazaFile order by C_FileTime desc";
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
       }
       ///根据起始记录和终止记录获取list集合
       public DataTable GetListByIndexCategory(int beginIndex, int endIndex)
       {
           string sql = "select top " + endIndex + " * from T_stuplazaFile where C_FileId not in (select top " + beginIndex + " C_FileId from T_stuplazaFile  order by C_FileTime desc)  order by C_FileTime desc";
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
       }
       //更新下载次数
       public bool UpdateDowNumById(string fileId)
       {
           string sql = "update T_stuplazaFile set C_FileDowNum=C_FileDowNum+1 where C_FileId=@fileid";
           SqlParameter[] sp = { new SqlParameter("@fileid", fileId) };
           int flag = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
           if (flag > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       //存储过程查询
       public DataTable GetListByPage(int pageIndex, int pageSize, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                 totalParameter};

           tb = SqlHelper.ExecuteDataTable("PFileList", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return tb;
       }
      //按照部门存储过程获取
       public DataTable GetListBySector(int pageIndex, int pageSize, string sector, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@sector",sector),
                                 totalParameter};

           tb = SqlHelper.ExecuteDataTable("PFileListBySector", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return tb;

       }
       //删除文件
       public bool deleteFile(string id) {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from T_stuplazaFile");
           strSql.Append(" where C_FileId=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char)
			};
           parameters[0].Value = id;
           int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
           if (rows > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       
       }
    }
}
