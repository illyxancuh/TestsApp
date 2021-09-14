using System;

namespace TestProj.DataAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionName : Attribute
    {
        public string Name { get; }

        public CollectionName(string name)
        {
            Name = name;
        }
    }
}
