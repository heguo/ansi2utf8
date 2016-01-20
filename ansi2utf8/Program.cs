using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ansi2utf8
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                convert(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("usage: convert \"c:\\ansifile.txt\" \"c:\\utf8file.txt\" ");
            }
        }

        static void convert(string infile, string outfile)
        {
            if (!File.Exists(infile))
            {
                Console.WriteLine(string.Format("error: file {0} not found.", infile));
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfile)))
            {
                CreateDictory(System.IO.Path.GetDirectoryName(outfile));
            }

            try
            {
                var s = File.ReadAllText(infile,Encoding.Default);
                using (var sw = new StreamWriter(outfile, false, Encoding.UTF8))
                {
                    sw.WriteLine(s);
                    sw.Close();
                }
                Console.WriteLine(string.Format("success: {0} => {1}", infile,outfile));
            }
            catch
            {
                Console.WriteLine(string.Format("error: {0} => {1}", infile,outfile));
            }
        }

        static void CreateDictory(string dict)
        {
            var parent = System.IO.Path.GetDirectoryName(dict);
            if (!System.IO.Directory.Exists(parent))
            {
                CreateDictory(parent);
                System.IO.Directory.CreateDirectory(dict);
            }
            else
            {
                System.IO.Directory.CreateDirectory(dict);
            }
        }
    }
}
