using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Models
{
    public class WorkDayModel
    {
        public int id { get; set; }
        public int workerId { get; set; }
        public DateTime date { get; set; }
        public int workTime { get; set; }
        public int ordersDone { get; set; }
        public int shopsDone { get; set; }

    }
}
