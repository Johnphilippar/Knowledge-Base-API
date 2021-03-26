using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CLEAN_Domain.Business
{
    public static class FileIO
    {
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        
        public static void CreateFile(string path)
        {
    
            if (!File.Exists(path))
                File.Create(path).Close();

        }

        public static void WriteText(string text, string path)
        {
            if (File.Exists(path))
            {
                TextWriter tsw = new StreamWriter(path, true);
                tsw.WriteLine(text);
                tsw.Close();
            }
        }

        public static string ReadText(string path)
        {
            string text = "";
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    do
                    {
                        text += sr.ReadLine();
                    } while (sr.ReadLine() != null);
                }
            }
            return text;
        }

        public static string CopyFile(IEnumerable<IFormFile> _files, string path)
        {
            string Files = "";
            foreach (IFormFile file in _files)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string awdad = path + "\\" + filename;
                using (var fileStream = new FileStream(path + "\\" + filename, FileMode.Create))
                {
                    Files += filename + "|~|" + Path.GetFileName(file.FileName) + "|~~|" + file.ContentType + "`";
                    file.CopyTo(fileStream);
                }
            }
            return Files.Substring(0, Files.Length - 1);
        }

    }
}
