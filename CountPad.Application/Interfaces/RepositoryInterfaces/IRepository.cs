// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;

namespace CountPad.Application.Interfaces.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        Task<int> AddAsync(T entity);
    }
}

