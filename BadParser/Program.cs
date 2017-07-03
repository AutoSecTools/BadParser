using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BadParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Bad Parser {0}",
                Assembly.GetExecutingAssembly().GetName().Version);

            if (args.Length != 1)
            {
                Console.WriteLine("\r\nUsage: BadParser [Input file]");
                Environment.Exit(1);
            }

            var inputFile = new FileInfo(args[0]);
            
            if (!inputFile.Exists)
            {
                Console.WriteLine("Could not find input file \"{0}\".", inputFile.Name);
                Environment.Exit(2);
            }

            var ext = inputFile.Extension.ToLower();

            if (ext == ".json")
            {
                try
                {
                    DeserializeJson(inputFile);
                }
                catch
                {
                    Console.WriteLine("Error deserializing");
                }
            }
        }

        static void DeserializeJson(FileInfo inputFile)
        {
            var jsonSerializer = new JavaScriptSerializer();

            using (var s = new StreamReader(inputFile.OpenRead()))
            {
                var json = s.ReadToEnd();
                var widgets = jsonSerializer.Deserialize<Widget[]>(json);

                if (widgets == null)
                {
                    return;
                }

                Console.WriteLine(
                    "{0} widgets loaded",
                    widgets.Length);

                var vulnSim = new VulnerabilitySimulator();

                vulnSim.CheckWidgetCount(widgets);

                var methods = vulnSim
                    .GetType()
                    .GetMethods()
                    .Select(x => new
                    {
                        Method = x,
                        Params = x.GetParameters()
                    })
                    .Where(x =>
                        x.Params.Count() == 1 &&
                        x.Params.Single().ParameterType ==
                        typeof(Widget))
                    .ToArray();

                foreach (var w in widgets)
                {
                    foreach (var m in methods)
                    {
                        m.Method.Invoke(
                            vulnSim,
                            new[] { w });
                    }

                    Console.WriteLine(w);
                }
            }
        }
    }
}
