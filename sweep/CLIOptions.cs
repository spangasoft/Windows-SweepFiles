using System.Text;
using CommandLine;


namespace sweep
{
    class CLIOptions
    {
        [Option('s', "source", Required = false, HelpText = "The Source directory to sweep files from.")]
        public string SourceDirectory { get; set; }

        [Option('t', "target", Required = false, HelpText = "The destination directory to sweep files to.")]
        public string DestinationDirectory { get; set; }

        [Option('c', "create", Required = false, HelpText = "Create the target directory if it doesn't exist.")]
        public bool Create { get; set; }

        [Option('v', "verbose", HelpText = "Print details during execution.")]
        public bool Verbose { get; set; }

        [Option('?', "help", HelpText = "Print detailed help.")]
        public bool Help { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            StringBuilder usage = new StringBuilder();
            usage.AppendLine("Sweeps files from one directory to another directory. Sweep will monitor each");
            usage.AppendLine("file prior to moving to ensure that the file isn't currently being written to.");
            usage.AppendLine("");
            usage.AppendLine("SWEEP is designed for the process of moving files from a dropbox directory to");
            usage.AppendLine("the desired final landing directory.");
            usage.AppendLine("");
            usage.AppendLine("SWEEP will pause while it waits for files to finish being written to prior to");
            usage.AppendLine("sweeping them to the target directory.");
            usage.AppendLine("");
            usage.AppendLine("SWEEP -S [drive:]path -T [drive:]path [-C] [-V]");
            usage.AppendLine("");
            usage.AppendLine("  [drive:]path");
            usage.AppendLine("            Specifies a path to a directory to sweep files from/to.");
            usage.AppendLine("");
            usage.AppendLine("  -S        Specifies the source path where files will be moved from.");
            usage.AppendLine("  -T        Specifies the target path where files will be moved to.");
            usage.AppendLine("  -C        Creates the target directory if it does not exist.");
            usage.AppendLine("  -V        Verbose logging of activity.");
            return usage.ToString();
        }
    }
}
