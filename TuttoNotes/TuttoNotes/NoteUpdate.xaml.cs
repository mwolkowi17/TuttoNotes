using SQLite;
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
        public SQLiteAsyncConnection _connection;
        public NoteUpdate(Note note)
        {
            if (note == null)
                throw new ArgumentNullException();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            BindingContext = note;
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as Button;
            var noteToUpdate = menuItem.CommandParameter as Note;
            noteToUpdate.Title = NoteTilte.Text;
            noteToUpdate.Body = NoteBody.Text;
            noteToUpdate.NoteDate = NoteDate.Date;
            await _connection.UpdateAsync(noteToUpdate);
            await Navigation.PopAsync();
        }
    }
}