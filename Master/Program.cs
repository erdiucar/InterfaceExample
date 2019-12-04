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
            bool isSelectedRepositoryChoiceValid = false;
            RepositoryType? selectedRepositoryType;
            do
            {
                AskUserToChooseRepository();

                selectedRepositoryType = GetSelectedRepositoryTypeChoiceFromUser();

                if (selectedRepositoryType.HasValue)
                {
                    isSelectedRepositoryChoiceValid = Enum.IsDefined(typeof(RepositoryType), selectedRepositoryType);
                }
            } while (!isSelectedRepositoryChoiceValid);

            ShowPeople(selectedRepositoryType);
        }

        private static void ShowPeople(RepositoryType? repositoryType)
        {
            IPersonRepository repository = RepositoryFactory.GetRepository(repositoryType);

            try
            {
                var people = repository.GetPeople();

                foreach (var person in people)
                {
                    Console.WriteLine(GetPersonInformationAsStringFormat(person));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static RepositoryType? GetSelectedRepositoryTypeChoiceFromUser()
        {
            try
            {
                RepositoryType? choiseOfUser = (RepositoryType)Convert.ToInt32(Console.ReadLine());
                return choiseOfUser;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private static void AskUserToChooseRepository()
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
            sb.AppendLine("Surname: " + person.Rating);
            if (!String.IsNullOrWhiteSpace(person.FormatString))
                sb.AppendLine("Format String: " + person.FormatString);

            return sb.ToString();
        }
    }
}
