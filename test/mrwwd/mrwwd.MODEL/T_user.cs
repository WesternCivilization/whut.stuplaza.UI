using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrwwd.MODEL
{
    public class T_user
    {
        public string C_UserOpenId { get; set; }
        // public string UserWeChatId { get; set; }
        public string C_UserName { get; set; }
        public string C_UserPhone { get; set; }
        public string C_UserPlaceId { get; set; }
        public int C_UserTotalRightNum { get; set; }
        public int C_UserTodayRightNum { get; set; }
        public string C_UserAccuracy { get; set; }
        public int C_UserAnswerDays { get; set; }
        public string C_UserLastLogin { get; set; }
        public string C_UserFirstLogin { get; set; }
        public int C_UserRanking { get; set; }
        public int C_UserTotalAnswerNum { get; set; }
    }
}
