using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Models
{
    public class WorkDayDisplayModel
    {
        public string date { get; set; }
        public int workTime { get; set; }
        public int ordersDone { get; set; }
        public int shopsDone { get; set; }
    }
}
