using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadParser
{
    public class WidgetVector
    {
        public long X { get; set; }

        public long Y { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
    }
}
