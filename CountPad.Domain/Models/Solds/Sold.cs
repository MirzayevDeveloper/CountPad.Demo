// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using CountPad.Domain.Models.Users;

namespace CountPad.Domain.Models.Solds
{
    public class Sold
    {
        public Guid Id { get; set; }
        public DateTime SoldDate { get; set; }
        public User User { get; set; }
    }
}
