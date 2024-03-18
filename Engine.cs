using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zXmlMove
{
    public class Engine
    {
        public string FileElenco { get; set; } = string.Empty;
        public string XmlMoveFolder { get; set; } = string.Empty;
        public string XmlPath { get; set; } = string.Empty;

        public void XmlMove(){

            try
            {
                string fromPath = Environment.CurrentDirectory;
                string toPath = Path.Combine(fromPath, XmlMoveFolder);
                string[] fileTxt;


                if (!Path.Exists(toPath))
                {
                    Directory.CreateDirectory(toPath);
                }

                if (!File.Exists(FileElenco))
                {
                    throw new Exception($"File inesistente: {FileElenco}");
                }

                fileTxt = File.ReadAllLines(FileElenco);
                Console.WriteLine($"Totale files da spostare: {fileTxt.Length}");
                
                for (int i = 0; i < fileTxt.Length; i++)
                {
                    string filexml = fileTxt[i];
                    
                    if (File.Exists(filexml))
                    {
                        Console.WriteLine($"File xml '{filexml}'");
                        string pathOrigin = Path.GetFullPath(filexml);
                        string pathDest = Path.Combine(toPath, filexml);

                        Console.WriteLine($"Move {pathOrigin} -> {pathDest}");

                        File.Move(pathOrigin, pathDest, true);

                        
                    }
                    else
                    {
                        Console.WriteLine($"File xml '{filexml}': NON TROVATO");
                    }
                }

                



                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Eccezione: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Dettaglio: {ex.InnerException.Message}");
            }


        }



    }
}