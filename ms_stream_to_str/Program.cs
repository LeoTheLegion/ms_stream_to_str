using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_stream_to_str
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\..\"));
            Console.WriteLine(path);
            string[] lines = System.IO.File.ReadAllLines(path + "/test");
            int offset = 4;
            int num_of_logs = 0;

            string STR_text = "";

            for(int i = offset; i < lines.Length; i++)
            {
                if (i% 4 == 0)
                {
                    //Console.WriteLine(++num_of_logs);
                    STR_text += ++num_of_logs + "\n";
                }
                if (i % 4 == 1)
                {
                    string str = lines[i];
                    str = str.Replace('.', ',');
                    //Console.WriteLine(str);
                    STR_text += str + "\n";
                }
                if (i % 4 == 2)
                {
                    string str = lines[i];
                    string newStr = "";
                    for (int j = 0; j < str.Length-1; j++)
                    {
                        if(str[j] == '�')
                        {
                            newStr += '\'';
                            continue;
                        }
                        newStr += str[j];
                    }
                    //Console.WriteLine(newStr);
                    STR_text += newStr + "\n";
                }
                if (i % 4 == 3)
                {
                    //Console.WriteLine(lines[i]);
                    STR_text += lines[i] + "\n";
                }
            }
            Console.WriteLine(STR_text);
            File.WriteAllText(path+"/newText.str", STR_text);
        }
    }
}
//" I�m from California. There were surfers there and there are surfers here. A little illogical, but they�re in the United States. "