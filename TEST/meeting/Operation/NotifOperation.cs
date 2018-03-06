using meeting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.Operation
{
    public class NotifOperation : IOperation
    {
        public long id => 6;

        public string name => "Уведомить о встрече";
    }
}
