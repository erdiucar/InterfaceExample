using System;
using System.Collections.Generic;
using System.Text;

namespace PersonRepository.Interface
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime StartDate { get; set; }
        public int Rating { get; set; }
        public string FormatString { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FormatString))
                FormatString = "{0} {1}";
            return string.Format(FormatString, Name, Surname);
        }
    }
}
