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

    public class UserLoginBLL
    {
        UserLoginDAL dal = new UserLoginDAL();
        //将DataTable的数据转移到Model里面
        //系统管理员
        public T_stuplazaSysAdmin GetSysAdmin(string username)
        {
            T_stuplazaSysAdmin SysAdminmodel = new T_stuplazaSysAdmin();
            DataTable tb = dal.GetSysAdmin(username);
            if (tb.Rows.Count > 0)
            {
                SysAdminmodel.SysAdminAccount = tb.Rows[0]["C_SysAdminAccount"].ToString();
                SysAdminmodel.SysAdminPwd = tb.Rows[0]["C_SysAdminPwd"].ToString();
                SysAdminmodel.SysAdminName = tb.Rows[0]["C_SysAdminName"].ToString();
                SysAdminmodel.SysAdminTel = tb.Rows[0]["C_SysAdminTel"].ToString();
                SysAdminmodel.SysAdminEmail = tb.Rows[0]["C_SysAdminEmail"].ToString();
                SysAdminmodel.SysAdminCategory = (int)tb.Rows[0]["C_SysAdminCategory"];
            }
            return SysAdminmodel;
        }
        //获取系统管理员最后一个id
        public string GetSysAdminId()
        {
            T_stuplazaSysAdmin SysAdminmodel = new T_stuplazaSysAdmin();
            DataTable tb = dal.sysAdmin();
            if (tb.Rows.Count > 0)
            {
                SysAdminmodel.SysAdminAccount = tb.Rows[0]["C_SysAdminAccount"].ToString();
            }
            return SysAdminmodel.SysAdminAccount;
        }
        public List<T_stuplazaSysAdmin> GetAllSysAdmin()
        {
            DataTable tb = dal.GetAllSysAdmin();
            List<T_stuplazaSysAdmin> list = new List<T_stuplazaSysAdmin>();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    T_stuplazaSysAdmin SysAdminmodel = new T_stuplazaSysAdmin();
                    SysAdminmodel.SysAdminAccount = tb.Rows[i]["C_SysAdminAccount"].ToString();
                    SysAdminmodel.SysAdminPwd = tb.Rows[i]["C_SysAdminPwd"].ToString();
                    SysAdminmodel.SysAdminName = tb.Rows[i]["C_SysAdminName"].ToString();
                    SysAdminmodel.SysAdminTel = tb.Rows[i]["C_SysAdminTel"].ToString();
                    SysAdminmodel.SysAdminEmail = tb.Rows[i]["C_SysAdminEmail"].ToString();
                    SysAdminmodel.SysAdminCategory = (int)tb.Rows[i]["C_SysAdminCategory"];
                    list.Add(SysAdminmodel);
                }
            }
            return list;
        }

        //信息发布者
        public T_stuplazaInfoAdmin GetInfoAdmin(string username)
        {
            T_stuplazaInfoAdmin InfoAdminmodel = new T_stuplazaInfoAdmin();
            DataTable InfoAdminTab = dal.GetInfoAdmin(username);
            if (InfoAdminTab.Rows.Count > 0)
            {
                InfoAdminmodel.InfoAdminAccount = InfoAdminTab.Rows[0]["C_InfoAdminAccount"].ToString();
                InfoAdminmodel.InfoAdminPwd = InfoAdminTab.Rows[0]["C_InfoAdminPwd"].ToString(); InfoAdminmodel.InfoAdminName = InfoAdminTab.Rows[0]["C_InfoAdminName"].ToString();
                InfoAdminmodel.InfoAdminTel = InfoAdminTab.Rows[0]["C_InfoAdminTel"].ToString();
                InfoAdminmodel.InfoAdminEmail = InfoAdminTab.Rows[0]["C_InfoAdminEmail"].ToString();
                InfoAdminmodel.InfoAdminSector = InfoAdminTab.Rows[0]["C_InfoAdminSector"].ToString();
                InfoAdminmodel.InfoAdminCategory = (int)InfoAdminTab.Rows[0]["C_InfoAdminCategory"];
            }
            return InfoAdminmodel;
        }
        //获取信息管理员的最后一个ID
        public string GetInfoAdminId(string flag, string sectory)
        {
            T_stuplazaInfoAdmin InfoAdminmodel = new T_stuplazaInfoAdmin();
            //超级发布员
            if (flag == "00")
            {
                DataTable dt = dal.ChaoJiInfoAdmin();
                if (dt.Rows.Count > 0)
                {
                    InfoAdminmodel.InfoAdminAccount = dt.Rows[0]["C_InfoAdminAccount"].ToString();
                }
                return InfoAdminmodel.InfoAdminAccount;
            }
            //普通管理员
            else
            {
                DataTable dt = dal.PuTongInfoAdmin(sectory);
                if (dt.Rows.Count > 0)
                {
                    InfoAdminmodel.InfoAdminAccount = dt.Rows[0]["C_InfoAdminAccount"].ToString();
                }
                return InfoAdminmodel.InfoAdminAccount;
            }

        }

        public DataTable GetAllInfoAdmin()
        {
            return dal.GetAllInfoAdmin();
        }
        //稿件审核员
        public T_stuplazaReviewer GetReviewer(String username)
        {
            T_stuplazaReviewer Reviewermodel = new T_stuplazaReviewer();
            DataTable ReviewerTab = dal.GetReviewer(username);
            if (ReviewerTab.Rows.Count > 0)
            {
                Reviewermodel.ReviewerAccount = ReviewerTab.Rows[0]["C_ReviewerAccount"].ToString();
                Reviewermodel.ReviewerPwd = ReviewerTab.Rows[0]["C_ReviewerPwd"].ToString();
                Reviewermodel.ReviewerName = ReviewerTab.Rows[0]["C_ReviewerName"].ToString();
                Reviewermodel.ReviewerTel = ReviewerTab.Rows[0]["C_ReviewerTel"].ToString();
                Reviewermodel.ReviewerEmail = ReviewerTab.Rows[0]["C_ReviewerEmail"].ToString();
            }
            return Reviewermodel;
        }
        //获取稿件发布员的最后一个ID
        public string GetReviewerId()
        {
            T_stuplazaReviewer Reviewermodel = new T_stuplazaReviewer();
            DataTable ReviewerTab = dal.reviewer();
            if (ReviewerTab.Rows.Count > 0)
            {
                Reviewermodel.ReviewerAccount = ReviewerTab.Rows[0]["C_ReviewerAccount"].ToString();
            }
            return Reviewermodel.ReviewerAccount;
        }
        public DataTable GetAllReviewer()
        {

            return dal.GetAllReviewer();
        }

        //错误判断
        public LoginError CheckLoginError(string username, string userpwd, int i)
        {
            //信息发布员   
            if (i == 1)
            {
                T_stuplazaInfoAdmin InfoAdmin = GetInfoAdmin(username);
                if (InfoAdmin.InfoAdminAccount == null)
                {
                    return LoginError.UserNotExists;
                }
                else if (InfoAdmin.InfoAdminPwd != userpwd)
                {
                    return LoginError.ErrorPassword;
                }
                else
                {
                    return LoginError.Success;
                }
            }
            //稿件审核员
            else if (i == 2)
            {
                T_stuplazaReviewer Reviewer = GetReviewer(username);
                if (Reviewer.ReviewerAccount == null)
                {
                    return LoginError.UserNotExists;
                }
                else if (Reviewer.ReviewerPwd != userpwd)
                {
                    return LoginError.ErrorPassword;
                }
                else
                {
                    return LoginError.Success;
                }
            }
            //系统管理员
            else
            {
                T_stuplazaSysAdmin SysAdmin = GetSysAdmin(username);
                if (SysAdmin.SysAdminAccount == null)
                {
                    return LoginError.UserNotExists;
                }
                else if (SysAdmin.SysAdminPwd != userpwd)
                {
                    return LoginError.ErrorPassword;
                }
                else
                {
                    return LoginError.Success;
                }
            }


        }
        //添加系统管理员
        public int InsertSysAdmin(T_stuplazaSysAdmin model)
        {
            UserLoginDAL dal = new UserLoginDAL();
            return dal.InsertSysAdmin(model);
        }
        //插入信息发布者
        public int InsertInfoAdmin(T_stuplazaInfoAdmin model)
        {
            UserLoginDAL dal = new UserLoginDAL();
            return dal.InsertInfoAdmin(model);
        }

        //插入稿件审核员
        public int InsertReviewer(T_stuplazaReviewer model)
        {
            UserLoginDAL dal = new UserLoginDAL();
            return dal.InsertReviewer(model);
        }
        //修改系统管理员
        public bool UpdateSysAdmin(T_stuplazaSysAdmin model)
        {
            UserLoginDAL dal = new UserLoginDAL();
            return dal.UpdateSysAdmin(model);
        }
        //修改信息发布者
        public bool UpdateInfoAdmin(T_stuplazaInfoAdmin model)
        {
            UserLoginDAL dal = new UserLoginDAL();
            return dal.UpdateInfoAdmin(model);
        }
        //修改稿件审核员
        public bool UpdateReviewer(T_stuplazaReviewer model)
        {
            UserLoginDAL dal = new UserLoginDAL();
            return dal.UpdateReviewer(model);
        }
        //删除信息发布员
        public bool DeleteInfoAdmin(string id)
        {
            return dal.DeleteInfoAdmin(id);
        }
        //删除系统管理员 
        public bool DeleteSysAdmin(string id)
        {
            return dal.DeleteSysAdmin(id);
        }
        //删除稿件审核员 
        public bool DeleteReviewer(string id)
        {
            return dal.DeleteReviewer(id);
        }
    }
    public enum LoginError
    {
        Success,
        UserNotExists,
        ErrorPassword
    }
}
 
