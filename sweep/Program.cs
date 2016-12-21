using System;
using CommandLine;

namespace sweep
{
    class Program
    {
        static void Main(string[] args)
        {
            CLIOptions options = new CLIOptions();

             if (Parser.Default.ParseArguments(args, options))
             {
                 if (options.Help)
                 {
                     Console.WriteLine(options.GetUsage());
                     return;
                 }
                 try
                 {
                     new MoveFiles(options.SourceDirectory, options.DestinationDirectory, options.Create, options.Verbose);
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine("Error: " + e.Message);
                     Console.WriteLine(options.GetUsage());
                 }
            } 
        }
    }
}
