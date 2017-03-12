using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.stuplaza.MODEL;
using whut.stuplaza.DAL;
using System.Data;
namespace whut.stuplaza.BLL
{
  public class TopicBLL
    {
      TopicDAL dal = new TopicDAL();
        //获取专题modellist
        public List<T_stuplazaTopic> GetAllTopicInfo()
        {
            return DataTableToList(dal.GetAllTopicInfo());
        
        }


        public List<T_stuplazaTopic> DataTableToList(DataTable table)
        {
            List<T_stuplazaTopic> list = new List<T_stuplazaTopic>();
            int rowCount = table.Rows.Count;
            if (rowCount > 0)
            {
                T_stuplazaTopic model;
                for (int i = 0; i < rowCount; i++)
                {

                    model = dal.DataRowToModel(table.Rows[i]);
                    if (model != null)
                        list.Add(model);

                }


            }
            return list;
        
        
        }
        public int InsertTopic(T_stuplazaTopic model)
        {
            TopicDAL dal = new TopicDAL();
            return dal.Insert(model);
        }

        public bool UpdateTopic(T_stuplazaTopic model)
        {
            TopicDAL dal = new TopicDAL();
            return dal.Update(model);
        }

        public bool DeleteTopic(string id)
        {
            TopicDAL dal = new TopicDAL();
            return (dal.Delete(id));
        }
        public T_stuplazaTopic GetTopicById(string id)
        {
            TopicDAL dal = new TopicDAL();
            return dal.GetTopicById(id);
        }



        public string GetTopicNameById(int id)
        {
            return dal.GetTopicNameById(id);
        }
        public bool GetTopicNameByName(string name) {
            return dal.GetTopicNameByName(name);
        }

      ///获取前三条数据
        public List<T_stuplazaTopic> GetListByTotal(int total)
        {
            return DataTableToList(dal.GetListByTotal(total));
        }
      //按照优先级获取total条数据
        public List<T_stuplazaTopic> GetListByPriority(int total)
        {
            return DataTableToList(dal.GetListByPriority(total));
        }

      //根据优先级分页查询model
        public List<T_stuplazaTopic> GetListByCategory(int pageIndex, int pageSize, out int total)
        {
            return DataTableToList(dal.GetListByCategory(pageIndex, pageSize, out total));
        }

    }
}
