using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var xRoot = CreateTree();
            
            var noProp = xRoot.Descendants("Type").Where(v => !v.Elements("Properties").Nodes().Any())
                .OrderBy(v => v.Element("Name"));

            Console.WriteLine(noProp.Count());

            var propertiesNames = xRoot.Descendants("Type").Elements("Properties").Elements("Name");
            Console.WriteLine(propertiesNames.Count());

            var mostUsedTypes = propertiesNames.GroupBy(v => v.Attribute("Type").Value).OrderByDescending(v => v.Count());
            Console.WriteLine("mostUsedTypes: " + string.Join(",\r\n", mostUsedTypes.Take(10).Select(v => $"{v.Key} ({v.Count()})")));


            //Console.WriteLine(xRoot);
            Console.ReadKey();
        }

        static XElement CreateTree()
        {
            var xRoot = new XElement("Root");

            // TODO: Convert this to one linq statment...
            foreach (Type item in Assembly.Load("mscorlib").GetTypes().Where(v => /*v.Name == "Exception" && */ v.IsClass && v.IsPublic))
            {
                var xType = new XElement("Type", new XAttribute("FullName", item.FullName));
                xRoot.Add(xType);

                var xProperties = new XElement("Properties");
                xType.Add(xProperties);

                foreach (var item2 in item.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var xProperty = new XElement("Name", new XAttribute("Name", item2.Name), new XAttribute("Type", item2.PropertyType.Name));
                    xProperties.Add(xProperty);
                }

                var xMethods = new XElement("Methods");
                xType.Add(xMethods);

                // TODO: I'm not filtering this as the lab describe?...
                foreach (var item2 in item.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(v => v.GetBaseDefinition() != v))
                {
                    var xMethod = new XElement("Method", new XAttribute("Name", item2.Name), new XAttribute("ReturnType", item2.ReturnType.Name));
                    xMethods.Add(xMethod);

                    var xParameters = new XElement("Parameters");
                    xMethod.Add(xParameters);

                    foreach (var item3 in item2.GetParameters())
                    {
                        var xParameter = new XElement("Parameter", new XAttribute("Name", item2.Name), new XAttribute("Type", item2.ReturnType.Name));
                        xParameters.Add(xParameter);
                    }
                }
            }

            return xRoot;
        }
    }
}
