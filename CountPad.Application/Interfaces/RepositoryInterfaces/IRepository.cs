// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountPad.Application.Interfaces.RepositoryInterfacess
{
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);
    }
}
