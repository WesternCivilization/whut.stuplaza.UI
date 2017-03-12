using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.stuplaza.MODEL
{
   public class T_stuplazaManuScript
    {
        //C_ManuScriptId, C_ManuScriptTitle, C_ManuScriptContent, C_ManuScriptAcademy, C_ManuScriptAuthor, C_ManuScriptTel, C_ManuScriptEmail, C_ManuScriptReviewer, C_ManuScriptStatus
       public string ManuScriptId{ get; set; }
       public string ManuScriptTitle { get; set; }
       public string ManuScriptContent { get; set; }
       public string ManuScriptAcademy { get; set; }
       public string ManuScriptAuthor { get; set; }
       public string ManuScriptTel { get; set; }
       public string ManuScriptEmail { get; set; }
       public string ManuScriptReviewer { get; set; }
       public int ManuScriptStatus { get; set; }
       public string ManuScriptTime { get; set; }
    }
}
