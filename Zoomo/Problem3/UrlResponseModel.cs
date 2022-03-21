using System;
using System.Collections.Generic;

namespace Zoomo.Problem3
{
    public class UrlResponseModel
    {
        public int LinksWorking { get; set; }
        public int LinksNotWorking { get; set; }
        public List<string> LinksWorkingList { get; set; }
        public List<string> LinksNotWorkingList { get; set; }
        public TimeSpan TimeElapsed { get; set; }
    }
}