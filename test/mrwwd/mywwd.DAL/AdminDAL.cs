using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.COMMON;
using mrwwd.MODEL;

namespace mrwwd.DAL
{
    public class AdminDAL
    {
        //获得系统管理员
        public DataTable GetSysAdmin(string account)
        {
            string sql = "select * from T_admin where C_AdminAccount=@account";
            SqlParameter[] sp = { new SqlParameter("@account", account) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }
        public DataTable GetAllSysAdmin()
        {
            string sql = "select * from T_admin";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        // 添加系统管理员
        public int InsertSysAdmin(T_admin model)
        {
            string sql = "insert into T_admin(C_AdminAccount,C_AdminPassword) values(@account,@password)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@account",model.AdminAccount),
                new SqlParameter("@password",model.AdmminPassword)
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        // 修改系统管理员
        public bool UpdateSysAdmin(T_admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_admin set ");
            strSql.Append("C_AdminAccount=@account,");
            strSql.Append("C_AdminPassword=@password");
            SqlParameter[] pms =
            {
                new SqlParameter("@account",SqlDbType.NVarChar,50),
                new SqlParameter("@account",SqlDbType.NVarChar,50)
            };
            pms[0].Value = model.AdminAccount;
            pms[1].Value = model.AdmminPassword;
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, pms);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 实现自动编号
        // 系统管理员
        public DataTable sysAdmin()
        {
            string sql = "select top(1) * from T_admin order by C_AdminAccount desc;";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }

        // 删除系统管理员
        public bool DeleteSysAdmin(string account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete * from T_admin ");
            strSql.Append("where C_AdminAccount=@account");
            SqlParameter[] pms =
            {
                new SqlParameter("@account", SqlDbType.NVarChar,50)
            };
            pms[0].Value = account;
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text,pms);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        // 根据账户获取密码
        public string GetPasswordByAccount(string account)
        {
            string strSql = "select C_AdminPassword from T_admin where C_AdminAccount=@account";
            SqlParameter[] sp =
            {
                new SqlParameter("@account",account)
            };
            return (string)SqlHelper.ExecuteScalar(strSql, CommandType.Text, sp);
        }
    }
}
