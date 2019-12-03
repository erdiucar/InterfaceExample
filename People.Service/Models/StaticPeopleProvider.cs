using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonRepository.Interface;

namespace People.Service.Models
{
    public class StaticPeopleProvider : IPeopleProvider
    {
        public List<Person> GetPeople()
        {
            var people = new List<Person>()
            {
                new Person() { Id=1, Name="Erdi", Surname="Uçar",
                    StartDate = new DateTime(1987, 1, 1), Rating=6 },
                new Person() { Id=2, Name="Umut", Surname="Unut",
                    StartDate = new DateTime(2000, 10, 2), Rating=8 },
                new Person() { Id=3, Name="George", Surname="Borch",
                    StartDate = new DateTime(1999, 3, 28), Rating=8,
                    FormatString = "{1} {0}" },
            };

            return people;
        }
    }
}
