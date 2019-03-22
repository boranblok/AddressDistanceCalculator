using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressDistance
{
    public class GoogleCachedResponse :  SQLiteBase
    {
        public String Request { get; set; }
        public String Response { get; set; }
        public Int64 Ticks { get; set; }

    }
}
