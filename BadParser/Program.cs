using Components.Aphid.Interpreter;
using Components.External;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BadParser
{
    class Program
    {
        static void Main(string[] args)
        {
            new AphidInterpreter().InterpretFile(
                PathHelper.GetEntryPath(
                    @"Scripts\VulnerabilitySimulation.alx"));
        }
    }
}
