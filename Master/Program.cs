using PersonRepository.Interface;
using PersonRepository.Factory;
using System;
using System.Text;
using System.Collections.Generic;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryType selectedRepositoryType = GetSelectedRepositoryTypeFromUser();

            try
            {
                ShowPeople(selectedRepositoryType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        private static RepositoryType GetSelectedRepositoryTypeFromUser()
        {
            while (true)
            {
                try
                {
                    AskUserToChooseRepositoryType();
                    RepositoryType selectedRepositoryType = (RepositoryType)Convert.ToInt32(Console.ReadLine());
                    bool isSelectedRepositoryChoiceValid = Enum.IsDefined(typeof(RepositoryType), selectedRepositoryType);

                    if (isSelectedRepositoryChoiceValid)
                        return selectedRepositoryType;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ShowPeople(RepositoryType repositoryType)
        {
            IPersonRepository repository = RepositoryFactory.GetRepository(repositoryType);
            IEnumerable<Person> people = repository.GetPeople();

            foreach (var person in people)
            {
                Console.WriteLine(GetPersonInformationAsStringFormat(person));
            }
        }

        private static void AskUserToChooseRepositoryType()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Choose a repository type to get data:");
            sb.AppendLine("1. CSV");
            sb.AppendLine("2. Service");
            sb.AppendLine("3. SQL");

            Console.WriteLine(sb.ToString());
        }

        public static string GetPersonInformationAsStringFormat(Person person)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Name: " + person.Name);
            sb.AppendLine("Surname: " + person.Surname);
            sb.AppendLine("Start Date: " + person.StartDate.ToShortDateString());
            sb.AppendLine("Rating: " + person.Rating);
            if (!String.IsNullOrWhiteSpace(person.FormatString))
                sb.AppendLine("Format String: " + person.FormatString);

            return sb.ToString();
        }
    }
}
