using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DependencyExplorer.Core;

namespace DependencyExplorer.Scaner
{
    class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Scanning inside " + options.Path + " folder...");
                var di = new DirectoryInfo(options.Path);
                var files = di.GetFiles("*.dll");
                foreach (FileInfo fileName in files)
                {
                    Console.WriteLine(fileName.Name);

                    var assembly = Assembly.LoadFrom(fileName.FullName);

                    CheckDependency(assembly);
                    CheckDeploymentComponent(assembly);
                }
                files = di.GetFiles("*.exe");
                foreach (FileInfo fileName in files)
                {
                    Console.WriteLine(fileName.Name);

                    var assembly = Assembly.LoadFrom(fileName.FullName);

                    CheckDependency(assembly);
                    CheckDeploymentComponent(assembly);
                }
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void CheckDependency(Assembly assembly)
        {
            var attribute = assembly
                .GetCustomAttributesData()
                .SingleOrDefault(x => x.ToString().Contains(typeof(IAmDependencyAttribute).ToString()));

            if (attribute != null)
            {
                Console.WriteLine(attribute.ConstructorArguments[0]);
            }
        }
        private static void CheckDeploymentComponent(Assembly assembly)
        {
            var attribute = assembly
                .GetCustomAttributesData()
                .SingleOrDefault(x => x.ToString().Contains(typeof(IAmDeploymentComponentAttribute).ToString()));

            if (attribute != null)
            {
                Console.WriteLine(attribute.ConstructorArguments[0]);
            }
        }
    }
}
