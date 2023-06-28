// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

class Program
{
    public static string? input { get; set; }
    static void Main(string[] args)
    {
        #region:Strings
        
        #region:66. String Builder
        // var builder = new StringBuilder("Hello World");
        // builder
        //     .Append('-', 10)
        //     .AppendLine()
        //     .Append("Header")
        //     .AppendLine()
        //     .Append('-', 10)
        //     .Replace("-", "+")
        //     .Remove(0, 10)
        //     .Insert(0, new string('-', 10));

        // Console.WriteLine(builder);

        // Console.WriteLine($"First Character: {builder[0]}");
        #endregion

        #region:68. Exercises
        /*
        * 1- Write a program and ask the user to enter a few numbers separated by a hyphen. 
        * Work out if the numbers are consecutive. 
        * For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".
        */
        string inputNumbers1 = numberListPrompt();
        var numberList = inputNumbers1.Split('-');
        
        //Check if numbers are consecutive
        var consecutive = true;
        for (int i = 1; i < numberList.Length; i++){
            if (Convert.ToInt32(numberList[i]) < Convert.ToInt32(numberList[i - 1])){
                consecutive = false;
                break;
            }
        }
        
        if (string.IsNullOrEmpty(inputNumbers1))
        {
            Console.WriteLine("No input.");
        }
        else
        {
            Console.WriteLine($"The numbers {inputNumbers1} are . . . " + (consecutive ? "Consecutive" : "Not Consecutive"));
        }

        /*
        * 2- Write a program and ask the user to enter a few numbers separated by a hyphen.
        * If the user simply presses Enter, without supplying an input, exit immediately;
        * otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.
        */
        string inputNumbers2 = numberListPrompt();
        if (string.IsNullOrEmpty(inputNumbers2))
        {
            return;
        }
        else
        {
            //Check for duplicates
            var numberList2 = inputNumbers2.Split('-');
            for (int i = 0; i < numberList2.Length; i++)
            {
                var potentialDuplicates = numberList2.Where(s => s.Equals(numberList2[i]));
                if (potentialDuplicates.Count() > 1) {
                    Console.WriteLine("Duplicate");
                    return;
                }
            }
        }

        #endregion
        
        
        #endregion
    }

    public static string numberListPrompt() {
        //Get input from user
        Console.WriteLine("Please enter a few numbers separated by a hyphen (ex. 5-2-7-4-9)");
        input = Console.ReadLine() as string;
        return input is not null ? input : "";
    }
}