using System;
using System.Collections.Generic;
using System.Text;

namespace Cs2GenLinqToXmlLib
{
    public class IOManager
    {
        public static void WriteToFile(string path,string Text)
        {
            System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(path);
            oStreamWriter.Write(Text);
            oStreamWriter.Close();
        }
        public static void SaveGeneratedClasses(List<GeneratedClass> oGeneratedClasses,string path,string AppPath,string CsNamespace)
        {
            foreach (GeneratedClass oGeneratedClass in oGeneratedClasses)
            {
                WriteToFile(System.IO.Path.Combine(path,oGeneratedClass.FileName), oGeneratedClass.FileCode);
            }

            System.IO.File.Copy(System.IO.Path.Combine(AppPath, @"Classes\PredicateHelper.cs"), System.IO.Path.Combine(path, "PredicateHelper.cs"));
            System.IO.File.Copy(System.IO.Path.Combine(AppPath, @"Classes\SerializeManager.cs"), System.IO.Path.Combine(path, "SerializeManager.cs"));

            if (CsNamespace != "NET2CsGenXLinq")
            {
                ReplaceInFile(System.IO.Path.Combine(path, @"PredicateHelper.cs"), CsNamespace);
                ReplaceInFile(System.IO.Path.Combine(path, @"SerializeManager.cs"), CsNamespace);
            }

        }
        public static string ReadToEndFile(string path)
        {
            System.IO.StreamReader oStreamReader = new System.IO.StreamReader(path,System.Text.Encoding.UTF8);          
            return oStreamReader.ReadToEnd();
        }

        public static void ReplaceInFile(string FilePath,string NewCsNamespace)
        {
            try
            {
                string sSource = string.Empty;
                System.IO.StreamReader oStreamReader = new System.IO.StreamReader(FilePath);
                sSource = oStreamReader.ReadToEnd();
                oStreamReader.Close();

                sSource = sSource.Replace("namespace NET2CsGenXLinq", "namespace " + NewCsNamespace);

                System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(FilePath);
                oStreamWriter.Write(sSource);
                oStreamWriter.Close();
            }
            catch
            { }
        }
    }
}
