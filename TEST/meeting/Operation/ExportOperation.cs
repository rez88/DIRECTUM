using meeting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.Operation
{
    public class ExportOperation : IOperation
    {
        public long id => 5;

        public string name => "Экспорт";
    }
}
