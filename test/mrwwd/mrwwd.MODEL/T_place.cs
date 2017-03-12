using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrwwd.MODEL
{
    public class T_place
    {
        public string C_PlaceId { get; set; }
        public string C_PlaceName { get; set; }
        public int C_PlaceParent { get; set; }
        public int C_PlacePersonNum { get; set; }
        public int C_PlaceQuestionAnsweredNum { get; set; }
        //public int C_PlaceRightNum { get; set; }
        public double C_PlaceAccuracy { get; set; }
        public int C_PlaceTotalRightNum { get; set; }
    }
}
