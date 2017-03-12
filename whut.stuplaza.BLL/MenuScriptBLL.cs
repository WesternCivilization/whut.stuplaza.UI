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
   public class MenuScriptBLL
    {
       MenuScriptDAL dal = new MenuScriptDAL();
        //C_ManuScriptId, C_ManuScriptTitle, C_ManuScriptContent, C_ManuScriptAcademy, C_ManuScriptAuthor, C_ManuScriptTel, C_ManuScriptEmail, C_ManuScriptReviewer, C_ManuScriptStatus
        /// <summary>
        /// 业务逻辑层添加model方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertArticle(T_stuplazaManuScript model)
        {
            return dal.Insert(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_stuplazaManuScript model)
        {
            return dal.Update(model);
        }
    //删除一条数据
        public bool Delete(string id) {
            return dal.Delete(id);
        } 
       
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }


       ///查询数据
        public List<T_stuplazaManuScript> GetList()
        {
            return dal.GetList();
        }
       //根据id获取model
        public T_stuplazaManuScript GetModelById(string id)
        {
            return dal.GetModelById(id);
        }

        //根据日期时间模糊查询获取编号
        public string GetIdByTime(string dateTime)
        {
           T_stuplazaManuScript ManuModel = new T_stuplazaManuScript();
            DataTable manu = dal.GetIdByTime(dateTime);
            string str = null;
            if (manu.Rows.Count == 0)
            {
                str = dateTime + "001";
            }
            else
            {
                ManuModel.ManuScriptId = manu.Rows[0]["C_ManuScriptId"].ToString().Trim();
                int strId = Int32.Parse(ManuModel.ManuScriptId.Substring(8, 3)) + 1;
                if (strId >= 10)
                {
                    str = dateTime + "0" + strId.ToString().Trim();
                }
                else if (strId >= 100)
                {
                    str = dateTime + "0" + strId.ToString().Trim();
                }
                else
                {
                    str = dateTime + "00" + strId.ToString().Trim();
                }
            }
            return str;

        }
       ///根据时间倒序排列查询前几条数据
        public List<T_stuplazaManuScript> GetListByNum(int num)
        {
            return dal.GetListByNum(num);
        }
        public List<T_stuplazaManuScript> GetListByPage(int pageIndex, int pageSize, out int total)
        {
            return dal.GetListByPage(pageIndex, pageSize, out total);
        }

     //获取已经审核的数据
        public List<T_stuplazaManuScript> GetListByPageManager(int pageIndex, int pageSize, out int total)
        {
            return dal.GetListByPageManager(pageIndex, pageSize, out total);
        }
      //获取未审核和审核未通过的数据
        public List<T_stuplazaManuScript> GetListByStatus(int pageIndex, int pageSize, out int total)
        {
            return dal.GetListByStatus(pageIndex, pageSize, out total);
        }
       //获取按姓名查找的数据
        public List<T_stuplazaManuScript> GetListByName(int pageIndex, int pageSize,string name, out int total)
        {
            return dal.GetListByName(pageIndex, pageSize,name ,out total);
        }
        //获取按标题查找的数据
        public List<T_stuplazaManuScript> GetListByTitle(int pageIndex, int pageSize, string title, out int total)
        {
            return dal.GetListByTitle(pageIndex, pageSize, title, out total);
        }
       ///
        public DataTable GetTableByTime(string begintime, string endtime)
        {
            return dal.GetTableByTime(begintime, endtime);
        
        }
    }
}
