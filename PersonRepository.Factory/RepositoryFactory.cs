using PersonRepository.CSV;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.SQL;
using System;

namespace PersonRepository.Factory
{
    public static class RepositoryFactory
    {
        public static IPersonReader GetRepository(RepositoryType repositoryType)
        {
            IPersonReader repository;

            switch (repositoryType)
            {
                case RepositoryType.CSV:
                    repository = new CSVRepository();
                    break;
                case RepositoryType.Service:
                    repository = new ServiceRepository();
                    break;
                case RepositoryType.SQL:
                    repository = new SQLRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid repository type");
            }

            return repository;
        }
    }
}
