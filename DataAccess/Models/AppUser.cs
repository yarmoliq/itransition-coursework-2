﻿using System;
using Microsoft.AspNetCore.Identity;

using DataAccess.Interfaces;

namespace DataAccess.Models
{
    public class AppUser : IdentityUser<Guid>, IDeletable, IAuditable, IEntity
    {
        public bool isDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        //public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}