using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Models.Eft.Launcher
{
    public class MiniProfile
    {
        public string username {  get; set; }
        public string nickname { get; set; }
        public string side { get; set; }
        public int currlvl { get; set; }
        public float currexp { get; set; }
        public float prevexp { get; set; }
        public int nextlvl { get; set; }
        public int maxlvl { get; set; } 
        public AkiData akiData { get; set; }
    }

    public class AkiData
    {
        public string version { get; set; }
    }
}
