using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class CommonRequest
    {
        public string format { get; set; }
        public long? makeId { get; set; }
        public long? modelyear { get; set; }
    }
}
