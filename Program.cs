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
      var inFileName = @"D:\#Projects\#REPOS\PikCorrector\PIK_PluginConfig.xml";
      XDocument xmlDoc = XDocument.Load(inFileName);
      xmlDoc.Descendants("PluginInfo")
      .Where(x => x.Element("AssemblyName").Value == "Revit_GroupManager")
      .Remove();

      xmlDoc.Save(@"D:\#Projects\#REPOS\PikCorrector\PIK_PluginConfig.xml");

      // delete unnesesery folders
      Directory.Delete("", true);
    }
  }
}
