using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrwwd.MODEL
{
    public class WeiXinAccessTokenResult
    {
        public WeiXinAccessTokenModel SueccessResult { get; set; }
        public bool Result { get; set; }
        public WeiXinErrorMsg ErrorResult { get; set; }
    }
}
