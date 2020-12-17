using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TuttoNotes.Model
{
   public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime NoteDate { get; set; }
        public bool IsImportant { get; set; }
    }
}
