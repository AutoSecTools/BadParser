using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadParser
{
    public class Widget
    {
        public string Name { get; set; }

        public WidgetVector Position { get; set; }

        public byte[] Buffer { get; set; }

        public object Variant { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0}, {{ {1} }}, Buffer Size={2}, Variant={3}",
                Name,
                Position,
                Buffer.Length,
                Variant);
        }
    }
}
