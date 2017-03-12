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
    public class UserLoginDAL
    {
        //获得系统管理员
        public DataTable GetSysAdmin(string username)
        {
            string sql = "select * from T_stuplazaSysAdmin where C_SysAdminAccount=@name";
            SqlParameter[] sp = { new SqlParameter("@name", username) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }
        public DataTable GetAllSysAdmin()
        {
            string sql = "select * from T_stuplazaSysAdmin";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        // 获得信息发布者
        public DataTable GetInfoAdmin(string username)
        {
            string sql = "select * from T_stuplazaInfoAdmin where C_InfoAdminAccount=@name";
            SqlParameter[] sp = { new SqlParameter("@name", username) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }
        public DataTable GetAllInfoAdmin()
        {
            string sql = "select * from T_stuplazaInfoAdmin";  
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        //获得稿件审核人员
        public DataTable GetReviewer(string username)
        {
            string sql = "select * from T_stuplazaReviewer where C_ReviewerAccount=@name";
            SqlParameter[] sp = { new SqlParameter("@name", username) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }
        public DataTable GetAllReviewer()
        {
            string sql = "select * from T_stuplazaReviewer";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        //添加系统管理员
        public int InsertSysAdmin(T_stuplazaSysAdmin model)
        {
            //C_SysAdminAccount, C_SysAdminPwd, C_SysAdminName, C_SysAdminTel, C_SysAdminEmail, C_SysAdminCategory
            string sql = "insert into T_stuplazaSysAdmin(C_SysAdminAccount,C_SysAdminPwd, C_SysAdminName,C_SysAdminTel,C_SysAdminEmail)values(@account,@pwd,@name,@tel,@email)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@account",model.SysAdminAccount),
            new SqlParameter("@pwd",model.SysAdminPwd),
            new SqlParameter("@name",model.SysAdminName),
            new SqlParameter("@tel",model.SysAdminTel),
            new SqlParameter("@email",model.SysAdminEmail),
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        //插入信息发布者
        public int InsertInfoAdmin(T_stuplazaInfoAdmin model)
        { //C_InfoAdminAccount, C_InfoAdminPwd, C_InfoAdminSector, C_InfoAdminCategory, C_InfoAdminName, C_InfoAdminTel, C_InfoAdminEmail
            string sql = "insert into T_stuplazaInfoAdmin(C_InfoAdminAccount,C_InfoAdminPwd, C_InfoAdminSector,C_InfoAdminCategory,C_InfoAdminName,C_InfoAdminTel,C_InfoAdminEmail) values(@account,@pwd,@sector,@category,@name,@tel,@email)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@account",model.InfoAdminAccount),
            new SqlParameter("@pwd",model.InfoAdminPwd),
            new SqlParameter("@sector",model.InfoAdminSector),
            new SqlParameter("@category",model.InfoAdminCategory),
            new SqlParameter("@name",model.InfoAdminName),
            new SqlParameter("@tel",model.InfoAdminTel),
            new SqlParameter("@email",model.InfoAdminEmail),
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        //插入稿件审核员
        public int InsertReviewer(T_stuplazaReviewer model)
        {
            //C_ReviewerAccount, C_ReviewerPwd, C_ReviewerName, C_ReviewerTel, C_ReviewerEmail
            string sql = "insert into T_stuplazaReviewer(C_ReviewerAccount,C_ReviewerPwd, C_ReviewerName,C_ReviewerTel,C_ReviewerEmail) values(@account,@pwd,@name,@tel,@email)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@account",model.ReviewerAccount),
            new SqlParameter("@pwd",model.ReviewerPwd),
            new SqlParameter("@name",model.ReviewerName),
            new SqlParameter("@tel",model.ReviewerTel),
            new SqlParameter("@email",model.ReviewerEmail),
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
        //修改系统管理员
        //C_SysAdminAccount, C_SysAdminPwd, C_SysAdminName, C_SysAdminTel, C_SysAdminEmail, C_SysAdminCategory
        public bool UpdateSysAdmin(T_stuplazaSysAdmin model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_stuplazaSysAdmin  set ");
            strSql.Append("C_SysAdminPwd=@pwd,");
            strSql.Append("C_SysAdminName=@name,");
            strSql.Append("C_SysAdminTel=@tel,");
            strSql.Append("C_SysAdminEmail=@email");
            strSql.Append(" where C_SysAdminAccount=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,9),
					new SqlParameter("@pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@name", SqlDbType.NVarChar,40),
                    new SqlParameter("@tel", SqlDbType.Char,11),
					new SqlParameter("@email", SqlDbType.NVarChar,20)};
            parameters[0].Value =model.SysAdminAccount;
            parameters[1].Value = model.SysAdminPwd;
            parameters[2].Value = model.SysAdminName;
            parameters[3].Value = model.SysAdminTel;
            parameters[4].Value = model.SysAdminEmail;
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
         }
        //修改信息发布者
        public bool UpdateInfoAdmin(T_stuplazaInfoAdmin model)
        {  //C_InfoAdminAccount, C_InfoAdminPwd, C_InfoAdminSector, C_InfoAdminCategory, C_InfoAdminName, C_InfoAdminTel, C_InfoAdminEmail
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_stuplazaInfoAdmin  set ");
            strSql.Append("C_InfoAdminPwd=@pwd,");
            strSql.Append("C_InfoAdminName=@name,");
            strSql.Append("C_InfoAdminTel=@tel,");
            strSql.Append("C_InfoAdminEmail=@email");
            strSql.Append(" where C_InfoAdminAccount=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,8),
					new SqlParameter("@pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@name", SqlDbType.NVarChar,40),
                    new SqlParameter("@tel", SqlDbType.Char,11),
					new SqlParameter("@email", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.InfoAdminAccount;
            parameters[1].Value = model.InfoAdminPwd;
            parameters[2].Value = model.InfoAdminName;
            parameters[3].Value = model.InfoAdminTel;
            parameters[4].Value = model.InfoAdminEmail;
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //修改稿件审核员
        public bool UpdateReviewer(T_stuplazaReviewer model)
        {   //C_ReviewerAccount, C_ReviewerPwd, C_ReviewerName, C_ReviewerTel, C_ReviewerEmail
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_stuplazaReviewer  set ");
            strSql.Append("C_ReviewerPwd=@pwd,");
            strSql.Append("C_ReviewerName=@name,");
            strSql.Append("C_ReviewerTel=@tel,");
            strSql.Append("C_ReviewerEmail=@email");
            strSql.Append(" where C_ReviewerAccount=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,10),
					new SqlParameter("@pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@name", SqlDbType.NVarChar,40),
                    new SqlParameter("@tel", SqlDbType.Char,11),
					new SqlParameter("@email", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.ReviewerAccount;
            parameters[1].Value = model.ReviewerPwd;
            parameters[2].Value = model.ReviewerName;
            parameters[3].Value = model.ReviewerTel;
            parameters[4].Value = model.ReviewerEmail;
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //实现自动编号
        //系统管理员
        public DataTable sysAdmin() {
            string sql = "select top(1) * from T_stuplazaSysAdmin order by C_SysAdminAccount desc;";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);   
        }
        //稿件发布员
        public DataTable reviewer() { 
           string sql="select top(1) * from T_stuplazaReviewer order by C_ReviewerAccount desc";
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        //超级管理员
        public DataTable ChaoJiInfoAdmin()
        {
            string sql = "select top(1) *from T_stuplazaInfoAdmin where SUBSTRING(C_InfoAdminAccount,5,2)='00' order by C_InfoAdminAccount desc;";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        //普通管理员
        public DataTable PuTongInfoAdmin(string sectory)
        {
            string sql = "select top(1) *from T_stuplazaInfoAdmin where SUBSTRING(C_InfoAdminAccount,5,2)=@sectory order by C_InfoAdminAccount desc;";
            SqlParameter[] parameters = { new SqlParameter("@sectory", sectory)};
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text,parameters);   
        }
        //删除信息发布员
        public bool DeleteInfoAdmin(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_stuplazaInfoAdmin ");
            strSql.Append("where C_InfoAdminAccount=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,8)
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
        //删除系统管理员
        public bool DeleteSysAdmin(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_stuplazaSysAdmin ");
            strSql.Append("where C_SysAdminAccount=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,9)
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
        //删除稿件审核员
        public bool  DeleteReviewer(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_stuplazaReviewer ");
            strSql.Append("where C_ReviewerAccount=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,10)
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
 
 
