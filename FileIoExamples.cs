using System.Text.RegularExpressions;

public class FileIoExamples
{


    public void FileFileInfoDemo()
    {
        /* File is a static class so you don't need to create an instance of it.
        Makes it good for quick things with files.
        However, it does do some sequrity checks on the file that can eat up time.
        */
        var path = @"c:temp\somefile.jpg";

        File.Copy(path, @"d:\temp\somefile.jpg", true);
        File.Delete(path);
        if (File.Exists(path))
        {
            // Do something
        }

        var content = File.ReadAllText(@"d:\temp\somefile.jpg");

        /* 
         * FileInfo is an instance class so you need to create an instance of it.
         * Better for when you need to do more complicated interactions with a file.
         */
         var fileInfo = new FileInfo(path);
         fileInfo.CopyTo("...");
         fileInfo.Delete();
         if (fileInfo.Exists)
         {
             // Do something
         }
    }
}

public class DirectoryPathDemo
{
    public void DirectoryExample()
    {
        // Look through all the C# files at a certain path
        Directory.CreateDirectory(@"C:\temp\folder1");
        var files = Directory.GetFiles(@"C:\Users\Jordan.Glover\Documents\Jordan-workspace\Online Coursework\Udemy\C# Fundamentals", "*.cs", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

        // Look through all the directories at a certain path
        var directories = Directory.GetDirectories(@"C:\Users\Jordan.Glover\Documents\Jordan-workspace\Online Coursework\Udemy\C# Fundamentals", "*.*", SearchOption.AllDirectories);
        foreach (var directory in directories)
        {
            Console.WriteLine(directory);
        }

        // Determine if some directory exists
        Directory.Exists("...");

        // For more info about Directory class, see https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-7.0
        // For working with your current directory, see https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory?view=net-7.0#system-io-directory-getcurrentdirectory
        // Here is an example of how you might use Directory.GetDirectories() to use a relative path
        string relativePath = "myFile.txt";
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            writer.WriteLine("Hello, world!");
        }
    }

    public void PathDemo()
    {
        var path = @"C:\Users\Jordan.Glover\Documents\Jordan-workspace\Online Coursework\Udemy\C# Fundamentals\C# Basics\C# Basics.csproj";

        var dotIndex = path.IndexOf('.');
        var extension = path.Substring(dotIndex);

        Console.WriteLine("Extension: " + extension);
        Console.WriteLine("Extension: " + Path.GetExtension(path));
        Console.WriteLine("File Name: " + Path.GetFileName(path));
        Console.WriteLine("File Name without Extension:" + Path.GetFileNameWithoutExtension(path));
        Console.WriteLine("Directory Name: " + Path.GetDirectoryName(path));

        // For more info about Path class, see https://docs.microsoft.com/en-us/dotnet/api/system.io.path?view=net-7.0
    }

    public void FileIoExercise1()
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

    public int countWords(string input)
    {
        var words = input.Split(new string[] {"  ", " "}, StringSplitOptions.RemoveEmptyEntries);
        // foreach (var word in words)
        //     Console.WriteLine($"-{word}- ");
        return words.Length;
    }

    public void FileIoExercise2()
    {
        var relativePath = "tempfolder\\myfile.md";
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

        var fileInfo = new FileInfo(fullPath);

        using (StreamReader reader = fileInfo.OpenText())
        {
            var allText = reader.ReadToEnd();
            Console.WriteLine($"Longest word from the text: \n \"{allText}\" \n is {getLongestWord(allText)}");
        }
    }

    public string getLongestWord(string input)
    {
        int longest = 0;
        int indexOfLongest = 0;
        var words = input.Split();
        foreach (var word in words.Select((value, i) => new { value, i }))
        {
            string wordSanitized = Regex.Replace(word.value, "[^a-zA-Z0-9]", "");
            if (wordSanitized.Length > longest)
            {
                longest = wordSanitized.Length;
                indexOfLongest = word.i;
            }
        }
        return Regex.Replace(words[indexOfLongest], "[^a-zA-Z0-9]", "");
    }
}