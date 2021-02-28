//Copyright ⓒ 2020. 김동준. All rights Reserved 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIO
{
    class FileIO
    {
        public static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + "\\keybd.ini"; // 경로지정 : 현재 디렉토리의 keybd.ini

            if (!File.Exists(path)) // 파일 존재하지 않을 경우,
            {
                Console.WriteLine("keybd.ini 파일이 없습니다.");
                //makeFile(path);
            }
            else // 파일이 존재할 경우,
            {
                List<Tuple<char, string>> list = readFile(path); // list에 .ini LineString 다 들어감
                for (int i = 0; i < list.Count(); i++)
                    Console.WriteLine(list[i].Item1 + " " + list[i].Item2);

            }
            
        }

        public static void makeFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hi");
            }
        }

        public static List<Tuple<char, string>> readFile(string path)
        {
            List<Tuple<char, string>> list = new List<Tuple<char, string>>();

            using (StreamReader sr = File.OpenText(path))
            {
                
                string[] linecut;

                string line, quit = "q";
                char symbol;
                int lineLen;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.CompareTo(quit) == 0)
                    {
                        list.Add(Tuple.Create('q', "exitapp"));
                        continue;
                    }
                    symbol = line[0];
                    lineLen = line.Length;
                    if (lineLen >=4)
                        line = line.Substring(2, lineLen - 2);

                    linecut = line.Split(',');

                    for (int i = 0; i < linecut.Count(); i++)
                        list.Add(Tuple.Create(symbol, linecut[i]));
                }
            }
            return list;
        }
    }
}
