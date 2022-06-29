using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystem.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SpecialPath(@"C:", " ");                                                      //Dir. dove scrivere
            SpecialDirectory();                                                             //Dir. del Desktop  
            //GetDirInfo();                                                                 //File della dir. corrente
            //SearchInDirectory();                                                          //Cerca file in dir. corrente
            //FindOrCreate(@"C:\FileClienti\");                                             //Crea la Directory
            //CreateFile("MovClienti.txt");                                                 //Crea file in dir. corrente
            //WriteOnFile(@"C:\FileClienti\", "MovClienti.txt");                            //Scrive il file nella dir.
            //ReadOnFile(@"C:\FileClienti\", "MovClienti.txt");                             //Legge il file
            //SimpleFileMove(@"C:\FileClienti\", @"C:\FileClientiBk\", "MovClienti.txt");   //Muove il file in backup
            //SimpleFileCopy(@"C:\FileClientiBk\", @"C:\FileClienti\", "MovClienti.txt");   //Copia il file
            //SimpleFileDelete(@"C:\FileClienti\", "MovClienti.txt");                       //Cancella il file
        }
        static void SpecialPath(string RootPath, String MyDir) // Path  = percorso LOCAL  -> REMOTE path -> SERVER , URL 
        {
            string myPath = $"{RootPath}{Path.DirectorySeparatorChar}{MyDir}";

            Console.WriteLine(myPath);

        }
        static void SpecialDirectory()
        {
            string SpecialDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(SpecialDir);
        }
        static void SplitPath()
        {
            string myDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(myDirectory);
            string[] splitedPath = myDirectory.Split(Path.DirectorySeparatorChar);

            foreach (var item in splitedPath)
            {
                int counter = 1;
                Console.Write(counter + "-");
                Console.WriteLine(item);
                counter++;
            }
            JoinPath(splitedPath);
        }
        static void JoinPath(string[] _path)
        {

            var path = Path.Combine(_path);
            Console.Write("JOINED STRINGS: ");
            Console.WriteLine(path);
        }
        static void GetFileExtention()
        {
            var fExt = Path.GetExtension("vendita.json");
        }
        static void GetDirInfo()
        {
            string path = Directory.GetCurrentDirectory(); // -> trova il Path 
            DirectoryInfo dInfos = new DirectoryInfo(path);

            //foreach (var info in dInfos.GetDirectories())
            //{
            //    Console.WriteLine(info.Parent);
            //}

            foreach (var item in dInfos.GetFiles())
            {
                Console.WriteLine(item.Name);

            }
        }
        static void SearchInDirectory()
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory(),
                "*.dll",
                SearchOption.AllDirectories);

            foreach (var file in files)
                Console.WriteLine(file);
        }
        static void FindOrCreate(String path)
        {
            DirectoryInfo info = new DirectoryInfo(path);

            if (info.Exists)
            {
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Parent);
            }
            else
            {
                info.Create();
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Parent);
            }
        }
        static void CreateFile(string FileName)
        {
            File.Create(FileName);
        }
        static void WriteOnFile(string path, string FileName)
        {
            List<string> mytext = new List<string>()
            {
                "Movimento conto Bruno",
                "Movimento conto marco",
                "Movimento conto Maria"
            };

            File.AppendAllLines(Path.Combine(path, FileName), mytext);
        }
        static void ReadOnFile(string path, string FileName)
        {
            var texd = File.ReadAllText(Path.Combine(path, FileName));
            Console.WriteLine(texd);
        }
        static void SimpleFileMove(string SrcPath, string destPath, string Filename)
        {
            string Src = Path.Combine(SrcPath, Filename);
            string dest = Path.Combine(destPath, Filename);
            File.Move(Src, dest);
        }
        static void SimpleFileCopy(string SrcPath, string destPath, string Filename)
        {
            string Src = Path.Combine(SrcPath, Filename);
            string dest = Path.Combine(destPath, Filename);
            File.Copy(Src, dest, true);
        }
        static void SimpleFileDelete(string SrcPath, string Filename)
        {

            File.Delete(Path.Combine(SrcPath, Filename));

        }


    }

}
