using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuttoNotes.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuttoNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteUpdate : ContentPage
    {
        public NoteUpdate(Note note)
        {
            if (note == null)
                throw new ArgumentNullException();
            BindingContext = note;
            InitializeComponent();
        }
    }
}