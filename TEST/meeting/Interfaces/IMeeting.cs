using System;

namespace meeting.Interfaces
{
    public interface IMeeting
    {
        int id { get; set; }

        DateTime dtstart { get; set; }

        DateTime dtend { get; set; }

        string name { get; set; }
    }
}
