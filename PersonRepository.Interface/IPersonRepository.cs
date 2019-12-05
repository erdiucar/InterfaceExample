using System;
using System.Collections.Generic;

namespace PersonRepository.Interface
{
    public interface IPersonRepository : IPersonReader
    {
        Person GetPerson(int id);

        void AddPerson(Person newPerson);

        void UpdatePerson(int id, Person updatedPerson);

        void DeletePerson(int id);
    }
}
