using Newtonsoft.Json;
using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.Net;

namespace PersonRepository.Service
{
    public class ServiceRepository : IPersonReader
    {
        WebClient client = new WebClient();
        string baseUri = "http://localhost:9874/people";

        public IEnumerable<Person> GetPeople()
        {
            string result = client.DownloadString(baseUri);
            IEnumerable<Person> people =
                JsonConvert.DeserializeObject<IEnumerable<Person>>(result);
            return people;
        }
    }
}
