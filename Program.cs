// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

class Program
{
    public string? input { get; set; }
    static void Main(string[] args)
    {
        var relativePath = "tempfolder\\myfile.md";
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

        var fileInfo = new FileInfo(fullPath);
        using (StreamReader stream = fileInfo.OpenText())
        {
            string? line;
            string text = "";
            while ((line = stream.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line) || line != Environment.NewLine)
                {
                    text += line + " ";
                }
            }
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Word count: {countWords(text)}");
        }


    }

    public static int countWords(string input)
    {
        var words = input.Split(new string[] {"  ", " "}, StringSplitOptions.RemoveEmptyEntries);
        // foreach (var word in words)
        //     Console.WriteLine($"-{word}- ");
        return words.Length;
    }
}