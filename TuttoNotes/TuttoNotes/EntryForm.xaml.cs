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
    public partial class EntryForm : ContentPage
    {
        public SQLiteAsyncConnection _connection;
        public EntryForm()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var newdate=e.NewDate;
        }

        async private void  Button_Clicked(object sender, EventArgs e)
        {
            var noteToAdd = new Note();
            noteToAdd.Title = NoteTilte.Text;
            noteToAdd.Body = NoteBody.Text;
            noteToAdd.NoteDate = NoteDate.Date;
            await _connection.InsertAsync(noteToAdd);
            await Navigation.PopAsync();

        }

       
    }
}