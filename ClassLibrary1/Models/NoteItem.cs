using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Models
{
    public class NoteItem : IEntity 
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
    }
}