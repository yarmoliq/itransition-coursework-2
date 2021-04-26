using System;

using DataAccess.Interfaces;

namespace DataAccess.Models
{
    public class NoteItem : IDeletable, IAuditable, IEntity
    {
        public Guid Id { get; set; }
        public bool isDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } 
        public string Title { get; set; }
        public string Contents { get; set; }
    }
}