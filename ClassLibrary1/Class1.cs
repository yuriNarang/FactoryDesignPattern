using System;
using System.Data;
using System.Data.Common;
using System.IO;

namespace ClassLibrary1
{
    public class Class1
    {
        public void CreateFile()
        {
            using(TextWriter w = File.CreateText("log.txt"))
            {
                w.WriteLine("This is line one");
            }
        }
    }
}
