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
}