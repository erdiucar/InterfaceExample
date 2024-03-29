﻿using PersonRepository.Interface;
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
            RepositoryType selectedRepositoryType = GetARepositoryTypeFromUser();

            try
            {
                ShowPeople(selectedRepositoryType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static RepositoryType GetARepositoryTypeFromUser()
        {
            while (true)
            {
                AskUserToChooseARepositoryType();

                RepositoryType selectedRepositoryType;

                bool isSelectedRepositoryTypeParsed = Enum.TryParse(Console.ReadLine(), out selectedRepositoryType);
                bool isSelectedRepositoryTypeDefined = Enum.IsDefined(typeof(RepositoryType), selectedRepositoryType);

                if (isSelectedRepositoryTypeParsed && isSelectedRepositoryTypeDefined)
                    return selectedRepositoryType;
            }
        }

        private static void ShowPeople(RepositoryType repositoryType)
        {
            IPersonReader repository = RepositoryFactory.GetRepository(repositoryType);
            IEnumerable<Person> people = repository.GetPeople();

            foreach (var person in people)
            {
                Console.WriteLine(GetPersonInformation(person));
            }
        }

        private static void AskUserToChooseARepositoryType()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Choose a repository type to get data:");
            sb.AppendLine("1. CSV");
            sb.AppendLine("2. Service");
            sb.AppendLine("3. SQL");

            Console.WriteLine(sb.ToString());
        }

        public static string GetPersonInformation(Person person)
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
