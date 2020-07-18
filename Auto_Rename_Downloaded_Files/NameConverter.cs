using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Auto_Rename_Downloaded_Files
{
    public class NameConverter
    {
        public string DirectoryPath { get; private set; }
        public NameConverter(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        //TODO have to return informations
        public void GetExampleFileConverted(int numberOfExamples)
        {
            var files = Directory.GetFiles(DirectoryPath);

            for(var index = 0; index < numberOfExamples; index++)
            {
                var newName = NewName(files[index]);
                var file = new FileInfo(files[index]);
                Console.WriteLine($"'{file.Name}' => '{newName.Substring(Regex.Matches(newName, @"\\|//").Last().Index + 1)}'");
            }
        }

        //TODO create a system to delete specifics words before checks (example, if exceptions.txt exists get words and remove its on the name of episodes)
        public void RenameFiles()
        {
            var files = Directory.GetFiles(DirectoryPath);

            foreach (var filePath in files)
            {
                var newName = NewName(filePath);
                var file = new FileInfo(filePath);
                Console.WriteLine($"'{file.Name}' => '{newName.Substring(Regex.Matches(newName, @"\\|//").Last().Index + 1)}'");

                file.MoveTo(newName);
            }
        }

        private string NewName(string filePath)
        {
            string newName;
            Regex episodeRegex = new Regex(@"E\d+", RegexOptions.IgnoreCase);
            Regex SeasonRegex = new Regex(@"S\d+", RegexOptions.IgnoreCase);
            FileInfo file = new FileInfo(filePath);
            
            if (!episodeRegex.IsMatch(file.FullName))
            {
                Console.WriteLine($"'{file.Name}' => SKIPED, because invalid name");
            }

            var filename = file.FullName.Substring(0, episodeRegex.Match(file.FullName).Index + episodeRegex.Match(file.FullName).Length);

            var episode = episodeRegex.Match(filename).Value.Substring(1);
            newName = episodeRegex.Replace(filename, $"- {episode}").Replace(".", " ");

            if (SeasonRegex.IsMatch(filename))
            {
                var season = SeasonRegex.Match(filename).Value.Substring(1);
                newName = SeasonRegex.Replace(newName, $"- Saison {season}");

                //if the name of ep is S01E01 (example of name), had space between S01 and E01
                if (Regex.IsMatch(newName, @"\d-"))
                {
                    var index = newName.LastIndexOf("-");
                    newName = newName.Remove(index, 1).Insert(index, " -");
                }
            }
            newName += file.Extension;

            return newName;
        }

    }
}
