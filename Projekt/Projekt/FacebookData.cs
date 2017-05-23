using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class FacebookData
    {
        public FacebookPost[] data { get; set; }  
    }
    public class Result
    {
        public FacebookData[] data { get; set; }
    }
}
