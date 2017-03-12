using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrwwd.MODEL
{
    public class WeiXinUserInfo
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nicname { get; set; }
        /// <summary>
        /// 用户性别 1为男 2为女 0为未知
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 用户资料的省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 用户所在国家，如中国为CN
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 用户头像 最后一个数值代表正方形头像大小（有 46 64 96 132可选 0代表640*640）用户无头像时该值为空
        /// </summary>
        public string headimgurl { get; set; }
        /// <summary>
        /// 用户特权信息，json数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        public string[] privilege { get; set; }
    }
}
