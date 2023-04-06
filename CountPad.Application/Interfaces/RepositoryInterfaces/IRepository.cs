﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace CountPad.Application.Interfaces.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T @object);
    }
}

