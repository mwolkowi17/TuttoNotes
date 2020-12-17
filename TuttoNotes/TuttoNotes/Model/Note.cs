using System;
using System.Collections.Generic;
using System.Text;

namespace TuttoNotes.Model
{
    class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime NoteDate { get; set; }
        public bool IsImportant { get; set; }
    }
}
