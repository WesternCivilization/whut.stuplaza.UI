using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.DAL;
using mrwwd.MODEL;
using System.Data;

namespace mrwwd.BLL
{
    public class PlaceBLL
    {
        PlaceDAL dal = new PlaceDAL();
        // 根据市父节点遍历县子节点
        public List<T_place> GetRecordByParent(string parent)
        {
            return DataTableToList(dal.GetDataTableByParent(parent));
        }

        public List<T_place> DataTableToList(DataTable tb)
        {
            List<T_place> list = new List<T_place>();
            int count = tb.Rows.Count;
            if ( count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    T_place model = new T_place();
                    if (tb.Rows[i]["C_PlaceId"] != null && tb.Rows[i]["C_PlaceId"].ToString() != "")
                    {
                        model.C_PlaceId = tb.Rows[i]["C_PlaceId"].ToString();
                    }
                    if(tb.Rows[i]["C_PlaceName"] != null && tb.Rows[i]["C_PlaceName"].ToString() != "")
                    {
                        model.C_PlaceName = tb.Rows[i]["C_PlaceId"].ToString();
                    }
                    if (tb.Rows[i]["C_PlaceParent"] != null && tb.Rows[i]["C_PlaceParent"].ToString() != "")
                    {
                        model.C_PlaceParent = (int)tb.Rows[i]["C_PlaceParent"];
                    }
                    if (tb.Rows[i]["C_PlacePersonNum"] != null && tb.Rows[i]["C_PlacePersonNum"].ToString() != "")
                    {
                        model.C_PlacePersonNum = (int)tb.Rows[i]["C_PlacePersonNum"];
                    }
                    if (tb.Rows[i]["C_PlaceQuestionAnsweredNum"] != null && tb.Rows[i]["C_PlaceQuestionAnsweredNum"].ToString() != "")
                    {
                        model.C_PlaceQuestionAnsweredNum = (int)tb.Rows[i]["C_PlaceQuestionAnsweredNum"];
                    }
                    //if (tb.Rows[i]["C_PlaceRightNum"] != null && tb.Rows[i]["C_PlaceRightNum"].ToString() != "")
                    //{
                    //    model.C_PlaceRightNum = (int)tb.Rows[i]["C_PlaceRightNum"];
                    //}
                    if (tb.Rows[i]["C_PlaceAccuracy"] != null && tb.Rows[i]["C_PlaceAccuracy"].ToString() != "")
                    {
                        model.C_PlaceAccuracy = (double)tb.Rows[i]["C_PlaceAccuracy"];
                    }
                    if (tb.Rows[i]["C_PlaceTotalRightNum"] != null && tb.Rows[i]["C_PlaceTotalRightNum"].ToString() != "")
                    {
                        model.C_PlaceTotalRightNum = (int)tb.Rows[i]["C_PlaceTotalRightNum"];
                    }
                    list.Add(model);
                }
            }
            return list;
        }

        // 通过地名获取地方模型类
        public T_place GetRecordByPlaceName(string placeName)
        {
            PlaceDAL dal = new PlaceDAL();
            return dal.GetCountyByPlaceName(placeName);
        }

        // 通过地方编号获取地方模型类
        public T_place GetRecordByPlaceId(string PlaceId)
        {
            PlaceDAL dal = new PlaceDAL();
            return dal.GetPlaceById(PlaceId);
        }


        // 统计地方答题总人数 并更新数据 县
        public bool GetPeopleNumOfCounty(string county)
        {
            UserDAL dal = new UserDAL();
            PlaceDAL placeDAL = new PlaceDAL();
            int count = placeDAL .GetCountyUserNumByPlaceId(county);
            return placeDAL.UpdateTotalPeople(county, count);
        }

        // 统计地方答题总人数 市 并更新数据
        public int GetPlacePeopleNum(string parent)
        {
            PlaceDAL placeDAL = new PlaceDAL();
            List<T_place> list = new List<T_place>();
            list = DataTableToList(dal.GetDataTableByParent(parent));
            int totalPeople = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalPeople += list[i].C_PlacePersonNum;
            }
            return placeDAL.UpdatePersonNum(parent, totalPeople);   // !!!  UpdatePersonNum
        }

        // 统计地方答题总正确题数 并更新数据 县
        public int GetPlaceTotalScore(string county)
        {
            UserDAL userDal = new UserDAL();
            PlaceDAL placeDAL = new PlaceDAL();
            int count = placeDAL.GetPlaceNumOfCorrectAns(county);
            return placeDAL.UpdateRightNum(county, count);
        }


        // 统计地方答题总答对题数 市 并更新数据
        public int GetRightNumOfCity(string parent)
        {
            PlaceDAL placeDAL = new PlaceDAL();
            List<T_place> list = new List<T_place>();
            list = GetRecordByParent(parent);
            int totalCorrNum = 0;
            if (list != null)
            {
                
                for (int i = 0; i < list.Count; i++)
                {
                    totalCorrNum += list[i].C_PlaceTotalRightNum;
                }
            }
            return placeDAL.UpdateRightNum(parent, totalCorrNum);
        }
        //// 获得地方答题总答题正确数 并更新
        //public int GetRightNum(string placeId)
        //{
        //    PlaceDAL placeDAL = new PlaceDAL();

        //}


        // 通过placeId获取地方答题总数
        public int GetCountyAnswers(string placeId)
        {
            PlaceDAL placeDAL = new PlaceDAL();
            List<T_place> list = new List<T_place>();
            list = DataTableToList(placeDAL.GetTotalAnswersByPlaceId(placeId));
            return list.Count;
        }
    }
}
