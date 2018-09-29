using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PikCorrector
{    class Program
  {
    static void Main(string[] args)
    {
      var userPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      var pluginsConfigpath = Path.Combine(userPath, @"Autodesk\Revit\Addins\2017\PIK\PIK_PluginConfig.xml");

      XDocument xmlDoc = XDocument.Load(pluginsConfigpath);
      xmlDoc.Descendants("PluginInfo")
      .Where(x => x.Element("AssemblyName").Value == "ChangeManager")
      .Remove();
      xmlDoc.Descendants("PluginInfo")
      .Where(x => x.Element("AssemblyName").Value == "RevitNameValidator")
      .Remove();
      xmlDoc.Descendants("PluginInfo")
      .Where(x => x.Element("AssemblyName").Value == "Revit_RebarColorFiller")
      .Remove();
      xmlDoc.Descendants("PluginInfo")
      .Where(x => x.Element("AssemblyName").Value == "OkCommand")
      .Remove();

      xmlDoc.Save(pluginsConfigpath);

      // delete unnesesery folders
      var deleters = new List<string> {
        @"C:\Autodesk\AutoCAD\Pik\Settings\Dll",
        Path.Combine(userPath, @"Autodesk\Revit\Addins\2017\PIK\OtherAddins")
      };

      // add vitrocad folder
      // if (userPath.Contains("malozyomovvv")){
      //   deleters.Add("vitro path...");
      // }

      foreach(var path in deleters) {
      if (Directory.Exists(path))
        try {
        Directory.Delete(path, true);
        }
        catch (Exception ex){
          Debug.Write(ex.Message);
        }
      }
    }
  }
}
