using PersonRepository.Interface;
using PersonRepository.Factory;
using System;
using System.Text;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryType? selectedRepositoryType = TryToGetRepositoryTypeFromUser();
            ShowPeople(selectedRepositoryType);
        }

        private static RepositoryType? TryToGetRepositoryTypeFromUser()
        {
            bool isSelectedRepositoryChoiceValid = false;
            RepositoryType? repositoryType;
            do
            {
                AskUserToChooseRepository();

                repositoryType = GetSelectedRepositoryTypeChoiceFromUser();

                if (repositoryType.HasValue)
                {
                    isSelectedRepositoryChoiceValid = Enum.IsDefined(typeof(RepositoryType), repositoryType);
                }
            } while (!isSelectedRepositoryChoiceValid);
            return repositoryType;
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
