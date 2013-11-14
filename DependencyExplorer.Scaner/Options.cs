using System.Text;
using CommandLine;

namespace DependencyExplorer.Scaner
{
    class Options
    {
        [Option('p', "path", Required = true, HelpText = "Path to the folder to be scanned.")]
        public string Path { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            //  or using HelpText.AutoBuild
            var usage = new StringBuilder();
            usage.AppendLine("DependencyExplorer.Scaner Application 1.0");
            usage.AppendLine("Read user manual for usage instructions...");
            return usage.ToString();
        }
    }

}