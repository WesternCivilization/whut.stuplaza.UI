using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.DAL;
using mrwwd.MODEL;

namespace mrwwd.BLL
{
    public class AdminBLL
    {
        public string GetPasswordByAccount(string account)
        {
            AdminDAL dal = new AdminDAL();
            return dal.GetPasswordByAccount(account);
        }
    }
}
