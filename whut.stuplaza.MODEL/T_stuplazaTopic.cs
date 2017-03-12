using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.stuplaza.MODEL
{
   public class T_stuplazaTopic
    {
        //专题模型类
        //C_TopicId, C_TopicTitle, C_TopicTime, C_TopicPriority, C_TopicSummary
        public int TopicId{ get; set; }
        public string TopicTitle { get; set; }
        public string TopicTime { get; set; }
        public int TopicPriority { get; set; }
        public string TopicSummary { get; set; }
        public string TopicFileName { get; set; }
    }
}
