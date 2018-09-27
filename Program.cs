using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PikCorrector
{
    class Program
    {
        static void Main(string[] args)
        {
            // XDocument xmlDoc = null;
            var inFileName = @"C:\#Coding\PikCorrector\PIK_PluginConfig.xml";
            // using (StreamReader oReader = new StreamReader(inFileName, Encoding.GetEncoding("utf-8")))
            // {
                // xmlDoc = XDocument.Load(oReader);
                XDocument xmlDoc = XDocument.Load(inFileName);
                xmlDoc.Element("breakfast_menu")
                  .Element("food")
                  .Remove();

// target.Attribute("prive").Value = "changed";
xmlDoc.Save(Console.Out);
                // xmlDoc.Element("GroupCIDsS").Remove();

// xdoc.Descendants("add")
//     .Where(x => (string)x.Attribute("key") == key)
//     .Remove();

                // xmlDoc.Save(@"C:\#Coding\PikCorrector\PIK_PluginConfig.xml");
            // }
            // Console.WriteLine("Hello World!");
        }
    }
}
