using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Service.Models
{
    public interface IPeopleProvider
    {
        List<Person> GetPeople();
    }
}
