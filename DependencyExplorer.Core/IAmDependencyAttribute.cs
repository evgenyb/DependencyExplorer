using System;

namespace DependencyExplorer.Core
{
    [AttributeUsage(AttributeTargets.Assembly)]
// ReSharper disable once InconsistentNaming
    public class IAmDependencyAttribute : Attribute
    {
        public IAmDependencyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
