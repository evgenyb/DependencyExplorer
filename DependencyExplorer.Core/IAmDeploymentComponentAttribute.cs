using System;

namespace DependencyExplorer.Core
{
    [AttributeUsage(AttributeTargets.Assembly)]
    // ReSharper disable once InconsistentNaming
    public class IAmDeploymentComponentAttribute : Attribute
    {
        public IAmDeploymentComponentAttribute(string name)
        {
            Name = name;
        }
        private string Name { get; set; }         
    }
}