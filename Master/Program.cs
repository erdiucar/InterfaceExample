using PersonRepository.Interface;
using PersonRepository.Service;
using System;
using System.Text;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonRepository repository = new ServiceRepository();
            var people = repository.GetPeople();

            foreach (var person in people)
            {
                Console.WriteLine(GetPersonInformationAsFormattedString(person));
            }
        }
        public static string GetPersonInformationAsFormattedString(Person person)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Name: " + person.Name);
            sb.AppendLine("Surname: " + person.Surname);
            sb.AppendLine("Start Date: " + person.StartDate.ToShortDateString());
            sb.AppendLine("Surname: " + person.Rating);
            if (!String.IsNullOrWhiteSpace(person.FormatString))
                sb.AppendLine("Format String: " + person.FormatString);

            return sb.ToString();
        }
    }
}
