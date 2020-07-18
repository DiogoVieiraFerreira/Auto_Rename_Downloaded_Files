using System;
using System.IO;

namespace Auto_Rename_Downloaded_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirPath = Environment.CurrentDirectory;

            while (!PromptConfirmation($"Get all episodes on {dirPath} ?"))
            {
                do
                {
                    Console.Clear();
                    Console.Write("What's location of episodes : ");
                    dirPath = Console.ReadLine();
                } while (!Directory.Exists(dirPath));
            }
            NameConverter nameConverter = new NameConverter(dirPath);
            Console.WriteLine("\n\nExample with your Files!\n\n");
            nameConverter.GetExampleFileConverted(2);

            if (!PromptConfirmation("rename files?"))
                return;
            //TODO if not, user inform if series has multiple seasons, if yes user insert total of seasons and how many episodes by season and he give the name of serie.
            Console.WriteLine("\n\nRename Files!\n\n");
            nameConverter.RenameFiles();
        }
        static bool PromptConfirmation(string confirmText)
        {
            Console.Write(confirmText + " [y/n] : ");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            return (response == ConsoleKey.Y);
        }
    }
}
