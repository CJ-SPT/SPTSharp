using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Models.Eft.Game
{
    public class GameStartResponse
    {
        public GameStartResponse(int utcNow) 
        { 
            utc_now = utcNow;
        }

        public int utc_now {  get; set; }
    }
}
