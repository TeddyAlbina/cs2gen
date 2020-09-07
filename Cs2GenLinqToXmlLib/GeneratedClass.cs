using System;
using System.Collections.Generic;
using System.Text;

namespace Cs2GenLinqToXmlLib
{
    public class GeneratedClass
    {
        private string _FileCode;

        public string FileCode
        {
            get { return _FileCode; }
            set { _FileCode = value; }
        }
        private string _FileName;

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public GeneratedClass()
        { }
        public GeneratedClass(string FileCode,string FileName)
        {
            this.FileCode = FileCode;
            this.FileName = FileName;
        } 
    }
}
