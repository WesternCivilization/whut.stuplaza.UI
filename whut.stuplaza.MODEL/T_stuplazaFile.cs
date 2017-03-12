using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whut.stuplaza.MODEL
{
   public class T_stuplazaFile
    {
        //C_FileId, C_FileName, C_FileTime, C_FileSector, C_FileSummary
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileTime { get; set; }
        public string FileSector { get; set; }
        public string FileSummary { get; set; }
        public string FileExt { get; set; }
        public string FilePath { get; set; }
        public int FileDowNum { get; set; }
    }
}
