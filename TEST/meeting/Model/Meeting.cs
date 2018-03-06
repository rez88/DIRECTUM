using meeting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.Model
{
    public class Meeting : IMeeting
    {
        public DateTime dtend { get; set; }

        public DateTime dtstart { get; set; }

        public int id { get; set; }

        public string name { get; set; }
    }
}
