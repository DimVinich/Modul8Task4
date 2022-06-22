using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;


namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string aName, string aGroup, DateTime aDateOfBirth)
        {
            Name = aName;
            Group = aGroup;
            DateOfBirth = aDateOfBirth;
        }

    }
}
