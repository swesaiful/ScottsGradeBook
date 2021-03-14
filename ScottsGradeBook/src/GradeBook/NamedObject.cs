using System;

namespace GradeBook
{
    public class NamedObject
    {
        private string name;

        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                // else
                // {
                //     throw new ArgumentException($"Invalid {nameof(value)}");
                // }
            }
        }
        
    }
}
